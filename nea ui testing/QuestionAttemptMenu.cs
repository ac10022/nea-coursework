using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListExtensionMethods;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace nea_ui_testing
{
    /// <summary>
    /// A form through which the student can view questions, question data, question images, and answer questions. The student also has access to a mini whiteboard to do workings on.
    /// </summary>
    public partial class QuestionAttemptMenu : Form
    {
        // question fields
        private Question questionRef;
        private List<Question> questionList;
        private Random random = new Random();
        private Control[] MCA_CONTROLS;
        private Control[] FI_CONTROLS;
        private bool canSubmit = false;
        private Assignment assignmentRef = null;
        private DateTime timeQuestionOpened = DateTime.MinValue;

        // image fields
        private List<Image> questionImagesRef;
        private Image originalImage;
        private double zoomFactor = 1;

        // the form to return to after the questions have been completed.
        private Form formReturn;

        // drawing fields
        private bool isDrawing = false;
        private Point mouseDownPosition;
        private Point mouseUpPosition;
        private Graphics drawing;
        private Pen pen = new Pen(Color.Black, 3);

        public QuestionAttemptMenu(List<Question> questionReference = null, Assignment assignmentRef = null, Form formReturnRef = null)
        {
            InitializeComponent();

            // fetch the first question in the question series and use this as a question reference, then remove this from the question series.
            questionRef = questionReference.First();
            questionReference.RemoveAt(0);
            questionList = questionReference;
            
            // if an assignment is appended to this practice, fetch this.
            this.assignmentRef = assignmentRef;

            QuestionsRemainingLabel.Text = questionReference.Count.ToString();

            timeQuestionOpened = DateTime.Now;

            MCA_CONTROLS = new Control[] { MCA_D, MCA_C, MCA_B, MCA_A, MCALabel };
            FI_CONTROLS = new Control[] { FI_4, FI_FIELD4, FI_3, FI_FIELD3, FI_2, FI_FIELD2, FI_1, FI_FIELD1, FILabel };

            isDrawing = false;

            formReturn = formReturnRef;

            LoadQuestionData();
        }

        /// <summary>
        /// A method to fill fields with question data and display relevant controls, i.e. answer boxes/multiple choice radio buttons.
        /// </summary>
        private void LoadQuestionData()
        {
            canSubmit = false;
            SubmitButton.Enabled = canSubmit;

            try
            {
                DatabaseHelper dbh = new DatabaseHelper();
                List<Image> imageList = new List<Image>();

                // if the question is not randomly generated
                if (!(questionRef is RandomlyGeneratedQuestion))
                {
                    // show the author of the question
                    AuthorLabel.Text = $"Author: {questionRef.Author.FirstName} {questionRef.Author.Surname}";
                    // fetch question images from DB
                    imageList = dbh.GetQuestionImages(questionRef);
                }
                else
                {
                    // display that this is a randomly generated question
                    AuthorLabel.Text = "Randomly generated question";
                    // if this rgq has any appended images, load these
                    if ((questionRef as RandomlyGeneratedQuestion).RgqImage != null) imageList.Add((questionRef as RandomlyGeneratedQuestion).RgqImage);
                }

                questionImagesRef = imageList;

                // load fields with question data
                TopicLabel.Text = $"Topic: {questionRef.Topic.TopicName}";
                SubjectLabel.Text = $"Subject: {questionRef.Topic.Subject.SubjectName}";
                DifficultyLabel.Text = $"Difficulty: {questionRef.Difficulty}";
                QuestionContentBox.Text = questionRef.QuestionContent;

                // if the question is multiple-choice
                if (questionRef.IsMc)
                {
                    List<string> allAnswers;
                    // if there are more than 3 alternative answers, take the first 3
                    if (questionRef.McAnswers.Count > 3) allAnswers = questionRef.McAnswers.Take(3).ToList();
                    else allAnswers = questionRef.McAnswers.ToList();
                    // if a mc question, it can only have one answer
                    allAnswers.Add(questionRef.Answer.First());
                    // shuffle the answer inc. the other multiple choice answers
                    string[] shuffledAnswers = allAnswers.RandomiseList().ToArray();

                    // there will always be at least 2 multiple-choice answers; the correct one and the alternate mc answer.
                    // push the mc answers to the fields
                    MCA_A.Text = shuffledAnswers[0];
                    MCA_B.Text = shuffledAnswers[1];
                    if (allAnswers.Count >= 3) MCA_C.Text = shuffledAnswers[2];
                    if (allAnswers.Count >= 4) MCA_D.Text = shuffledAnswers[3];

                    // show mc question controls, i.e. radio buttons
                    foreach (Control c in MCA_CONTROLS)
                    {
                        SetVisible(c);
                    }
                    // if less than 4 mca available, hide unavailable radio buttons
                    if (questionRef.McAnswers.Count < 4)
                    {
                        foreach (Control c in MCA_CONTROLS.Take(4 - allAnswers.Count)) SetHidden(c);
                    }
                    // hide all free-input controls
                    foreach (Control c in FI_CONTROLS)
                    {
                        SetHidden(c);
                    }
                }
                // if this is a free-input question
                else
                {
                    // if there are more than 4 answers to this question, take the first 4
                    List<string> allAnswers;
                    if (questionRef.Answer.Count > 4) allAnswers = questionRef.Answer.Take(4).ToList();
                    else allAnswers = questionRef.Answer.ToList();

                    // each part of the answer can be named in the DB by using diagonal brackets (<>), if there is a named answer, display this as the free-input field name, for each answer.
                    string match = Regex.Match(allAnswers[0], @"(?<=<).+(?=>)").Value;
                    FI_FIELD1.Text = match != string.Empty ? match : "Answer 1";
                    if (allAnswers.Count >= 2)
                    {
                        match = Regex.Match(allAnswers[1], @"(?<=<).+(?=>)").Value;
                        FI_FIELD2.Text = match != string.Empty ? match : "Answer 2";
                    }
                    if (allAnswers.Count >= 3)
                    {
                        match = Regex.Match(allAnswers[2], @"(?<=<).+(?=>)").Value;
                        FI_FIELD3.Text = match != string.Empty ? match : "Answer 3";
                    }
                    if (allAnswers.Count == 4)
                    {
                        match = Regex.Match(allAnswers[3], @"(?<=<).+(?=>)").Value;
                        FI_FIELD4.Text = match != string.Empty ? match : "Answer 4";
                    }

                    // show all free-input controls
                    foreach (Control c in FI_CONTROLS)
                    {
                        SetVisible(c);
                    }
                    // if less than 4 fi answers available, hide unavailable textboxes
                    if (allAnswers.Count < 4)
                    {
                        foreach (Control c in FI_CONTROLS.Take((4 - allAnswers.Count) * 2)) SetHidden(c);
                    }
                    // hide all mc controls
                    foreach (Control c in MCA_CONTROLS)
                    {
                        SetHidden(c);
                    }
                }

                // if this question has an image, load the image on the next tab
                if (imageList.Count != 0)
                {
                    // resize the image to fit in the box
                    Image image = ResizeImageToWidth(imageList.First(), ImageBox.Width);
                    ImageBox.Height = image.Height;
                    ImageBox.Image = image;
                    ImageBox.SizeMode = PictureBoxSizeMode.CenterImage;

                    originalImage = image;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to close the form and return to menu. Before closing, confirm with the user, and notify them that this will lose progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Hide();
            ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to quit? You will lose progress.");
            bool wasSuccess = false;

            // form closed events
            cf.FormClosing += (s, args) =>
            {
                wasSuccess = cf.wasSuccess;
            };
            cf.Closed += (s, args) =>
            {
                if (wasSuccess)
                {
                    Hide();
                    formReturn.Show();
                    Close();
                }
                else Show();
            };
            cf.Show();
        }

        /// <summary>
        /// A method to show and enable a control.
        /// </summary>
        /// <param name="c"></param>
        private void SetVisible(Control c)
        {
            c.Visible = true;
            c.Enabled = true;
            c.BringToFront();
        }

        /// <summary>
        /// A method to hide and disable a control.
        /// </summary>
        /// <param name="c"></param>
        private void SetHidden(Control c)
        {
            c.Visible = false;
            c.Enabled = false;
            c.SendToBack();
        }

        /// <summary>
        /// A method to resize an image to a new width. Height is scaled down maintaining original image ratio.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <returns>A scaled image, with a new width of the given width parameter.</returns>
        private Image ResizeImageToWidth(Image image, int width)
        {
            double resizeRatio = image.Width / (double)width;
            return new Bitmap(image, new Size(width, (int)Math.Round(image.Height / resizeRatio)));
        }

        /// <summary>
        /// On submit: fetch student answer, determine whether the student was correct, insert this question attempt, then take them to the instant feedback menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitEvent(object sender, EventArgs e)
        {
            try
            {
                bool wasCorrect = false;
                string wholeStudentAnswer = string.Empty;

                // if this was a multiple-choice question
                if (questionRef.IsMc)
                {
                    // set the student answer to the radio buttons which were selected
                    string studentAnswer = this.Controls.OfType<RadioButton>().First(x => x.Checked).Text;
                    // check this against the correct question answer
                    if (questionRef.Answer.First() == studentAnswer) wasCorrect = true;
                    wholeStudentAnswer = studentAnswer;
                }
                else
                {
                    // set the student answer to a list of the contents of the answer textboxes
                    List<string> studentAnswers = new List<string>();
                    foreach (TextBox tb in this.Controls.OfType<TextBox>().Where(x => x.Visible)) studentAnswers.Add(tb.Text.Replace(" ", ""));

                    // create a list of sanitised question answers to compare the student answers to.
                    List<string> questionAnsWithoutFields = new List<string>();
                    foreach (string answer in questionRef.Answer)
                    {
                        Match m = Regex.Match(answer, @".+(?=<.+>)");
                        if (m.Success) questionAnsWithoutFields.Add(m.Value.Replace(" ", ""));
                        else questionAnsWithoutFields.Add(answer.Replace(" ", ""));
                    }

                    // assume the student was correct, then for each of their inputs, check whether this answer appears in the actual question, and if not, it can be assumed the student made an arror.
                    wasCorrect = true;
                    foreach (string answer in studentAnswers)
                    {
                        if (!questionAnsWithoutFields.Contains(answer)) wasCorrect = false;
                    }
                    wholeStudentAnswer = string.Join(", ", studentAnswers);
                }

                // insert the question attempt into the DB
                DatabaseHelper dbh = new DatabaseHelper();
                // if randomly generated
                if (questionRef is RandomlyGeneratedQuestion)
                {
                    dbh.InsertStudentQuestionAttemptWithTopic(questionRef.Topic, Program.loggedInUser, wasCorrect, wholeStudentAnswer, timeQuestionOpened, assignmentRef);
                }
                // otherwise
                else
                {
                    dbh.InsertStudentQuestionAttempt(questionRef, Program.loggedInUser, wasCorrect, wholeStudentAnswer, timeQuestionOpened, assignmentRef);
                }

                SubmitButton.Enabled = false;
                DashboardButton.Enabled = false;

                Hide();
                // load a feedback form with the student answer, following questions, and assignment ref
                InstantFeedbackForm iff = new InstantFeedbackForm(questionRef, questionList, wasCorrect, assignmentRef, formReturn);

                // form closed events
                iff.Load += (s, args) =>
                {
                    Close();
                };
                iff.Show();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to test fields for data. Here: only allow the student to submit if at least one mc radio button is selected OR if each free-input textbox has been filled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForData(object sender, EventArgs e)
        {
            if (questionRef.IsMc)
            {
                canSubmit = MCA_A.Checked || MCA_B.Checked || MCA_C.Checked || MCA_D.Checked;
            }
            else
            {
                canSubmit = true;
                foreach(TextBox tb in this.Controls.OfType<TextBox>().Where(x => x.Visible))
                {
                    if (tb.Text == string.Empty) canSubmit = false;
                }
            }
            SubmitButton.Enabled = canSubmit;
        }

        /// <summary>
        /// On zoom: right click to zoom in, left click to zoom out of the image, zoom by a factor of 5/4.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomEvent(object sender, MouseEventArgs e)
        {
            // if there is a question image
            if (originalImage != null)
            {
                // if left-click, zoom in by 1.25
                if (e.Button.Equals(MouseButtons.Left) && zoomFactor < 4) zoomFactor *= 1.25;
                // if right-click, zoom in by 0.8 (reverse zoom in)
                else if (e.Button.Equals(MouseButtons.Right) && zoomFactor > 0.4) zoomFactor *= 0.8;

                // calculate the new size of the image and create a copy of the image which these dimensions
                Size resize = new Size((int)(originalImage.Width * zoomFactor), (int)(originalImage.Height * zoomFactor));
                Image newImage = new Bitmap(originalImage, resize);

                // display the new image
                ImageBox.Image = newImage;
            }
        }

        // drawing methods

        /// <summary>
        /// On load: preload the drawing panel to allow the user to draw on it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            // create graphics object from drawing box background so that lines can be drawn on it
            DrawingBox.BackgroundImage = new Bitmap(DrawingBox.Width, DrawingBox.Height, PixelFormat.Format24bppRgb);
            drawing = Graphics.FromImage(DrawingBox.BackgroundImage);

            // smooth rendering
            drawing.SmoothingMode = SmoothingMode.AntiAlias;

            // set drawing box background to white
            drawing.Clear(Color.White);

            // smooth pen edges
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;

            // set first point for mouse move invocations
            mouseDownPosition = e.Location;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // draw a line from point of previous invocation to this invocation, refresh to apply changes
                mouseUpPosition = e.Location;
                drawing.DrawLine(pen, mouseDownPosition, mouseUpPosition);
                DrawingBox.Refresh();

                // set point of previous invocation to point of this invocation to set up next invocation
                mouseDownPosition = mouseUpPosition;
            }
        }

        private void ClearDrawing(object sender, EventArgs e)
        {
            // reset background to white and refresh to apply changes
            drawing.Clear(Color.White);
            DrawingBox.Refresh();
        }

        /// <summary>
        /// A method which displays a message box which shows the video-link for help on this topic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetVideoLink(object sender, EventArgs e)
        {
            // if there is a question topic
            if (questionRef.Topic != null)
            {
                // copy this video link to clipboard
                Clipboard.SetText(questionRef.Topic.VideoLink);
                // show message box
                MessageBox.Show("Video help link copied to clipboard.", questionRef.Topic.VideoLink, MessageBoxButtons.OK);
            }
        }
    }
}
