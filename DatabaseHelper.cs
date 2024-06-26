using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

                    cmd.Parameters.AddRange(new SqlParameter[] { saltParameter, passwordParameter });

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
                string query = $"UPDATE {entity} SET LastLogin = CAST(GETDATE() AS date) WHERE {entity.Substring(0, 7)}Id = @IdParameter";

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

        public void CreateNewStudent(string firstName, string lastName, string email, string hashedPassword, string salt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Students VALUES (@FirstnameParameter, @LastnameParameter, @EmailParameter, @HashedPasswordParameter, CAST(GETDATE() AS DATE), @SaltParameter)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter fnParameter = new SqlParameter("@FirstnameParameter", firstName);
                    SqlParameter lnParameter = new SqlParameter("@LastnameParameter", lastName);
                    SqlParameter emailParameter = new SqlParameter("@EmailParameter", email);
                    SqlParameter hpParameter = new SqlParameter("@HashedPasswordParameter", hashedPassword);
                    SqlParameter saltParameter = new SqlParameter("@SaltParameter", salt);
                    cmd.Parameters.AddRange(new SqlParameter[] { fnParameter, lnParameter, emailParameter, hpParameter, saltParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CreateNewClass(string className)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Classes VALUES (@ClassnameParameter)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter cnParameter = new SqlParameter("@ClassnameParameter", className);
                    cmd.Parameters.Add(cnParameter);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Class> SearchForClasses(string className)
        {
            List<Class> list = new List<Class>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Classes WHERE ClassName LIKE '%' + @ClassnameParameter + '%'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter cnParameter = new SqlParameter("@ClassnameParameter", className);
                    cmd.Parameters.Add(cnParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Class((int)reader[0], (string)reader[1]));
                        }
                    }

                    conn.Close();
                }
            }
            if (list.Count == 0) throw new Exception($"No classes found in database.");
            return list;
        }

        public List<User> GetStudentsInClass(Class _class)
        {
            List<User> studentList = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Students.StudentId, FirstName, Surname, Email FROM ClassStudents INNER JOIN Students ON ClassStudents.StudentId = Students.StudentId WHERE ClassId = @ClassIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.Add(cidParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            studentList.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], _UserType.Student));
                        }
                    }

                    conn.Close();
                }
            }
            //if (studentList.Count == 0) throw new Exception($"No students found in this class.");
            return studentList;
        }

        public List<User> GetTeachersInClass(Class _class)
        {
            List<User> teacherList = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Teachers.TeacherId, FirstName, Surname, Email FROM ClassTeachers INNER JOIN Teachers ON ClassTeachers.TeacherId = Teachers.TeacherId WHERE ClassId = @ClassIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.Add(cidParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            teacherList.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], _UserType.Teacher));
                        }
                    }

                    conn.Close();
                }
            }
            //if (teacherList.Count == 0) throw new Exception($"No teachers found in this class.");
            return teacherList;
        }

        public List<User> GetStudentsByFirstName(string name)
        {
            List<User> studentList = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT StudentId, FirstName, Surname, Email FROM Students WHERE FirstName LIKE '%' + @FirstnameParameter + '%'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter fnParameter = new SqlParameter("@FirstnameParameter", name);
                    cmd.Parameters.Add(fnParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            studentList.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], _UserType.Student));
                        }
                    }

                    conn.Close();
                }
            }
            //if (studentList.Count == 0) throw new Exception($"No students with this name.");
            return studentList;
        }

        public List<User> GetTeachersByFirstName(string name)
        {
            List<User> teacherList = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TeacherId, FirstName, Surname, Email FROM Teachers WHERE FirstName LIKE '%' + @FirstnameParameter + '%'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter fnParameter = new SqlParameter("@FirstnameParameter", name);
                    cmd.Parameters.Add(fnParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            teacherList.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], _UserType.Teacher));
                        }
                    }

                    conn.Close();
                }
            }
            //if (teacherList.Count == 0) throw new Exception($"No teachers with this name.");
            return teacherList;
        }

        public List<User> GetStudentsMultimetric(string name, Class _class)
        {
            List<User> studentList = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Students.StudentId, FirstName, Surname, Email FROM Students INNER JOIN ClassStudents ON Students.StudentId = ClassStudents.StudentId WHERE FirstName LIKE '%' + @FirstnameParameter + '%' AND ClassId = @ClassIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter fnParameter = new SqlParameter("@FirstnameParameter", name);
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.AddRange(new SqlParameter[] { fnParameter, cidParameter });

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            studentList.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], _UserType.Student));
                        }
                    }

                    conn.Close();
                }
            }
            if (studentList.Count == 0) throw new Exception($"No students with these credentials.");
            return studentList;
        }

        public void AddStudentToClass(User student, Class _class)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ClassStudents VALUES (@StudentIdParameter, @ClassIdParameter)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter sidParameter = new SqlParameter("@StudentIdParameter", student.Id);
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.AddRange(new SqlParameter[] { sidParameter, cidParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void AddTeacherToClass(User teacher, Class _class)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ClassTeachers VALUES (@TeacherIdParameter, @ClassIdParameter)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter tidParameter = new SqlParameter("@TeacherIdParameter", teacher.Id);
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.AddRange(new SqlParameter[] { tidParameter, cidParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void RemoveStudentFromClass(User student, Class _class)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM ClassStudents WHERE ClassId = @ClassIdParameter AND StudentId = @StudentIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter sidParameter = new SqlParameter("@StudentIdParameter", student.Id);
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.AddRange(new SqlParameter[] { sidParameter, cidParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void RemoveTeacherFromClass(User teacher, Class _class)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM ClassTeachers WHERE ClassId = @ClassIdParameter AND TeacherId = @TeacherIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter tidParameter = new SqlParameter("@TeacherIdParameter", teacher.Id);
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.AddRange(new SqlParameter[] { tidParameter, cidParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Class> GetAllClasses()
        {
            List<Class> list = new List<Class>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Classes";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Class((int)reader[0], (string)reader[1]));
                        }
                    }

                    conn.Close();
                }
            }
            if (list.Count == 0) throw new Exception($"No classes found in database.");
            return list;
        }

        public List<User> GetAllTeachers()
        {
            List<User> teacherList = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TeacherId, FirstName, Surname, Email FROM Teachers";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            teacherList.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], _UserType.Teacher));
                        }
                    }

                    conn.Close();
                }
            }
            if (teacherList.Count == 0) throw new Exception($"No teachers found in database.");
            return teacherList;
        }

        public List<Class> GetClassesOfStudent(User student)
        {
            List<Class> list = new List<Class>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Classes.ClassId, ClassName FROM ClassStudents INNER JOIN Classes ON Classes.ClassId = ClassStudents.ClassId WHERE StudentId = @StudentIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter sidParameter = new SqlParameter("@StudentIdParameter", student.Id);
                    cmd.Parameters.Add(sidParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Class((int)reader[0], (string)reader[1]));
                        }
                    }

                    conn.Close();
                }
            }
            return list;
        }

        public List<Class> GetClassesOfTeacher(User teacher)
        {
            List<Class> list = new List<Class>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Classes.ClassId, ClassName FROM ClassTeachers INNER JOIN Classes ON Classes.ClassId = ClassTeachers.ClassId WHERE TeacherId = @TeacherIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter sidParameter = new SqlParameter("@TeacherIdParameter", teacher.Id);
                    cmd.Parameters.Add(sidParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Class((int)reader[0], (string)reader[1]));
                        }
                    }

                    conn.Close();
                }
            }
            return list;
        }

        public void ChangeClassName(Class _class, string newClassName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Classes SET ClassName = @ClassnameParameter WHERE ClassId = @ClassIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter cnParameter = new SqlParameter("@ClassnameParameter", newClassName);
                    SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", _class.ClassId);
                    cmd.Parameters.AddRange(new SqlParameter[] { cnParameter, cidParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public DateTime GetLastLoginOfStudent(User student)
        {
            DateTime lastLogin;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT LastLogin FROM Students WHERE StudentId = @StudentIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter sidParameter = new SqlParameter("@StudentIdParameter", student.Id);
                    cmd.Parameters.Add(sidParameter);

                    conn.Open();
                    try
                    {
                        lastLogin = (DateTime)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        throw new Exception("Couldn't fetch last login of student.");
                    }
                    conn.Close();
                }
            }
            return lastLogin;
        }

        public void EditStudentDetails(User student, string newFirstName, string newLastName, string newEmail, string newHashedPassword, string newSalt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Students SET FirstName =	@FirstnameParameter, Surname = @LastnameParameter, Email = @EmailParameter, Password = @HashedPasswordParameter, Salt = @SaltParameter WHERE StudentId = @StudentIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter fnParameter = new SqlParameter("@FirstnameParameter", newFirstName);
                    SqlParameter lnParameter = new SqlParameter("@LastnameParameter", newLastName);
                    SqlParameter emailParameter = new SqlParameter("@EmailParameter", newEmail);
                    SqlParameter hpParameter = new SqlParameter("@HashedPasswordParameter", newHashedPassword);
                    SqlParameter saltParameter = new SqlParameter("@SaltParameter", newSalt);
                    SqlParameter sidParameter = new SqlParameter("@StudentIdParameter", student.Id);
                    cmd.Parameters.AddRange(new SqlParameter[] { fnParameter, lnParameter, emailParameter, hpParameter, saltParameter, sidParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public int CreateNewQuestion(Question question)
        {
            int index;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Questions VALUES (@TopicIdParameter, @AuthorIdParameter, @DifficultyParameter, @QuestionContentParameter, CAST(@IsMultipleChoice AS BIT), @AnswerParameter, @AnswerKeyParameter, @MCAnswersParameter) SELECT @@Identity";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter tidParameter = new SqlParameter("@TopicIdParameter", question.Topic.TopicId);
                    SqlParameter aidParameter = new SqlParameter("@AuthorIdParameter", question.Author.Id);
                    SqlParameter difficultyParameter = new SqlParameter("@DifficultyParameter", question.Difficulty);
                    SqlParameter qcParameter = new SqlParameter("@QuestionContentParameter", question.QuestionContent);
                    SqlParameter isMCParameter = new SqlParameter("@IsMultipleChoice", question.IsMc);
                    SqlParameter answerParameter = new SqlParameter("@AnswerParameter", string.Join(",", question.Answer));
                    SqlParameter akParameter = new SqlParameter("@AnswerKeyParameter", question.AnswerKey);
                    SqlParameter mcaParameter = new SqlParameter("@MCAnswersParameter", string.Join(",", question.McAnswers));
                    cmd.Parameters.AddRange(new SqlParameter[] { tidParameter, aidParameter, difficultyParameter, qcParameter, isMCParameter, answerParameter, akParameter, mcaParameter });

                    conn.Open();
                    index = Convert.ToInt32((decimal)cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            return index;
        }

        public void AppendImageToQuestion(int questionId, byte[] imageData)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Images VALUES (@QuestionIdParameter, (CONVERT(VARBINARY(MAX), @ImageDataParameter)))";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter qidParameter = new SqlParameter("@QuestionIdParameter", questionId);
                    SqlParameter idParameter = new SqlParameter("@ImageDataParameter", imageData);
                    cmd.Parameters.AddRange(new SqlParameter[] { qidParameter, idParameter });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Question> GetQuestionsMultimetric(List<int> difficulties, Topic topic, User author)
        {
            List<Question> questionList = new List<Question>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetQuestionsMultimetric", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AuthorId", author?.Id));
                    cmd.Parameters.Add(new SqlParameter("@TopicId", topic?.TopicId));
                    cmd.Parameters.Add(new SqlParameter("@ListOfDifficulties", string.Join(",", difficulties)));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Question question = new Question(questionId: (int)reader[0], difficulty: (int)reader[1], questionContent: (string)reader[2], answer: ((string)reader[4]).Split(',').ToList(), author: new User((int)reader[7], (string)reader[8], (string)reader[9], (string)reader[10], _UserType.Teacher), answerKey: (string)reader[5], topic: new Topic((int)reader[11], (string)reader[12], (string)reader[13], new Subject((int)reader[14], (string)reader[15])));
                            
                            // if multiple-choice
                            if ((bool)reader[3]) question.ForceMc(((string)reader[6]).Split(',').ToList());

                            questionList.Add(question);
                        }
                    }

                    conn.Close();
                }
            }
            return questionList;
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            return (Bitmap)new ImageConverter().ConvertFrom(byteArray);
        }

        public List<Image> GetQuestionImages(Question question)
        {
            List<Image> imageList = new List<Image>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Image FROM Images WHERE QuestionId = @QuestionIdParameter";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter qidParameter = new SqlParameter("@QuestionIdParameter", question.QuestionId);
                    cmd.Parameters.Add(qidParameter);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            imageList.Add(ByteArrayToImage((byte[])reader[0]));
                        }
                    }

                    conn.Close();
                }
            }
            return imageList;
        }

        public void InsertStudentQuestionAttempt(Question question, User student,  bool wasCorrect, string studentAnswer, Assignment assignment = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertStudentQuestionAttempt", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@QuestionId", question.QuestionId));
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment?.AssignmentId));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));
                    cmd.Parameters.Add(new SqlParameter("@TopicId", question.Topic.TopicId));
                    cmd.Parameters.Add(new SqlParameter("@WasCorrect", wasCorrect));
                    cmd.Parameters.Add(new SqlParameter("@StudentAnswer", studentAnswer));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void InsertStudentQuestionAttemptWithTopic(Topic topic, User student, bool wasCorrect, string studentAnswer, Assignment assignment = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertStudentQuestionAttempt", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment?.AssignmentId));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));
                    cmd.Parameters.Add(new SqlParameter("@TopicId", topic.TopicId));
                    cmd.Parameters.Add(new SqlParameter("@WasCorrect", wasCorrect));
                    cmd.Parameters.Add(new SqlParameter("@StudentAnswer", studentAnswer));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}