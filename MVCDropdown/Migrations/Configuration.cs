namespace MVCDropdown.Migrations
{
    using MVCDropdown.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCDropdown.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCDropdown.Infrastructure.ApplicationDbContext context)
        {
            var departmentEng = new Department() { DepartmentId = 1, Name = "Engineering" };
            var departmentHealth = new Department() { DepartmentId = 2, Name = "Health" };

            context.Departments.AddOrUpdate(
                departmentEng,
                departmentHealth
                );
            context.Programs.AddOrUpdate(
                new Program() { Id = 1, Name = "Software", Department = departmentEng },
                new Program() { Id = 2, Name = "Hardware", Department = departmentEng },
                new Program() { Id = 3, Name = "Radio Therapy", Department = departmentHealth }
                );
        }
    }
}
