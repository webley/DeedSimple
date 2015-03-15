using DeedSimple.ViewModel.Property;

namespace DeedSimple.Converters
{
    public static class PropertyConverterExtensions
    {
        public static EditPropertyModel ToEditPropertyModel(this ViewPropertyDetailsModel viewModel)
        {
            var editModel = new EditPropertyModel(viewModel.Id)
            {
                AskingPrice = viewModel.AskingPrice,
                TagLine = viewModel.TagLine,
                County = viewModel.County,
                Description = viewModel.Description,
                PostCode = viewModel.PostCode,
                Road = viewModel.Road,
                Town = viewModel.Town,
                Type = viewModel.Type
            };

            return editModel;
        }
    }
}