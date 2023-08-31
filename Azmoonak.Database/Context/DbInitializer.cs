using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;
using Azmoonak.Database.Classes;

namespace Azmoonak.Database.Context
{
    internal class DbInitializer
    {
        private ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }


        //دوتا رول و یک یوزر میخواهیم که از قبل ساخته شود
        internal async void Seed()
        {
            Role adminRole = new Role()
            {
                Id = Guid.NewGuid(),
                RoleName = "admin",
                RoleTitle = "مدیر"
            };
            _modelBuilder.Entity<Role>().HasData(adminRole);


            Role userRole = new Role()
            {
                Id = Guid.NewGuid(),
                RoleName = "user",
                RoleTitle = "کاربر"
            };
            _modelBuilder.Entity<Role>().HasData(userRole);



            User adminUser = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = adminRole.Id,
                FName="میلاد",
                LName="حیدرپور",
                Mobile = "09030826556",
                Password = await new Security().HashPassword(await new Security().HashPassword("27736124")),
                IsActive = true,
            };
            _modelBuilder.Entity<User>().HasData(adminUser);

            // Create Groups and get migration... 
        }
    }
}