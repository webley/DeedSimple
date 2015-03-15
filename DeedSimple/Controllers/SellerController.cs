using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DeedSimple.BLL.Interface;
using DeedSimple.Converters;
using DeedSimple.Models;
using DeedSimple.ViewModel.Offer;
using DeedSimple.ViewModel.Property;
using DeedSimple.ViewModel.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DeedSimple.Controllers
{
    public class SellerController : Controller
    {
        private readonly IPropertyProcessor _propertyProcessor;
        private ApplicationUserManager _userManager;

        public SellerController(IPropertyProcessor propertyProcessor)
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

        // GET: Seller
        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var properties = _propertyProcessor.GetPropertiesForUser(user.Id);
            var model = new ViewSellerUserModel { Id = user.UserName, Properties = properties };
            return View(model);
        }

        // GET: Seller/Add
        public ActionResult Add()
        {
            var model = new AddPropertyModel();
            return View(model);
        }

        // POST: Seller/Add
        [HttpPost]
        public async Task<ActionResult> Add(AddPropertyModel model)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            var propertyId = _propertyProcessor.AddPropertyForUser(user.Id, model);
            return RedirectToAction("Edit", new { propertyId });
        }

        public async Task<ActionResult> Edit(long propertyId)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (!_propertyProcessor.PropertyCanBeEditedByUser(propertyId, user.Id))
                throw new Exception("You can't edit other people's properties.");

            var property = _propertyProcessor.GetProperty(propertyId);

            var model = property.ToEditPropertyModel();
            return View(model);
        }

        public ActionResult Delete(long propertyId)
        {
            return View(new ConfirmDeletePropertyModel{PropertyId = propertyId});
        }

        public ActionResult Accept(long offerId)
        {
            var offer = _propertyProcessor.GetOffer(offerId);
            return View(new ConfirmAcceptOfferModel { OfferId = offer.OfferId, OfferPrice = offer.OfferPrice});
        }

        public ActionResult ConfirmAccept(long offerId)
        {
            var userId = User.Identity.GetUserId();
            var offer = _propertyProcessor.GetOffer(offerId);
            if (_propertyProcessor.PropertyCanBeEditedByUser(offer.PropertyId, userId))
            {
                _propertyProcessor.AcceptOffer(offerId);
            }

            return RedirectToAction("Offers");
        }

        public ActionResult Reject(long offerId)
        {
            var offer = _propertyProcessor.GetOffer(offerId);
            return View(new ConfirmRejectOfferModel { OfferId = offer.OfferId, OfferPrice = offer.OfferPrice });
        }

        public ActionResult ConfirmReject(long offerId)
        {
            var userId = User.Identity.GetUserId();
            var offer = _propertyProcessor.GetOffer(offerId);
            if (_propertyProcessor.PropertyCanBeEditedByUser(offer.PropertyId, userId))
            {
                _propertyProcessor.RejectOffer(offerId);
            }

            return RedirectToAction("Offers");
        }

        public ActionResult Offers()
        {
            var offers = _propertyProcessor.GetOffersForSeller(User.Identity.GetUserId());
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
    }
}