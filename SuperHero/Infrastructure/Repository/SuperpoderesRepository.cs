using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class SuperpoderesRepository : BaseRepository<Superpoderes>, ISuperpoderesRepository
    {
        public SuperpoderesRepository(SuperHeroDbContext context) : base(context)
        {}
    }
}
