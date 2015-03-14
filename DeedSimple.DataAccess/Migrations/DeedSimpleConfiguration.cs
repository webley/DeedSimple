using System.Data.Entity.Migrations;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess.Migrations
{
    public sealed class DeedSimpleConfiguration : DbMigrationsConfiguration<DeedSimpleContext>
    {
        public DeedSimpleConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DeedSimpleContext context)
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

            context.Images.AddOrUpdate(new Image{Caption = "No Image Added", FileName = "default", Id = 1});
        }
    }
}
