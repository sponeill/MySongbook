using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySongbook.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace MySongbook.DAL
{
	public class ForumDAL
	{
		string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		public List<ForumPostModel> GetForumPosts()
		{
			List<ForumPostModel> posts = new List<ForumPostModel>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM forum;", conn);
					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						ForumPostModel post = new ForumPostModel();
						post.display_name = Convert.ToString(reader["display_name"]);
						post.forum_post = Convert.ToString(reader["forum_post"]);
						posts.Add(post);
						
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex);
			}

			return posts;
		}

	}
}