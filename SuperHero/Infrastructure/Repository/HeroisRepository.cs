using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class HeroisRepository : BaseRepository<Herois>, IHeroisRepository
    {
        public HeroisRepository(SuperHeroDbContext context) : base(context)
        { }

        public override async Task<List<Herois>> GetAllAsync()
        {
            return await _dbSet
                .Where(h => !h.Flg_Inativo)
                .Include(h => h.HeroisSuperpoderes.Where(hs => !hs.Flg_Inativo))
                .ThenInclude(hs => hs.Superpoder)
                .ToListAsync();
        }

        public override async Task<Herois?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(h => h.HeroisSuperpoderes.Where(hs => !hs.Flg_Inativo))
                .ThenInclude(hs => hs.Superpoder)
                .FirstOrDefaultAsync(h => h.Id == id && !h.Flg_Inativo);
        }

        public async Task<bool> ExisteHeroiComNomeAsync(string nomeHeroi, int? ignorarId = null)
        {
            var query = _dbSet.AsQueryable();

            if (ignorarId.HasValue)
            {
                query = query.Where(h => h.Id != ignorarId.Value);
            }

            return await query.AnyAsync(h => h.NomeHeroi == nomeHeroi);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var heroi = await GetByIdAsync(id);
            if (heroi == null) return false;

            heroi.Flg_Inativo = true;
            heroi.Deleted_At = DateTime.Now;

            if (heroi.HeroisSuperpoderes != null)
            {
                foreach (var hs in heroi.HeroisSuperpoderes)
                {
                    hs.Flg_Inativo = true;
                    hs.Deleted_At = DateTime.Now;
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
