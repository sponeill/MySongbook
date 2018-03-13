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

		public ActionResult Success()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SubmitSong(Song song)
		{
			SongBookDAL dal = new SongBookDAL();

			dal.InputSongs(song);

			return RedirectToAction("Success");
		}

		public ActionResult FindSong()
		{
			return View();
		}

		public ActionResult SearchResult(SongSearchModel search)
		{
			SongBookDAL dal = new SongBookDAL();

			var songs = dal.SearchSongs(search.Title, search.Composer, search.Lyricist, search.Source, search.Genre, search.Gender, search.VoicePart);

			return View("SearchResult", songs);
		}

		public ActionResult DisplayAllSongs(SongBookDAL dal)
		{
			var songs = dal.ReturnAllSongs();

			return View("DisplayAllSongs", songs);
		}


		public ActionResult UpdateEntry(int databaseId)
		{
			SongBookDAL dal = new SongBookDAL();

			Song song = dal.IdSearch(databaseId);

			return View("UpdateEntry", song);
		}

		[HttpPost]
		public ActionResult UpdateEntry(Song song)
		{
			SongBookDAL dal = new SongBookDAL();

			dal.UpdateSong(song);

			return RedirectToAction("Success");
		}
		
	}
}