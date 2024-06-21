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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
    public partial class QuestionEditor : Form
    {
        private bool canSubmit = false;
        Dictionary<string, Image> imageTrackingList = new Dictionary<string, Image>();
        List<Topic> topicList;

        public QuestionEditor()
        {
            InitializeComponent();
            SubmitButton.Enabled = false;
            IncorrectAnswersField.Enabled = false;
            IncorrectAnswersLabel.Enabled = false;
            SuccessMessage.Visible = false;

            // put topics in topic picker
            DatabaseHelper dbh = new DatabaseHelper();
            topicList = dbh.GetAllTopics();
            TopicPicker.DataSource = topicList.Select(x => x.TopicName).ToArray();
            TopicPicker.SelectedIndex = -1;
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
                DatabaseHelper dbh = new DatabaseHelper();

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
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }
    }
}
