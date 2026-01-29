using ApplicationService.Common;
using ApplicationService.Dtos.Resposes.Superpoder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.Interfaces
{
    public interface ISuperpoderService
    {
        Task<ServiceResponse<List<SuperpoderResponse>>> GetAllAsync();
    }
}
