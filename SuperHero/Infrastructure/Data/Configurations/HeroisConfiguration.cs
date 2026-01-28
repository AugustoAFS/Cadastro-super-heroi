using Domain.Entities;
using Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configurations
{
    public class HeroisConfiguration : BaseEntityConfiguration<Herois>
    {
        public override void Configure(EntityTypeBuilder<Herois> builder)
        {
            base.Configure(builder);

            builder.Property(h => h.Nome)
                   .IsRequired()
                   .HasMaxLength(120);

            builder.Property(h => h.NomeHeroi)
                   .HasMaxLength(120);

            builder.Property(h => h.DataNascimento);

            builder.Property(h => h.Altura)
                   .HasColumnType("decimal(18, 2)")
                   .IsRequired();

            builder.Property(h => h.Peso)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

        }
    }
}
