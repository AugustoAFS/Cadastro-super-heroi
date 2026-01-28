using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Base
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Created_At)
                .IsRequired();

            builder.Property(b => b.Flg_Inativo)
                .IsRequired();

            builder.Property(b => b.Deleted_At);
        }
    }
}