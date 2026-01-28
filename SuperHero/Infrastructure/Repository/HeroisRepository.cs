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
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoder)
                .ToListAsync();
        }

        public override async Task<Herois?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoder)
                .FirstOrDefaultAsync(h => h.Id == id);
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
    }
}
