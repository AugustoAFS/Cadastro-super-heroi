using ApplicationService.Dtos.Requests.Heroi;
using ApplicationService.Dtos.Resposes.Heroi;
using ApplicationService.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class HeroiService : IHeroiService
    {
        private readonly IHeroisRepository _repository;

        public HeroiService(IHeroisRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HeroiResponse>> GetAllAAssync()
        {
            var herois = await _repository.GetAllAsync();
            return herois.Select(MapToResponse).ToList();
        }

        public async Task<HeroiResponse> GetByIdAsync(int id)
        {
            var heroi = await _repository.GetByIdAsync(id);
            if (heroi == null) return null;

            return MapToResponse(heroi);
        }

        public async Task<HeroiResponse> CreateAsync(CreateHeroiRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Para criar um heroi as informações dele não podem ser nulas");
            }

            if (await _repository.ExisteHeroiComNomeAsync(request.NomeHeroi))
            {
                throw new Exception("Já existe um herói cadastrado com este nome de herói.");
            }

            var heroi = new Herois
            {
                Nome = request.Nome,
                NomeHeroi = request.NomeHeroi,
                DataNascimento = request.DataNascimento,
                Altura = request.Altura,
                Peso = request.Peso,
                Created_At = DateTime.Now,
                HeroisSuperpoderes = new List<HeroisSuperpoderes>()
            };

            if (request.SuperpoderesIds != null)
            {
                foreach (var superpoderId in request.SuperpoderesIds)
                {
                    heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderes
                    {
                        SuperpoderId = superpoderId,
                        Created_At = DateTime.Now
                    });
                }
            }

            var criado = await _repository.CreateAsync(heroi);
            
            return await GetByIdAsync(criado.Id);
        }

        public async Task<HeroiResponse> UpdateAsync(int id, UpdateHeroiRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var heroi = await _repository.GetByIdAsync(id);
            if (heroi == null) throw new Exception("Herói não encontrado.");

            if (await _repository.ExisteHeroiComNomeAsync(request.NomeHeroi, id))
            {
                throw new Exception("Já existe outro herói cadastrado com este nome de herói.");
            }

            heroi.Nome = request.Nome;
            heroi.NomeHeroi = request.NomeHeroi;
            heroi.DataNascimento = request.DataNascimento;
            heroi.Altura = request.Altura;
            heroi.Peso = request.Peso;

            if (request.SuperpoderesIds != null)
            {
                heroi.HeroisSuperpoderes.Clear();
                foreach (var superpoderId in request.SuperpoderesIds)
                {
                    heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderes
                    {
                        SuperpoderId = superpoderId,
                        Created_At = DateTime.Now,
                        HeroiId = heroi.Id
                    });
                }
            }

            await _repository.UpdateAsync(heroi);
            
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
             var heroi = await _repository.GetByIdAsync(id);
             if (heroi == null) throw new Exception("Herói não encontrado.");

             return await _repository.DeleteAsync(id);
        }

        private HeroiResponse MapToResponse(Herois heroi)
        {
            return new HeroiResponse
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.HeroisSuperpoderes?
                    .Select(hs => hs.Superpoder?.Superpoder)
                    .Where(s => s != null)
                    .ToList() ?? new List<string>()
            };
        }
    }
}