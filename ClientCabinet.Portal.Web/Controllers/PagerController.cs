using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RC.SiteCore.Engine.Controllers
{
    public class PagerController : Controller
    {
        //
        // GET: /Pager/

        public ActionResult Index(int currentPage,int itemsCount, int rowsCount, string action, string controller)
        {
	        ViewBag.PagerCount = Convert.ToInt32(itemsCount/rowsCount);
	        ViewBag.Action = action;
	        ViewBag.Controller = controller;
            return PartialView();
        }

		public ActionResult AjaxIndex(int currentPage, int itemsCount, int rowsCount, string action, string controller, string updateTargetId)
		{
			ViewBag.PagerCount = Convert.ToInt32(itemsCount / rowsCount);
			ViewBag.Action = action;
			ViewBag.Controller = controller;
			ViewBag.UpdateTargetId = updateTargetId;
			ViewBag.CurrentPage = currentPage;
			RedirectToAction(action, controller);
			return PartialView();
		}

		/*[HttpPost]
		public ActionResult Index(int currentPage)
		{
			ViewBag.CurrentPage = currentPage;
			RedirectToAction(action, controller);
			return PartialView();
		}*/
    }
}
