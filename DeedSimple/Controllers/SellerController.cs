using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DeedSimple.Domain;
using DeedSimple.Helpers;
using DeedSimple.Models;
using DeedSimple.Models.Seller;
using DeedSimple.Models.User;
using DeedSimple.Processor;
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
            var model = new SellerUserModel { Name = user.UserName, Properties = properties ?? new List<Property>() };
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

            var propertyId = _propertyProcessor.AddPropertyForUser(user.Id, model.MapToProperty());
            return RedirectToAction("Edit", new RouteValueDictionary { { "propertyId", propertyId } });
        }

        public async Task<ActionResult> Edit(long propertyId)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (!_propertyProcessor.PropertyCanBeEditedByUser(propertyId, user.Id))
                throw new Exception("You can't edit other people's properties.");

            var property = _propertyProcessor.GetProperty(propertyId);

            var model = property.MapToEditPropertyModel();
            return View(model);
        }

        public ActionResult Delete(long propertyId)
        {
            return View(new ConfirmDeletePropertyModel{PropertyId = propertyId});
        }

        public ActionResult Accept(long offerId)
        {
            var offer = _propertyProcessor.GetOffer(offerId);
            return View(new ConfirmAcceptOfferModel { OfferId = offer.Id, OfferPrice = offer.Price});
        }

        public ActionResult ConfirmAccept(long offerId)
        {
            var userId = User.Identity.GetUserId();
            var offer = _propertyProcessor.GetOffer(offerId);
            if (_propertyProcessor.PropertyCanBeEditedByUser(offer.PropertyId, userId))
            {
                _propertyProcessor.RejectOffer(offerId);
            }

            return RedirectToAction("Offers");
        }

        public ActionResult Reject(long offerId)
        {
            var offer = _propertyProcessor.GetOffer(offerId);
            return View(new ConfirmRejectOfferModel { OfferId = offer.Id, OfferPrice = offer.Price });
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
            var model = new List<ViewBuyerOfferModel>();
            foreach (var offer in offers)
            {
                var property = _propertyProcessor.GetProperty(offer.PropertyId);
                model.Add(new ViewBuyerOfferModel
                {
                    OfferId = offer.Id,
                    PropertyId = offer.PropertyId,
                    OfferPrice = offer.Price,
                    State = offer.State,
                    TagLine = property.TagLine,
                    MainImage = property.Images.FirstOrDefault()
                });
            }

            return View(model);
        }
    }
}