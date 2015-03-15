using System.ComponentModel.DataAnnotations.Schema;

namespace DeedSimple.Domain
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public string ContentType { get; set; }

        public static Image GetDefault()
        {
            return new Image
            {
                Id = 0,
                FileName = "default",
                Caption = "No Images",
                ContentType = "image/jpeg"
            };
        }
    }
}
