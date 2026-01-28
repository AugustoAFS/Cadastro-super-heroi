using ApplicationService.Dtos.Requests.Heroi;
using ApplicationService.Dtos.Resposes.Heroi;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.Interfaces
{
    public interface IHeroiService
    {
        Task<List<HeroiResponse>> GetAllAAssync();
        Task<HeroiResponse> GetByIdAsync(int id);
        Task<HeroiResponse> CreateAsync(CreateHeroiRequest request);
        Task<HeroiResponse> UpdateAsync(int id, UpdateHeroiRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
