using System.Web;
using System.Web.Mvc;
using DeedSimple.BLL.Interface;
using DeedSimple.ViewModel.Enum;
using DeedSimple.ViewModel.Offer;
using DeedSimple.ViewModel.Property;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;

namespace DeedSimple.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IPropertyProcessor _propertyProcessor;
        private ApplicationUserManager _userManager;

        public BuyerController(IPropertyProcessor propertyProcessor)
        {
            _propertyProcessor = propertyProcessor;
        }

        private ApplicationUserManager UserManager
        {
            get 
            {
                return _userManager ?? (_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }
        }

        // GET: Buyer
        [AllowAnonymous]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.PriceSortParm = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            PropertySortOrder propertySortOrder;
            switch (sortOrder)
            {
                case "name_desc":
                    propertySortOrder = PropertySortOrder.TagLineDescending;
                    break;
                case "price_asc":
                    propertySortOrder = PropertySortOrder.AskingPriceAscending;
                    break;
                case "price_desc":
                    propertySortOrder = PropertySortOrder.AskingPriceDescending;
                    break;
                default:
                    propertySortOrder = PropertySortOrder.TagLineAscending;
                    break;
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var properties = _propertyProcessor.GetPropertiesFiltered(propertySortOrder, searchString);
            var pagedListModel = properties.ToPagedList(pageNumber, pageSize);
            return View(pagedListModel);
        }

        [AllowAnonymous]
        public ActionResult View(long id)
        {
            var property = _propertyProcessor.GetProperty(id);
            return View(property);
        }

        [HttpPost]
        public ActionResult PlaceOffer(ViewPropertyDetailsModel model)
        {
            var offer = new AddOfferModel
            {
                PropertyId = model.Id,
                OfferPrice = model.OfferPrice,
                BuyerUserId = User.Identity.GetUserId()
            };

            var offerId = _propertyProcessor.PlaceOfferForProperty(offer);
            return RedirectToAction("Offers");
        }

        public ActionResult Offers()
        {
            var offers = _propertyProcessor.GetOffersForBuyer(User.Identity.GetUserId());

            //var model = new List<ViewOfferModel>();
            //foreach (var offer in offers)
            //{
            //    var property = _propertyProcessor.GetProperty(offer.PropertyId);
            //    model.Add(new ViewOfferModel
            //    {
            //        OfferId = offer.OfferId,
            //        PropertyId = offer.PropertyId,
            //        OfferPrice = offer.OfferPrice,
            //        State = offer.State,
            //        TagLine = property.TagLine,
            //        MainImage = property.Images.FirstOrDefault()
            //    });
            //}

            return View(offers);
        }

        public ActionResult Cancel(long offerId)
        {
            _propertyProcessor.CancelOffer(offerId);
            return RedirectToAction("Offers");
        }
    }
}