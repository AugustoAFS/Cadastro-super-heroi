using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class HeroisRepository : BaseRepository<Herois>, IHeroisRepository
    {
        public HeroisRepository(SuperHeroDbContext context) : base(context)
        {}
    }
}
