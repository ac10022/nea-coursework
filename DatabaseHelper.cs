using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace nea_prototype_full
{
    internal class DatabaseHelper
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lucam\Documents\Visual Studio 2022\All Projects\nea ui testing\Database.mdf"";Integrated Security=True";

        public string GetSaltFromEmail(string email, _UserType userType)
        {
            string salt = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string entity = (userType == _UserType.Teacher) ? "Teachers" : "Students";
                string query = $"SELECT Salt FROM {entity} WHERE Email = @EmailParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter emailParameter = new SqlParameter("@EmailParameter", email);
                    cmd.Parameters.Add(emailParameter);

                    conn.Open();
                    try
                    {
                        salt = (string)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        throw new Exception("Couldn't find a user by this email in the database.");
                    }
                    conn.Close();
                }
            }
            if (salt == null) throw new Exception("Couldn't find a user by this email in the database.");
            return salt;
        }

        public User GetUserFromSaltAndPassword(string salt, string hashedPassword, _UserType userType)
        {
            User result = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string entity = (userType == _UserType.Teacher) ? "Teachers" : "Students";
                string query = $"SELECT {entity.Substring(0, 7)}Id, FirstName, Surname, Email FROM {entity} WHERE Salt = @SaltParameter AND Password = @PasswordParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter saltParameter = new SqlParameter("@SaltParameter", salt);
                    SqlParameter passwordParameter = new SqlParameter("@PasswordParameter", hashedPassword);

                    cmd.Parameters.AddRange(new SqlParameter[] {saltParameter, passwordParameter});

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], userType);
                        }
                    }
                    conn.Close();
                }
            }
            if (result == null) throw new Exception($"Could not find a User by the given credentials");
            // update last login date of this user which is logging in now
            UpdateLastLogin(result);
            return result;
        }

        private void UpdateLastLogin(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string entity = (user.UserType == _UserType.Teacher) ? "Teachers" : "Students";
                string query = $"UPDATE Teachers SET LastLogin = CAST(GETDATE() AS date) WHERE {entity.Substring(0, 7)}Id = @IdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter idParameter = new SqlParameter("@IdParameter", user.Id);
                    cmd.Parameters.Add(idParameter);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        
        public Subject GetSubjectById(int id)
        {
            Subject subject = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Subjects WHERE SubjectId = @IdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter idParameter = new SqlParameter("@IdParameter", id);
                    cmd.Parameters.Add(idParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            subject = new Subject((int)reader[0], (string)reader[1]);
                        }
                    }
                    conn.Close();
                }
            }
            if (subject == null) throw new Exception($"Could not find a Subject with SubjectId: {id}");
            return subject;
        }

        public List<Topic> GetAllTopics()
        {
            List<Topic> list = new List<Topic>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TopicId, TopicName, VideoLink, Subjects.SubjectId, Subjects.SubjectName FROM Topics INNER JOIN Subjects ON Topics.SubjectId = Subjects.SubjectId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Topic((int)reader[0], (string)reader[1], (string)reader[2], new Subject((int)reader[3], (string)reader[4])));
                        }
                    }

                    conn.Close();
                }
            }
            if (list.Count == 0) throw new Exception($"No topics found in database.");
            return list;
        }
    }
}
