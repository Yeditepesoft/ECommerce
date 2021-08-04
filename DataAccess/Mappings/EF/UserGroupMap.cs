using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings.EF
{
    public class UserGroupMap :IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("UserGroups");
            builder.HasIndex(x => x.Description);

            builder.HasData(new List<UserGroup>
            {
                new ()
                {
                    Id = 1,
                    Description = "Son Kullanıcı",
                    CreatedUser = "Migration"
                },
                new ()
                {
                    Id = 2,
                    Description = "Administrator",
                    CreatedUser = "Migration"
                }
            });
        }
    }
}