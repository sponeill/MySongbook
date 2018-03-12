using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySongbook.Models
{
	public class Song
	{
		public string Title { get; set; }
		public string Composer { get; set; }
		public string Lyricist { get; set; }
		public string Source { get; set; }
		public string Genre { get; set; }
		public string Gender { get; set; }
		public string VoicePart { get; set; }
		public int DatabaseId { get; set; }
	}
}