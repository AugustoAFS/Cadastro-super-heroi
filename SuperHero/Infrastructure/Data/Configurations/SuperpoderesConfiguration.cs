using Domain.Entities;
using Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations
{
    public class SuperpoderesConfiguration : BaseEntityConfiguration<Superpoderes>
    {
        public override void Configure(EntityTypeBuilder<Superpoderes> builder)
        {
            base.Configure(builder);

            builder.Property(h => h.Superpoder)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(h => h.Descricao)
                   .HasMaxLength(250);

        }
    }
}
