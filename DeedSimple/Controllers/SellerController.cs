using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DeedSimple.Helpers;
using DeedSimple.Models.Seller;
using DeedSimple.Models.User;
using DeedSimple.Processor;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DeedSimple.Controllers
{
    public class SellerController : Controller
    {
        private readonly PropertyProcessor _propertyProcessor;
        private ApplicationUserManager _userManager;

        public SellerController(PropertyProcessor propertyProcessor)
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
            var model = new SellerUserModel { Name = user.UserName, Properties = properties };
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

        public async Task<ActionResult> Edit(int propertyId)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (!_propertyProcessor.PropertyCanBeEditedByUser(propertyId, user.Id))
                throw new Exception("You can't edit other people's properties.");

            var property = _propertyProcessor.GetProperty(propertyId);

            var model = property.MapToEditPropertyModel();
            return View(model);
        }
    }
}