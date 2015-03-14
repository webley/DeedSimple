using System.Data.Entity;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public class DeedSimpleDatabaseInitializer : DropCreateDatabaseIfModelChanges<DeedSimpleContext>
    {
        protected override void Seed(DeedSimpleContext context)
        {
            context.Images.Add(new Image { Caption = "No Image Added", FileName = "default.jpg", ContentType = "image/jpeg"});
            context.SaveChanges();
        }
    }
}
