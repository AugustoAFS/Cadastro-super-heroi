using ApplicationService.Common;
using ApplicationService.Dtos.Resposes.Superpoder;
using ApplicationService.Interfaces;
using ApplicationService.Mappings;
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
        private readonly SuperpoderMapper _mapper;

        public SuperpoderService(ISuperpoderesRepository superpoderesRepository, SuperpoderMapper mapper)
        {
            _repository = superpoderesRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<SuperpoderResponse>>> GetAllAsync()
        {
            var serviceResponse = new ServiceResponse<List<SuperpoderResponse>>();
            var superpoderes = await _repository.GetAllAsync();
            serviceResponse.Data = _mapper.MapToResponseList(superpoderes);
            return serviceResponse;
        }
    }
}
