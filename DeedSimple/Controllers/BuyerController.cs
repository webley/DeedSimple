using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeedSimple.Domain;
using DeedSimple.Helpers;
using DeedSimple.Processor;
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
            var pagedListModel = properties.Select(p => p.MapToViewPropertyOverviewModel()).ToPagedList(pageNumber, pageSize);
            return View(pagedListModel);
        }

        [AllowAnonymous]
        public ActionResult View(long id)
        {
            var property = _propertyProcessor.GetProperty(id);
            return View(property.MapToViewPropertyDetailsModel());
        }

        public ActionResult PlaceOffer()
        {
            throw new NotImplementedException();
        }
    }
}