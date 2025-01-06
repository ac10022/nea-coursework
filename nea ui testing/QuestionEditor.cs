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
    /// <summary>
    /// A form which can be used by teachers to create/modify questions.
    /// </summary>
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
                // prepare fields on load, should only be able to submit when modifications have been made
                SubmitButton.Enabled = false;
                IncorrectAnswersField.Enabled = false;
                IncorrectAnswersLabel.Enabled = false;
                SuccessMessage.Visible = false;

                this.isEditing = isEditing;
                this.questionRef = questionRef;

                // if no question to edit has been referenced, something has gone wrong
                if (isEditing && questionRef == null) throw new Exception("No question specified to be edited.");

                // fetch topics from DB and place in topic picker
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

        /// <summary>
        /// A method to test fields for data. Here: only allow the user to submit the question if there is question content, a selected difficulty, a selected topic, and an answer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForData(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            canSubmit = ContentField.TextLength != 0 && DifficultyPicker.SelectedIndex != -1 && TopicPicker.SelectedIndex != -1 && AnswerField.TextLength != 0;
            SubmitButton.Enabled = canSubmit;
        }

        /// <summary>
        /// A method which is called when switching between free-input and multiple-choice. Enables/disables the correct controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// On image upload: use an open-file dialog to allow the user to select a question image. Allow the user to select an image, then add this to an image tracking list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadImageEvent(object sender, EventArgs e)
        {
            try
            {
                // set up OFD so that only bmp, jpg, and png formats can be selected
                OFD.Title = "Select image to upload";
                OFD.DefaultExt = "jpg";
                OFD.Filter = @"Images (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

                // if an image has been selected successfully
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    // get this image path
                    string imagePath = OFD.FileName;

                    // regex selects end of file path
                    imageTrackingList.Add(Regex.Match(imagePath, @"[^\\]*\.(png|jpg|jpeg)$").Value, Image.FromFile(imagePath));

                    // update image tracking list within form
                    UpdateImageTrackingList();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to reload the image tracking list, i.e., refill the listbox with the contents of the dictionary.
        /// </summary>
        private void UpdateImageTrackingList()
        {
            // display file path on tracking list
            ImageTrackingList.DataSource = imageTrackingList.Select(x => x.Key).ToArray();
        }

        /// <summary>
        /// A method to remove a single selected image from the image tracking list then refresh it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveImageEvent(object sender, EventArgs e)
        {
            imageTrackingList.Remove((string)ImageTrackingList.SelectedItem);
            UpdateImageTrackingList();
        }

        /// <summary>
        /// On submit: fetch fields, then parse this into a single question object. If editing, update the existing question to the new one, otherwise insert the new question into the DB. If any images have been appended, save these in the DB with reference to this question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitQuestion(object sender, EventArgs e)
        {
            try
            {
                // if creating a new question
                if (!isEditing)
                {
                    // create a question object from fields, with author referencing the logged-in user
                    Question question = new Question(topicList[TopicPicker.SelectedIndex], DifficultyPicker.SelectedIndex + 1, ContentField.Text, AnswerField.Text.Split(',').ToList(), -1, Program.loggedInUser, AnswerKeyField.Text);

                    // if multiple-choice has been selected, append the mc answers
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

                    // display success message
                    SuccessMessage.Visible = true;
                    SuccessMessage.Text = $"Successfully created question";
                }
                // if editing
                else
                {
                    if (questionRef == null) throw new Exception("No question specified to be edited.");

                    // create a question object from fields, with author referencing the logged-in user
                    Question question = new Question(topicList[TopicPicker.SelectedIndex], DifficultyPicker.SelectedIndex + 1, ContentField.Text, AnswerField.Text.Split(',').ToList(), questionRef.QuestionId, questionRef.Author, AnswerKeyField.Text);

                    // if multiple-choice has been selected, append the mc answers
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

                    // display success message
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

        /// <summary>
        /// A method for editing existing questions: preload editing fields with existing question data.
        /// </summary>
        private void PreloadFields()
        {
            // if editing an existing question
            if (questionRef != null)
            {
                // tab 1: string question metadata fields
                ContentField.Text = questionRef.QuestionContent;
                DifficultyPicker.SelectedIndex = questionRef.Difficulty - 1;
                TopicPicker.SelectedIndex = questionRef.Topic.TopicId - 1;
                AnswerField.Text = string.Join(",", questionRef.Answer);
                
                if (questionRef.IsMc)
                {
                    MultipleChoiceCheckbox.Checked = true;
                    IncorrectAnswersField.Text = string.Join(",", questionRef.McAnswers);
                }

                // tab 2: images
                imageTrackingList.Clear();

                // download existing question images from database and add these to tracking list automatically
                tempImagePaths = DownloadQuestionImages();
                foreach (string imagePath in tempImagePaths)
                {
                    imageTrackingList.Add(Regex.Match(imagePath, @"[^\\]*\.(png|jpg|jpeg)$").Value, Image.FromFile(imagePath));
                }
                UpdateImageTrackingList();

                // tab 3: answer key
                if (!string.IsNullOrEmpty(questionRef.AnswerKey))
                {
                    AnswerKeyField.Text = questionRef.AnswerKey;
                }
            }
        }

        /// <summary>
        /// A method to fetch existing images appended to the question referenced from the database.
        /// </summary>
        /// <returns>A list of image paths, each image stored in the default temp directory.</returns>
        private List<string> DownloadQuestionImages()
        {
            List<string> pathList = new List<string>();

            // if editing an existing question
            if (questionRef != null)
            {
                // fetch images appended to this question from DB
                foreach (Image image in dbh.GetQuestionImages(questionRef))
                {
                    // save each image to temp folder and record paths
                    string tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString()}.png");
                    pathList.Add(tempPath);
                    
                    // save each image to their new path
                    image.Save(tempPath);
                }
            }
            return pathList;
        }

        /// <summary>
        /// On close: dispose of temporary images if the question wasn't saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            // dispose of temp images if question wasn't saved
            if (tempImagePaths != null && tempImagePaths.Count != 0)
            {
                foreach (string s in tempImagePaths)
                {
                    // if the temp image still exists, delete it
                    if (File.Exists(s)) File.Delete(s);
                }
            }
        }
    }
}