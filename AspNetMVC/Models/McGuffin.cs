using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMVC.Models
{
	public class McGuffin
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }

		#region Generation
		private static int _id = 0;
		private static Random _rnd = new Random();
		private static string[] _names = new[]
		{
			"Ingeborg Old",
			"Derrick Simard",
			"Teresia Trussell",
			"Randi Marez",
			"Mi Mowrey",
			"Raylene Weymouth",
			"Philomena Evenson",
			"Providencia Swihart",
			"Lupita Edgin",
			"Leida Zerangue",
			"Ryann Perino",
			"Alejandra Jenks",
			"Octavia Steppe",
			"Tiesha Milian",
			"Ivy Billingsly",
			"Misti Brendel",
			"Julene Willey",
			"Dwana Mosbey",
			"Santa Swarey",
			"Lara Borgeson"
		};

		public static McGuffin Create()
		{
			return new McGuffin()
			{
				Id = ++_id,
				Name = _names[_rnd.Next(0, _names.Length - 1)],
				ImageUrl = $"https://picsum.photos/100/100/?image=" + _rnd.Next(1, 500)
			};
		}
		#endregion
	}
}