using AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC.Controllers
{
    public class ItemsController : Controller
    {
		private static IEnumerable<McGuffin> _items;

		static ItemsController()
		{
			_items = Enumerable.Range(0, 100).Select(x => McGuffin.Create()).ToArray();
		}

		// GET: Items
		public ActionResult Index(string criteria = null)
        {
			var items = _items.Where(i => criteria == null || i.Name.StartsWith(criteria, StringComparison.OrdinalIgnoreCase));
			items = items.Take(10);

			if (Request.IsAjaxRequest())
			{
				return PartialView("_Items", items);
			}

            return View(items);
        }
    }
}