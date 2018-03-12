using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySongbook.DAL;

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