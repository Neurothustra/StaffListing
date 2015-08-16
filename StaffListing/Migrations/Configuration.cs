namespace Web.Peirce.FacultySearch.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Web.Peirce.FacultySearch.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.FacultyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Web.Peirce.FacultySearch.Models.FacultyContext";
        }

        protected override void Seed(Models.FacultyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Departments.AddOrUpdate(
                d => d.DepartmentId,
                new Department
                {
                    DepartmentName = "IT"
                });

            context.FacultyMembers.AddOrUpdate(
                f => f.FacultyId,
                new Faculty
                {
                    Prefix = "Mr",
                    FirstName = "John",
                    MiddleName = null,
                    LastName = "Smith",
                    Suffix = null,
                    JobTitle = "Engineer",
                    Email = null
                });
        }
    }
}
