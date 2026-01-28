using ApplicationService.Dtos.Resposes.Superpoder;
using ApplicationService.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class SuperpoderService : ISuperpoderService
    {
        private readonly ISuperpoderesRepository _repository;
        public SuperpoderService(ISuperpoderesRepository superpoderesRepository)
        {
            _repository = superpoderesRepository;
        }

        public async Task<List<SuperpoderResponse>> GetAllAsync()
        {
            var superpoderes = await _repository.GetAllAsync();
            return superpoderes.Select(s => new SuperpoderResponse
            {
                Id = s.Id,
                Superpoder = s.Superpoder,
                Descricao = s.Descricao
            }).ToList();
        }
    }
}
