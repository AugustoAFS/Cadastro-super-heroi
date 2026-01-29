using ApplicationService.Common;
using ApplicationService.Dtos.Requests.Heroi;
using ApplicationService.Dtos.Resposes.Heroi;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.Interfaces
{
    public interface IHeroiService
    {
        Task<ServiceResponse<List<HeroiResponse>>> GetAllAAssync();
        Task<ServiceResponse<HeroiResponse>> GetByIdAsync(int id);
        Task<ServiceResponse<HeroiResponse>> CreateAsync(CreateHeroiRequest request);
        Task<ServiceResponse<HeroiResponse>> UpdateAsync(int id, UpdateHeroiRequest request);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
