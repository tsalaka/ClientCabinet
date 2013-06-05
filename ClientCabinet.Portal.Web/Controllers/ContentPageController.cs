using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Content.Core.BLL;
using RGSiteCore.SM.NodeTypes;

namespace RC.SiteCore.Engine.Controllers
{
    public class ContentPageController : Controller
    {
        //
        // GET: /ContentPage/

        public ActionResult Index()
        {
	        var currentNode = RCSiteCore.RC.SiteMapFactory.CurrentNode;
			if(currentNode is IPageNode)
			{
				var html = HtmlContentManager.GetHtmlContent(
					Server.MapPath(String.Format("~/SharedFiles/Schema/{0}.xml", ((IPageNode) currentNode).PageGuid)));
				ViewBag.Source = html.Source;
			}
	        
            return View();
        }

		public void Redirect()
		{
			var currentNode = RCSiteCore.RC.SiteMapFactory.CurrentNode;
			if (currentNode is IRedirectNode)
			{
				if (currentNode != null && !String.IsNullOrEmpty(currentNode.Href))
				{
					Response.Redirect(currentNode.Href);
				}
				
			}

			Redirect("/");
		}

    }
}
