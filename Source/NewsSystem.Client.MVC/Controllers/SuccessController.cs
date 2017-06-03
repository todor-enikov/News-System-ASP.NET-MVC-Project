using System.Web.Mvc;

namespace NewsSystem.Client.MVC.Controllers
{
    public class SuccessController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string submit)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CannotEdit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CannotEdit(string submit)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}