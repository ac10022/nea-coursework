using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.Common;
using System.Reflection;
using nea_ui_testing;

namespace nea_prototype_full
{
    internal class DatabaseHelper
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lucam\Documents\Visual Studio 2022\All Projects\nea ui testing\Database.mdf"";Integrated Security=True";

        /// <summary>
        /// Given an email and user type, returns the 5 character salt for the user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userType"></param>
        /// <returns>A 5 character string containing the user salt.</returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Given the salt, password and user type, returns the user entity.
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="hashedPassword"></param>
        /// <param name="userType"></param>
        /// <returns>An object containing user data.</returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Refreshes the last login date of the given user to the current day.
        /// </summary>
        /// <param name="user"></param>
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

        /// <summary>
        /// Fetches all topics stored on the database.
        /// </summary>
        /// <returns>A list containing topic objects of all topics in the database.</returns>
        /// <exception cref="Exception"></exception>
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

        public void InsertStudentQuestionAttempt(Question question, User student,  bool wasCorrect, string studentAnswer, DateTime timeQOpened, Assignment assignment = null)
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
                    cmd.Parameters.Add(new SqlParameter("@TimeQuestionOpened", timeQOpened));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void InsertStudentQuestionAttemptWithTopic(Topic topic, User student, bool wasCorrect, string studentAnswer, DateTime timeQOpened, Assignment assignment = null)
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
                    cmd.Parameters.Add(new SqlParameter("@TimeQuestionOpened", timeQOpened));

