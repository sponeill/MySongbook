using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySongbook.DAL;
using MySongbook.Models;

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

		[HttpPost]
		public ActionResult SubmitSong(Song song)
		{
			return RedirectToAction("Success");
		}

		public ActionResult FindSong()
		{
			return View();
		}

		public ActionResult DisplayAllSongs(SongBookDAL dal)
		{
			var songs = dal.ReturnAllSongs();

			return View("DisplayAllSongs", songs);
		}
	}
}