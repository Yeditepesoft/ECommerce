using Core.Helpers;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings.EF
{
    public class UserMap :IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => new{x.FirstName,x.LastName});
            builder.HasIndex(x => x.Gsm);

            HashingHelper.CreatePasswordHash("1234",out var passwordHash,out var passwordSalt);
            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Abdi",
                LastName = "KURT",
                Email = "abdikurt@gmail.com",
                Gsm = "5423269293",
                IsSuperVisor = true,
                UserGroupId = 2,
                GenderId = 2,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedUser = "Migration"
            });
        }
    }
}