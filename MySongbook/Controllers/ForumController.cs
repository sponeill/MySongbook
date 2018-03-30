using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySongbook.DAL;
using MySongbook.Models;

namespace MySongbook.Controllers
{
    public class ForumController : Controller
    {
		// GET: Forum

		public ActionResult Forum(ForumDAL dal)
		{
			var posts = dal.GetForumPosts();

			return View("Forum", posts);
		}

		[HttpGet]
		public ActionResult NewPost()
		{
			return View("NewPost");
		}

		[HttpPost]
		public ActionResult NewPost(ForumPostModel post, ForumDAL dal)
		{
			dal.AddNewPost(post);

			return RedirectToAction("Forum");
		}
	}
}