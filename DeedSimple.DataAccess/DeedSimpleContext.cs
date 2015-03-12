using System.Data.Entity;
using DeedSimple.DataAccess.Migrations;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public class DeedSimpleContext : DbContext
    {
        //public DeedSimpleContext()
        //{
        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DeedSimpleContext>());
        //}

        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<BuyerUser> BuyerUsers { get; set; }
        public DbSet<SellerUser> SellerUsers { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
