using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using MySongbook.Models;


namespace MySongbook.DAL
{
	public class SongBookDAL
	{
		string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		public List<Song> ReturnAllSongs()
		{
			List<Song> allSongs = new List<Song>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM song ORDER BY title;", conn);
					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						Song song = MapRowToSong(reader);
						allSongs.Add(song);
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex);
			}

			return allSongs;
		}

		public void InputSongs(Song song)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("INSERT INTO song(title, composer, lyricist, source_material, genre, gender, voice_part) " +
						"VALUES(@Title, @Composer, @Lyricist, @Source, @Genre, @Gender, @VoicePart);", conn);
					cmd.Parameters.AddWithValue("@Title", song.Title);
					cmd.Parameters.AddWithValue("@Composer", song.Composer);
					cmd.Parameters.AddWithValue("@Lyricist", song.Lyricist);
					cmd.Parameters.AddWithValue("@Source", song.Source);
					cmd.Parameters.AddWithValue("@Genre", song.Genre);
					cmd.Parameters.AddWithValue("@Gender", song.Gender);
					cmd.Parameters.AddWithValue("@VoicePart", song.VoicePart);

					cmd.ExecuteNonQuery();
				}

			}
			catch(SqlException ex)
			{
				throw;
			}

		}

		public List<Song> SearchSongs(string title, string composer, string lyricist, string source, string genre, string gender, string voicepart)
		{
			List<Song> results = new List<Song>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = BuildSqlCommand(title, composer, lyricist, source, genre, gender, voicepart);
					cmd.Connection = conn;

					SqlDataReader reader = cmd.ExecuteReader();

					while(reader.Read())
					{
						Song song = MapRowToSong(reader);
						results.Add(song);
					}
				}
			}
			catch(SqlException ex)
			{
				throw;
			}

			return results;
		}

		private SqlCommand BuildSqlCommand(string title, string composer, string lyricist, string source, string genre, string gender, string voicepart)
		{
			SqlCommand cmd = new SqlCommand();
			string sql = "SELECT * FROM song WHERE ";
			string logicOperator = "";

			if (!String.IsNullOrEmpty(title))
			{
				sql += $"{logicOperator} title LIKE @title ";
				cmd.Parameters.AddWithValue("@title", "%" + title + "%");
				logicOperator = "AND";
			}

			if (!String.IsNullOrEmpty(composer))
			{
				sql += $"{logicOperator} composer LIKE @composer ";
				cmd.Parameters.AddWithValue("@composer", "%" + composer + "%");
				logicOperator = "AND";
			}

			if(!String.IsNullOrEmpty(lyricist))
			{
				sql += $"{logicOperator} lyricist LIKE @lyricist ";
				cmd.Parameters.AddWithValue("@lyricist", "%" + lyricist + "%");
				logicOperator = "AND";
			}

			if (!String.IsNullOrEmpty(source))
			{
				sql += $"{logicOperator} source_material LIKE @source ";
				cmd.Parameters.AddWithValue("@source", "%" + source + "%");
				logicOperator = "AND"; 
			}

			if (!String.IsNullOrEmpty(genre))
			{
				sql += $"{logicOperator} genre LIKE @genre ";
				cmd.Parameters.AddWithValue("@genre", genre);
				logicOperator = "AND";
			}

			if (!String.IsNullOrEmpty(gender))
			{
				sql += $"{logicOperator} gender LIKE @gender ";
				cmd.Parameters.AddWithValue("@gender", gender);
				logicOperator = "AND";
			}

			if (!String.IsNullOrEmpty(voicepart))
			{
				sql += $"{logicOperator} voice_part LIKE @voicepart ";
				cmd.Parameters.AddWithValue("@voicepart", voicepart);
			}

			sql += ";";

			cmd.CommandText = sql;

			return cmd;

		}

		private static Song MapRowToSong(SqlDataReader reader)
		{
			Song song = new Song();
			song.Title = Convert.ToString(reader["title"]);
			song.Composer = Convert.ToString(reader["composer"]);
			song.Lyricist = Convert.ToString(reader["lyricist"]);
			song.Source = Convert.ToString(reader["source_material"]);
			song.Gender = Convert.ToString(reader["gender"]);
			song.Genre = Convert.ToString(reader["genre"]);
			song.VoicePart = Convert.ToString(reader["voice_part"]);
			song.DatabaseId = Convert.ToInt32(reader["song_number"]);
			return song;
		}
	}
}