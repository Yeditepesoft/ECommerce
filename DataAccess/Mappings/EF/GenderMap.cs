using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings.EF
{
    public class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Genders");
            builder.HasIndex(x => x.Description);

            builder.HasData(new List<Gender>()
            {
                new()
                {
                    Id = 1,
                    Description = "Kadın",
                    CreatedUser = "Migration"
                },
                new()
                {
                    Id = 2,
                    Description = "Erkek",
                    CreatedUser = "Migration"
                },
                new()
                {
                    Id = 3,
                    Description = "Belirtilmedi",
                    CreatedUser = "Migration"
                }
            });
        }
    }
}