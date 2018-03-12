using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySongbook.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Forum()
		{
			return View();
		}

		public ActionResult SubmitSong()
		{
			return View();
		}

		public ActionResult FindSong()
		{
			return View();
		}

		public ActionResult DisplayAllSongs()
		{
			var songs = new List<MySongbook.Models.Song>(); //BUILD DAL

			return View("DisplayAllSongs", songs);
		}
	}
}