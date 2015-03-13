namespace DeedSimple.Models
{
    public class ViewPropertyOverviewModel
    {
        public ViewPropertyOverviewModel(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public decimal AskingPrice { get; set; }
        public long MainImageId { get; set; }
    }
}