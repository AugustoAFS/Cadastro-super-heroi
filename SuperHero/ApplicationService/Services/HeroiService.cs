using ApplicationService.Common;
using ApplicationService.Dtos.Requests.Heroi;
using ApplicationService.Dtos.Resposes.Heroi;
using ApplicationService.Interfaces;
using ApplicationService.Mappings;
using Domain.Entities;
using Domain.Exceptions;
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
        private readonly HeroiMapper _heroiMapper;
        private readonly SuperpoderMapper _superpoderMapper;

        public HeroiService(IHeroisRepository repository, HeroiMapper heroiMapper, SuperpoderMapper superpoderMapper)
        {
            _repository = repository;
            _heroiMapper = heroiMapper;
            _superpoderMapper = superpoderMapper;
        }

        public async Task<ServiceResponse<List<HeroiResponse>>> GetAllAAssync()
        {
            var serviceResponse = new ServiceResponse<List<HeroiResponse>>();
            var herois = await _repository.GetAllAsync();
            serviceResponse.Data = _heroiMapper.MapToResponseList(herois);
            return serviceResponse;
        }

        public async Task<ServiceResponse<HeroiResponse>> GetByIdAsync(int id)
        {
            var serviceResponse = new ServiceResponse<HeroiResponse>();
            var heroi = await _repository.GetByIdAsync(id);
            
            if (heroi == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Super-herói com Id {id} não encontrado.";
                serviceResponse.StatusCode = 404;
                return serviceResponse;
            }

            serviceResponse.Data = _heroiMapper.MapToResponse(heroi);
            return serviceResponse;
        }

        public async Task<ServiceResponse<HeroiResponse>> CreateAsync(CreateHeroiRequest request)
        {
            var serviceResponse = new ServiceResponse<HeroiResponse>();

            if (request == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Para criar um heroi as informações dele não podem ser nulas";
                serviceResponse.StatusCode = 400;
                return serviceResponse;
            }

            if (await _repository.ExisteHeroiComNomeAsync(request.NomeHeroi))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Já existe um herói cadastrado com este nome de herói.";
                serviceResponse.StatusCode = 400;
                return serviceResponse;
            }

            var heroi = _heroiMapper.MapFromCreateRequest(request);
            
            if (heroi.DataNascimento.HasValue && heroi.DataNascimento.Value < new DateTime(1753, 1, 1))
            {
                heroi.DataNascimento = null;
            }

            if (request.SuperpoderesIds != null && request.SuperpoderesIds.Any())
            {
                heroi.HeroisSuperpoderes = new List<HeroisSuperpoderes>();
                foreach (var superpoderId in request.SuperpoderesIds)
                {
                    heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderes
                    {
                        SuperpoderId = superpoderId
                    });
                }
            }

            var criado = await _repository.CreateAsync(heroi);
            
            var result = await GetByIdAsync(criado.Id);
            serviceResponse.Data = result.Data;
            serviceResponse.StatusCode = 201;
            return serviceResponse;
        }

        public async Task<ServiceResponse<HeroiResponse>> UpdateAsync(int id, UpdateHeroiRequest request)
        {
            var serviceResponse = new ServiceResponse<HeroiResponse>();

            if (request == null)
            {
                 serviceResponse.Success = false;
                 serviceResponse.Message = "Request nulo.";
                 serviceResponse.StatusCode = 400;
                 return serviceResponse;
            }

            var heroi = await _repository.GetByIdAsync(id);
            if (heroi == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Herói não encontrado.";
                serviceResponse.StatusCode = 404;
                return serviceResponse;
            }

            if (await _repository.ExisteHeroiComNomeAsync(request.NomeHeroi, id))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Já existe outro herói cadastrado com este nome de herói.";
                serviceResponse.StatusCode = 400;
                return serviceResponse;
            }

            heroi.Nome = request.Nome;
            heroi.NomeHeroi = request.NomeHeroi;
            heroi.DataNascimento = request.DataNascimento;
            
            if (heroi.DataNascimento.HasValue && heroi.DataNascimento.Value < new DateTime(1753, 1, 1))
            {
                heroi.DataNascimento = null;
            }

            heroi.Altura = request.Altura;
            heroi.Peso = request.Peso;

            if (request.SuperpoderesIds != null)
            {
                if (heroi.HeroisSuperpoderes == null)
                    heroi.HeroisSuperpoderes = new List<HeroisSuperpoderes>();
                else
                    heroi.HeroisSuperpoderes.Clear();

                foreach (var superpoderId in request.SuperpoderesIds)
                {
                    heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderes
                    {
                        SuperpoderId = superpoderId
                    });
                }
            }

            await _repository.UpdateAsync(heroi);
            
            var result = await GetByIdAsync(id);
            serviceResponse.Data = result.Data;
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
             var serviceResponse = new ServiceResponse<bool>();
             var heroi = await _repository.GetByIdAsync(id);
             
             if (heroi == null)
             {
                 serviceResponse.Success = false;
                 serviceResponse.Message = "Herói não encontrado.";
                 serviceResponse.StatusCode = 404;
                 return serviceResponse;
             }

             await _repository.DeleteAsync(id);
             serviceResponse.Data = true;
             return serviceResponse;
        }


    }
}