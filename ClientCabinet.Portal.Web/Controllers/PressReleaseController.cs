using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Content.Core.BLL;

namespace RC.SiteCore.Engine.Controllers.Shared
{
	public class PressReleaseController : Controller
	{
		//
		// GET: /PressRelease/
		private string filesrc = "~/SharedFiles/Schema/8ccbacaa-5ed3-4f65-9ae3-b5f2d7311175.xml";
		private int rowNumber = 15;

		public ActionResult Index()
		{
			const int pageNumber = 1;
			ViewBag.RowsCount = 5;
			int totalNumber = 0;
			var pubList = PublicationManager.GetPublicationListByPeriod(Server.MapPath(filesrc), 2012, 0, pageNumber,
			                                                            ViewBag.RowsCount, out totalNumber);
			ViewBag.CurrentPage = pageNumber;
			ViewBag.ItemsCount = totalNumber;

			return View(pubList);
		}

		[HttpPost]
		public ActionResult Index(int pageNumber)
		{
			ViewBag.RowsCount = 5;
			int totalNumber = 0;
			var pubList = PublicationManager.GetPublicationListByPeriod(Server.MapPath(filesrc), 2012, 0, pageNumber,
			                                                            ViewBag.RowsCount, out totalNumber);
			ViewBag.CurrentPage = pageNumber;
			ViewBag.ItemsCount = totalNumber;

			return View(pubList);
		}

		public ActionResult AjaxIndex(int? pageNumber)
		{
			var page = pageNumber??1;
			ViewBag.RowsCount = 5;
			int totalNumber = 0;
			var pubList = PublicationManager.GetPublicationListByPeriod(Server.MapPath(filesrc), 2012, 0, page,
			                                                            ViewBag.RowsCount, out totalNumber);
			ViewBag.CurrentPage = page;
			ViewBag.ItemsCount = totalNumber;

			return View(pubList);
		}

		public PartialViewResult AjaxPage(int pageNumber)
		{
			ViewBag.RowsCount = 5;
			int totalNumber = 0;
			var pubList = PublicationManager.GetPublicationListByPeriod(Server.MapPath(filesrc), 2012, 0, pageNumber,
			                                                            ViewBag.RowsCount, out totalNumber);
			ViewBag.CurrentPage = pageNumber;
			ViewBag.ItemsCount = totalNumber;

			return PartialView("~/Views/PressRelease/AjaxIndex.cshtml", pubList);
		}

		public ActionResult BackToList(int page)
		{
			return RedirectToAction("AjaxIndex",new {pageNumber = page});
		}

		public ActionResult PublicationGet(int id, int page)
		{
			ViewBag.PageNumber = page;
			var pub = PublicationManager.GetPublicationById(Server.MapPath(filesrc), id);
			return View(pub);
		}

		public ActionResult Page(int pageNumber)
		{
			ViewBag.RowNumber = rowNumber;
			ViewBag.CurrentPage = pageNumber;
			int totalNumber = 0;
			var pubList = PublicationManager.GetPublicationListByPeriod(Server.MapPath(filesrc), 2012, 0, pageNumber, 15, out totalNumber);
			return View(pubList);
		}

    }
}
