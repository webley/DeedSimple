using System.Web.Mvc;

namespace DeedSimple.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Who or what is Deed Simple?";

            return View();
        }
    }
}