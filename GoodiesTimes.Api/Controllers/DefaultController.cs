using System;
using System.Web;
using System.Web.Mvc;

namespace GoodiesTimes.Api.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
