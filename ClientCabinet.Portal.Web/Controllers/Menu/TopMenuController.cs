using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCSiteCore.Menu;
using RGSiteCore;

namespace RC.SiteCore.Engine.Controllers.Menu
{
	public class TopMenuController : Controller
	{
		private readonly IMenuRepository menuRepository;
		//private string fileSrc = @"d:\Projects\SVN\Education\RC.SiteCore.Engine\SharedFiles\Schema\TopMenu.xml";

		public TopMenuController(IMenuRepository menuRepository)
		{
			this.menuRepository = menuRepository;
		
		}

		public ActionResult Index(string fileSrc)
		{
			menuRepository.UniqueID = fileSrc;
		
			var nodes = menuRepository.Children;
			return View("~/Views/Shared/Menu/TopMenu/Index.cshtml", nodes);
		}

	}
}
