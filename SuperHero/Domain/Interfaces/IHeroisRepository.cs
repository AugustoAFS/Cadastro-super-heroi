using Domain.Entities;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IHeroisRepository : IBaseRepository<Herois>
    {
        Task<bool> ExisteHeroiComNomeAsync(string nomeHeroi, int? ignorarId = null);
    }
}
