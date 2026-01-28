using Domain.Entities;
using Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class HeroisSuperpoderesConfiguration : BaseEntityConfiguration<HeroisSuperpoderes>
    {
        public override void Configure(EntityTypeBuilder<HeroisSuperpoderes> builder)
        {
            base.Configure(builder);

            builder.HasOne(hs => hs.Heroi)
                   .WithMany(h => h.HeroisSuperpoderes)
                   .HasForeignKey(hs => hs.HeroiId)
                   .IsRequired();

            builder.HasOne(hs => hs.Superpoder)
                   .WithMany(s => s.HeroisSuperpoderes)
                   .HasForeignKey(hs => hs.SuperpoderId)
                   .IsRequired();
        }
    }
}