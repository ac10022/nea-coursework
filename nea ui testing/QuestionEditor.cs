using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
    public partial class QuestionEditor : Form
    {
        private bool canSubmit = false;
        private Dictionary<string, Image> imageTrackingList = new Dictionary<string, Image>();
        private List<Topic> topicList;

        private DatabaseHelper dbh = new DatabaseHelper();

        // question editing
        private bool isEditing;
        private Question questionRef;
        private List<string> tempImagePaths;

        public QuestionEditor(bool isEditing = false, Question questionRef = null)
        {
            InitializeComponent();
            try
            {
                SubmitButton.Enabled = false;
                IncorrectAnswersField.Enabled = false;
                IncorrectAnswersLabel.Enabled = false;
                SuccessMessage.Visible = false;

                this.isEditing = isEditing;
                this.questionRef = questionRef;

                if (isEditing && questionRef == null) throw new Exception("No question specified to be edited.");

                // put topics in topic picker
                
                topicList = dbh.GetAllTopics();
                TopicPicker.DataSource = topicList.Select(x => x.TopicName).ToArray();
                TopicPicker.SelectedIndex = -1;

                PreloadFields();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
                Close();
            }
        }

        private void TestForData(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            canSubmit = ContentField.TextLength != 0 && DifficultyPicker.SelectedIndex != -1 && TopicPicker.SelectedIndex != -1 && AnswerField.TextLength != 0;
            SubmitButton.Enabled = canSubmit;
        }

        private void EnableMultipleChoiceEvent(object sender, EventArgs e)
        {
            if (MultipleChoiceCheckbox.Checked)
            {
                IncorrectAnswersLabel.Enabled = true;
                IncorrectAnswersField.Enabled = true;
            }
            else
            {
                IncorrectAnswersLabel.Enabled = false;
                IncorrectAnswersField.Enabled = false;
                IncorrectAnswersField.Text = string.Empty;
            }
        }

        private void UploadImageEvent(object sender, EventArgs e)
        {
            try
            {
                OFD.Title = "Select image to upload";
                OFD.DefaultExt = "jpg";
                OFD.Filter = @"Images (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = OFD.FileName;
                    // regex selects end of file path
                    imageTrackingList.Add(Regex.Match(imagePath, @"[^\\]*\.(png|jpg|jpeg)$").Value, Image.FromFile(imagePath));
                    UpdateImageTrackingList();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void UpdateImageTrackingList()
        {
            // display file path on tracking list
            ImageTrackingList.DataSource = imageTrackingList.Select(x => x.Key).ToArray();
        }

        private void RemoveImageEvent(object sender, EventArgs e)
        {
            imageTrackingList.Remove((string)ImageTrackingList.SelectedItem);
            UpdateImageTrackingList();
        }

        private void SubmitQuestion(object sender, EventArgs e)
        {
            try
            {
                if (!isEditing)
                {
                    Question question = new Question(topicList[TopicPicker.SelectedIndex], DifficultyPicker.SelectedIndex + 1, ContentField.Text, AnswerField.Text.Split(',').ToList(), -1, Program.loggedInUser, AnswerKeyField.Text);

                    if (MultipleChoiceCheckbox.Checked) question.ForceMc(IncorrectAnswersField.Text.Split(',').ToList());

                    // push question to db, get id of question just pushed
                    int questionId = dbh.CreateNewQuestion(question);

                    // if images have been uploaded
                    if (imageTrackingList.Count != 0)
                    {
                        foreach (Image image in imageTrackingList.Values)
                        {
                            // convert each image to its byte array representation
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, image.RawFormat);
                                byte[] byteArray = ms.ToArray();
                                // push all images to db referencing qid
                                dbh.AppendImageToQuestion(questionId, byteArray);
                            }
                        }
                    }

                    SuccessMessage.Visible = true;
                    SuccessMessage.Text = $"Successfully created question";
                }
                else
                {
                    if (questionRef == null) throw new Exception("No question specified to be edited.");

                    Question question = new Question(topicList[TopicPicker.SelectedIndex], DifficultyPicker.SelectedIndex + 1, ContentField.Text, AnswerField.Text.Split(',').ToList(), questionRef.QuestionId, questionRef.Author, AnswerKeyField.Text);

                    if (MultipleChoiceCheckbox.Checked) question.ForceMc(IncorrectAnswersField.Text.Split(',').ToList());

                    // clear existing images, replace with new ones
                    dbh.DeleteQuestionImages(questionRef);

                    // if images have been uploaded
                    if (imageTrackingList.Count != 0)
                    {
                        foreach (Image image in imageTrackingList.Values)
                        {
                            // convert each image to its byte array representation
                            byte[] byteArray = null;
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, image.RawFormat);
                                byteArray = ms.ToArray();
                            }
                            // push all images to db referencing qid
                            dbh.AppendImageToQuestion(questionRef.QuestionId, byteArray);
                        }
                    }

                    // update question data with new input
                    dbh.UpdateQuestion(question);

                    // delete temp images
                    foreach (string s in tempImagePaths)
                    {
                        if (File.Exists(s)) File.Delete(s);
                    }
                    tempImagePaths.Clear();

                    SuccessMessage.Visible = true;
                    SuccessMessage.Text = $"Successfully edited question";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void PreloadFields()
        {
            if (questionRef != null)
            {
                // tab 1
                ContentField.Text = questionRef.QuestionContent;
                DifficultyPicker.SelectedIndex = questionRef.Difficulty - 1;
                TopicPicker.SelectedIndex = questionRef.Topic.TopicId - 1;
                AnswerField.Text = string.Join(",", questionRef.Answer);
                
                if (questionRef.IsMc)
                {
                    MultipleChoiceCheckbox.Checked = true;
                    IncorrectAnswersField.Text = string.Join(",", questionRef.McAnswers);
                }

                // tab 2
                imageTrackingList.Clear();
                tempImagePaths = DownloadQuestionImages();
                foreach (string imagePath in tempImagePaths)
                {
                    imageTrackingList.Add(Regex.Match(imagePath, @"[^\\]*\.(png|jpg|jpeg)$").Value, Image.FromFile(imagePath));
                }
                UpdateImageTrackingList();

                // tab 3
                if (!string.IsNullOrEmpty(questionRef.AnswerKey))
                {
                    AnswerKeyField.Text = questionRef.AnswerKey;
                }
            }
        }

        private List<string> DownloadQuestionImages()
        {
            List<string> pathList = new List<string>();
            if (questionRef != null)
            {
                foreach (Image image in dbh.GetQuestionImages(questionRef))
                {
                    // save each image to temp folder and record paths
                    string tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString()}.png");
                    pathList.Add(tempPath);
                    image.Save(tempPath);
                }
            }
            return pathList;
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            // dispose of temp images if question wasn't saved
            if (tempImagePaths != null && tempImagePaths.Count != 0)
            {
                foreach (string s in tempImagePaths)
                {
                    if (File.Exists(s)) File.Delete(s);
                }
            }
        }
    }
}
