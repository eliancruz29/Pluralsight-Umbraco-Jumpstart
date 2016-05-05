using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Logging;

namespace ElianPrueba.EventHandler
{
    public class Example : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //subscribe to events
            Umbraco.Core.Services.ContentService.Published += ContentService_Published;
            Umbraco.Core.Services.ContentService.Publishing += ContentService_Publishing;
        }

        private void ContentService_Publishing(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            foreach(var item in e.PublishedEntities)
            {
                LogHelper.Info(typeof(Example), "Hello" + item.Name + "is about to be published");
            }
        }

        private void ContentService_Published(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            //custom code
            LogHelper.Info(typeof(Example), "Hello world this is my custom code");
        }
    }
}