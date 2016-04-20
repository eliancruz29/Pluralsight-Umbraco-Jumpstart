using System;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Web;

namespace Pluralsight_Umbraco_Jumpstart
{
    public class CustomUmbracoApplication : UmbracoApplication
    {
        protected override IBootManager GetBootManager()
        {
            return new CustomWebBootManager(this);
        }
    }

    class CustomWebBootManager : WebBootManager
    {
        public CustomWebBootManager(UmbracoApplicationBase application) : base(application) { }

        public override IBootManager Complete(Action<ApplicationContext> afterComplete)
        {
            RouteTable.Routes.MapRoute(
                "HomePage",
                "Home/Index",
                new {controller = "Home", action = "Index"}
            );
            return base.Complete(afterComplete);
        }
    }
}