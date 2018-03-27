using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySongbook.DAL;

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
	}
}