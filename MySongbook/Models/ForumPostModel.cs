using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySongbook.Models
{
	public class ForumPostModel
	{
		public string display_name { get; set; }
		public string forum_post { get; set; }
		public DateTime post_date { get; set; } = DateTime.Now; // Allows the date to be set from Database but will be set to current by default
			
	}
}