                    //

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CreateAssignment(Assignment assignment)
        {
            int index;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string assignmentsQuery = @"INSERT INTO Assignments VALUES(@SetterIdParameter, @HwkNameParameter, CAST(@HwkDueDateParameter AS DATETIME)) SELECT @@Identity";
                string assignmentClassesQuery = @"INSERT INTO AssignmentClasses VALUES(@AssignmentIdParameter, @ClassIdParameter)";
                StringBuilder assignmentQuestionsQuery = new StringBuilder();
                assignmentQuestionsQuery.Append(@"INSERT INTO AssignmentQuestions VALUES");

                SqlCommand assignmentsCommand = new SqlCommand(assignmentsQuery, conn);
                SqlParameter sidParameter = new SqlParameter("@SetterIdParameter", assignment.Setter.Id);
                SqlParameter hwnParameter = new SqlParameter("@HwkNameParameter", assignment.HomeworkName);
                SqlParameter hwddParameter = new SqlParameter("@HwkDueDateParameter", assignment.HomeworkDueDate);
                assignmentsCommand.Parameters.AddRange(new SqlParameter[] { sidParameter, hwnParameter, hwddParameter });

                conn.Open();
                index = Convert.ToInt32((decimal)assignmentsCommand.ExecuteScalar());
                conn.Close();

                SqlCommand assignmentClassesCommand = new SqlCommand(assignmentClassesQuery, conn);
                SqlParameter aidParameter = new SqlParameter("@AssignmentIdParameter", index);
                SqlParameter cidParameter = new SqlParameter("@ClassIdParameter", assignment.TargetClass.ClassId);
                assignmentClassesCommand.Parameters.AddRange(new SqlParameter[] { aidParameter, cidParameter });

                conn.Open();
                assignmentClassesCommand.ExecuteNonQuery();
                conn.Close();

                foreach (Question q in assignment.QuestionList)
                {
                    assignmentQuestionsQuery.Append($" ({index}, {q.QuestionId}),");
                }

                // remove last comma
                assignmentQuestionsQuery.Length--;

                SqlCommand assignmentQuestionsCommand = new SqlCommand(assignmentQuestionsQuery.ToString(), conn);

                conn.Open();
                assignmentQuestionsCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// Given a class, fetches the assignments (excluding the list of questions) for this class, due both in the past and in the future.
        /// </summary>
        /// <param name="_class"></param>
        /// <returns>A list of assignment objects (without their corresponding question items).</returns>
        public List<Assignment> GetClassAssignments(Class _class)
        {
            List<Assignment> assignmentList = new List<Assignment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetClassAssignments", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ClassID", _class.ClassId));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            assignmentList.Add(new Assignment(assignmentId: (int)reader[0], homeworkName: (string)reader[1], homeworkDueDate: (DateTime)reader[2], targetClass: _class, setter: new User((int)reader[3], (string)reader[4], (string)reader[5], (string)reader[6], _UserType.Teacher), questionList: null));
                        }
                    }

                    conn.Close();
                }
            }
            return assignmentList;
        }

        public List<Question> GetQuestionsFromAssignment(Assignment assignment)
        {
            List<Question> questionList = new List<Question>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetQuestionsFromAssignment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment.AssignmentId));

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

        public double StudentCompletedAssignmentTest(Assignment assignment, User student)
        {
            double studentHasCompleted = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("StudentCompletedAssignmentTest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment.AssignmentId));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));

                    conn.Open();
                    studentHasCompleted = (double)cmd.ExecuteScalar();
                    conn.Close();
                }
            }
            return studentHasCompleted;
        }

        /// <summary>
        /// Given an assignment, fetches questions and their corresponding correctness.
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns>A dictionary: key containing the question, value containing the amount of times it was correctly answered for that assignment.</returns>
        public Dictionary<Question, int> PerformancePerAssignmentQuestion(Assignment assignment)
        {
            Dictionary<Question, int> questionCorrectness = new Dictionary<Question, int>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PerformancePerAssignmentQuestion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment.AssignmentId));

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // 0 QC.CorrectTally, 1 Q.QuestionId, 2 Q.Difficulty, 3 Q.QuContent, 4 Q.IsMC, 5 Q.Answer, 6 Q.AnswerKey, 7 Q.MCAnswers, 8 A.AuthorId, 9 A.FirstName, 10 A.Surname, 11 A.Email, 12 ST.TopicId, 13 ST.TopicName, 14 ST.VideoLink, 15 ST.SubjectId, 16 ST.SubjectName
                            Question question = new Question(questionId: (int)reader[1], difficulty: (int)reader[2], questionContent: (string)reader[3], answer: ((string)reader[5]).Split(',').ToList(), author: new User((int)reader[8], (string)reader[9], (string)reader[10], (string)reader[11], _UserType.Teacher), answerKey: (string)reader[6], topic: new Topic((int)reader[12], (string)reader[13], (string)reader[14], new Subject((int)reader[15], (string)reader[16])));

                            // if multiple-choice
                            if ((bool)reader[4]) question.ForceMc(((string)reader[7]).Split(',').ToList());

                            questionCorrectness.Add(question, (int)reader[0]);
                        }
                    }

                    conn.Close();
                }
            }
            return questionCorrectness;
        }

        public Dictionary<Question, int> PercentagePerAssignmentQuestion(Assignment assignment)
        {
            Dictionary<Question, int> questionCorrectness = new Dictionary<Question, int>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PerformancePerAssignmentQuestion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment.AssignmentId));

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // 0 QC.CorrectTally, 1 Q.QuestionId, 2 Q.Difficulty, 3 Q.QuContent, 4 Q.IsMC, 5 Q.Answer, 6 Q.AnswerKey, 7 Q.MCAnswers, 8 A.AuthorId, 9 A.FirstName, 10 A.Surname, 11 A.Email, 12 ST.TopicId, 13 ST.TopicName, 14 ST.VideoLink, 15 ST.SubjectId, 16 ST.SubjectName
                            Question question = new Question(questionId: (int)reader[1], difficulty: (int)reader[2], questionContent: (string)reader[3], answer: ((string)reader[5]).Split(',').ToList(), author: new User((int)reader[8], (string)reader[9], (string)reader[10], (string)reader[11], _UserType.Teacher), answerKey: (string)reader[6], topic: new Topic((int)reader[12], (string)reader[13], (string)reader[14], new Subject((int)reader[15], (string)reader[16])));

                            // if multiple-choice
                            if ((bool)reader[4]) question.ForceMc(((string)reader[7]).Split(',').ToList());

                            questionCorrectness.Add(question, (int)(Math.Round(Convert.ToDouble((int)reader[0]) / Convert.ToDouble((int)reader[17]), 3) * 100));
                        }
                    }

                    conn.Close();
                }
            }
            return questionCorrectness;
        }

        public List<Assignment> GetAllAssignmentsOfStudent(User student)
        {
            List<Assignment> assignmentList = new List<Assignment>();
            foreach (Class _class in GetClassesOfStudent(student)) assignmentList.AddRange(GetClassAssignments(_class));
            return assignmentList;
        }

        public double StudentCorrectnessAssignmentTest(Assignment assignment, User student)
        {
            double studentCorrectness = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("StudentCorrectnessAssignmentTest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment.AssignmentId));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));

                    conn.Open();
                    studentCorrectness = (double)cmd.ExecuteScalar();
                    conn.Close();
                }
            }
            return studentCorrectness;
        }

        public List<QuestionAttempt> GetStudentQuestionAttempts(User student)
        {
            List<QuestionAttempt> questionAttempts = new List<QuestionAttempt>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudentQuestionAttempts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Question question = null;
                            
                            // if a question is attached to the attempt, i.e. not an attempt of a rgq
                            if (reader[0].GetType().Name != "DBNull")
                            {
                                question = new Question(questionId: (int)reader[0], difficulty: (int)reader[1], questionContent: (string)reader[2], answer: ((string)reader[4]).Split(',').ToList(), author: new User((int)reader[7], (string)reader[8], (string)reader[9], (string)reader[10], _UserType.Teacher), answerKey: (string)reader[5], topic: new Topic((int)reader[11], (string)reader[12], (string)reader[13], new Subject((int)reader[14], (string)reader[15])));

                                // if multiple-choice
                                if ((bool)reader[3]) question.ForceMc(((string)reader[6]).Split(',').ToList());
                            }


                            // 0 QR.QuestionId, 1 QR.Difficulty, 2 QR.QuContent, 3 QR.IsMC, 4 QR.Answer, 5 QR.AnswerKey, 6 QR.MCAnswers, 7 QR.AuthorId, 8 QR.FirstName, 9 QR.Surname, 10 QR.Email, 11 QR.TopicId, 12 QR.TopicName, 13 QR.VideoLink, 14 QR.SubjectId, 15 QR.SubjectName, 16 QA.AttemptId, 17 QA.WasCorrect, 18 QA.StudentAns, 19 QA.TimeOfAtt, 20 QA.TimeQuOpened

                            DateTime timeQuestionOpened = reader[20].GetType().Name == "DBNull" ? DateTime.MinValue : (DateTime)reader[20];

                            QuestionAttempt questionAttempt = new QuestionAttempt((int)reader[16], (bool)reader[17], (string)reader[18], (DateTime)reader[19], timeQuestionOpened, student, question);

                            // if rgq
                            if (reader[0].GetType().Name == "DBNull")
                            {
                                questionAttempt.AppendPseudotopic((_Topic)((int)reader[21]));
                            }

                            questionAttempts.Add(questionAttempt);

                            //new Topic((int)reader[11], (string)reader[12], (string)reader[13], new Subject((int)reader[14], (string)reader[15]))
                        }
                    }

                    conn.Close();
                }
            }
            return questionAttempts;
        }

        public Topic GetTopicFromId(int topicId)
        {
            Topic topic = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TopicId, TopicName, VideoLink, Subjects.SubjectId, Subjects.SubjectName FROM Topics INNER JOIN Subjects ON Topics.SubjectId = Subjects.SubjectId WHERE TopicId = @TopicId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@TopicId", topicId));
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            topic = new Topic((int)reader[0], (string)reader[1], (string)reader[2], new Subject((int)reader[3], (string)reader[4]));
                        }
                    }

                    conn.Close();
                }
            }
            return topic;
        }

        public List<Topic> GetStudentLastPracticedTopics(User student)
        {
            List<Topic> topics = new List<Topic>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudentLastPracticedTopics", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            topics.Add(new Topic((int)reader[0], (string)reader[1], (string)reader[2], new Subject((int)reader[3], (string)reader[4])));
                        }
                    }

                    conn.Close();
                }
            }
            return topics;
        }

        public List<Topic> GetClassSOWTopics(Class _class)
        {
            List<Topic> topics = new List<Topic>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetClassSOWTopics", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ClassId", _class.ClassId));
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            topics.Add(new Topic((int)reader[0], (string)reader[1], (string)reader[2], new Subject((int)reader[3], (string)reader[4])));
                        }
                    }

                    conn.Close();
                }
            }
            return topics;
        }

        public void ChangeClassSOW(Class _class, List<Topic> newSOW)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                StringBuilder query = new StringBuilder();
                query.Append("DELETE FROM SchemeOfWork WHERE ClassId = @ClassId DELETE FROM ChecklistData WHERE ClassId = @ClassId INSERT INTO SchemeOfWork VALUES");

                foreach (Topic topic in newSOW)
                {
                    query.Append($" ({_class.ClassId}, {topic.TopicId}),");
                }

                // remove last comma
                query.Length--;

                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    SqlParameter cidParameter = new SqlParameter("@ClassId", _class.ClassId);
                    cmd.Parameters.Add(cidParameter);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<int> GetStudentChecklistData(Class _class, User student)
        {
            try
            {
                List<int> result = new List<int>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT SerialisedData FROM ChecklistData WHERE StudentId = @StudentId AND ClassId = @ClassId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ClassId", _class.ClassId));
                        cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));

                        conn.Open();
                        string serialisedString = (string)cmd.ExecuteScalar();
                        if (serialisedString == null) return null;
                        result = DeserialiseChecklistData(serialisedString);
                        conn.Close();
                    }
                }
                return result;
            } 
            catch
            {
                return null;
            }
        }

        private List<int> DeserialiseChecklistData(string serialisedData)
        {
            List<int> result = new List<int>();
            char[] chars = serialisedData.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                result.Add(chars[i] - '0');
            }
            return result;
        }

        public void UpdateSeralisedSOWData(Class _class, User student, string serialisedData)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ChecklistData WHERE StudentId = @StudentId AND ClassId = @ClassId INSERT INTO ChecklistData VALUES (@StudentId, @ClassId, @SerialisedData)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ClassId", _class.ClassId));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));
                    cmd.Parameters.Add(new SqlParameter("@SerialisedData", serialisedData));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void OverrideAttemptCorrectness(QuestionAttempt questionAttempt, bool newCorrectness)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"UPDATE QuestionAttempts SET WasCorrect = CAST({Convert.ToInt32(newCorrectness)} AS BIT) WHERE AttemptId = @AttemptId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@AttemptId", questionAttempt.AttemptId));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void DeleteAssignment(Assignment assignment)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAssignment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AssignmentId", assignment.AssignmentId));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void DeleteQuestionImages(Question question)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM Images WHERE QuestionId = @QuestionId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@QuestionId", question.QuestionId));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void UpdateQuestion(Question question)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Questions SET TopicId = @TopicId, Difficulty = @Difficulty, QuContent = @QuestionContent, IsMC = CAST(@IsMC AS BIT), Answer = @Answer, AnswerKey = @AnswerKey, MCAnswers = @MCAnswers WHERE QuestionId = @QuestionId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@TopicId", question.Topic.TopicId));
                    cmd.Parameters.Add(new SqlParameter("@Difficulty", question.Difficulty));
                    cmd.Parameters.Add(new SqlParameter("@QuestionContent", question.QuestionContent));
                    cmd.Parameters.Add(new SqlParameter("@IsMC", question.IsMc ? 1 : 0));
                    cmd.Parameters.Add(new SqlParameter("@Answer", string.Join(",", question.Answer)));
                    cmd.Parameters.Add(new SqlParameter("@AnswerKey", question.AnswerKey));

                    string mcAnswers = string.Empty;
                    // if there are multiple choice answers
                    if (question.McAnswers != null && question.McAnswers.Count != 0)
                    {
                        mcAnswers = string.Join(",", question.McAnswers);
                    }

                    cmd.Parameters.Add(new SqlParameter("@MCAnswers", mcAnswers));
                    cmd.Parameters.Add(new SqlParameter("@QuestionId", question.QuestionId));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void DeleteQuestion(Question question)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteQuestion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@QuestionId", question.QuestionId));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void DeleteStudent(User student)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteStudent", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}