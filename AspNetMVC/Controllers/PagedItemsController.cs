using AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace AspNetMVC.Controllers
{
	/// <summary>
	/// Based on OdeToFood demo on pluralisight
	/// 
	/// - Custom form submit
	/// - paged results
	/// - Autocomplete
	/// </summary>
    public class PagedItemsController : Controller
    {
		private static IEnumerable<McGuffin> _items;

		static PagedItemsController()
		{
			_items = Enumerable.Range(0, 10000).Select(x => McGuffin.Create()).ToArray();
		}

		// GET: PagedItems
		public ActionResult Index(string criteria = null, int page = 1)
		{
			var items = _items
				.Where(i => criteria == null || i.Name.StartsWith(criteria, StringComparison.OrdinalIgnoreCase))
				.ToPagedList(page, 10);

			if (Request.IsAjaxRequest())
			{
				return PartialView("_Items", items);
			}

			return View(items);
		}

		public ActionResult Autocomplete(string term)
		{
			var items = _items
				.Where(i => term == null || i.Name.StartsWith(term, StringComparison.OrdinalIgnoreCase))
				.Take(10)
				.Select(i => new
				{
					label = i.Name
				});

			return Json(items, JsonRequestBehavior.AllowGet);
		}
	}
}