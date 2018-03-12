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
				Console.WriteLine(ex);
			}

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