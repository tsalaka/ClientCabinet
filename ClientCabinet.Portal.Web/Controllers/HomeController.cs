using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Content.Core.BLL;

namespace RC.SiteCore.Engie.Controllers
{
	public class HomeController : Controller
	{
		private string filesrc = "~/SharedFiles/Schema/8ccbacaa-5ed3-4f65-9ae3-b5f2d7311175.xml";

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult PublicationGet(int id)
		{
			var pub = PublicationManager.GetPublicationById(Server.MapPath(filesrc), id);
			return View(pub);
		}


	}
}
