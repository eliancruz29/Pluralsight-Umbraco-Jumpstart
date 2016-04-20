using System.Threading;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Pluralsight_Umbraco_Jumpstart.Controllers
{
    public class HomeController : Controller
    {
        private readonly UmbracoContext umbracoContext;

        public HomeController()
        {
            umbracoContext = UmbracoContext.Current;
        }
        // GET: Home
        public ActionResult Index()
        {
            var rootNode = umbracoContext.ContentCache.GetById(1063);
            var siteTitle = rootNode.GetPropertyValue<string>("siteTitle");

            ViewBag.SiteTitle = siteTitle;

            var model = new RenderModel(rootNode, Thread.CurrentThread.CurrentCulture);

            return View(model);
        }
    }
}