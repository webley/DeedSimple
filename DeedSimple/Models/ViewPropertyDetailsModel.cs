using System.Collections.Generic;
using DeedSimple.Domain;

namespace DeedSimple.Models
{
    public class ViewPropertyDetailsModel
    {
        public ViewPropertyDetailsModel(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
        public PropertyType Type { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public decimal AskingPrice { get; set; }

        public string Road { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public virtual List<long> ImageIds { get; set; }
    }
}