using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_backend
{
    /// <summary>
    /// A form through which teachers can manage and modify the SOW for each of their classes.
    /// </summary>
    public partial class SchemeOfWorkManager : Form
    {
        private List<Class> classList;
        private List<Topic> classSOWTopicList;
        private List<Topic> topicToAddList;

        private DatabaseHelper dbh = new DatabaseHelper();

        public SchemeOfWorkManager()
        {
            InitializeComponent();

            // fetch all classes from the DB and load these into a drop down
            classList = dbh.GetAllClasses();
            ClassPicker.DataSource = classList.Select(x => x.ClassName).ToArray();
            ClassPicker.SelectedIndex = -1;
            ClassPicker.SelectedIndexChanged += ClassSelected;

            // disable/hide controls since no class has been selected yet
            SaveButton.Enabled = false;
            AddTopicButton.Enabled = false;
            RemoveTopicButton.Enabled = false;
            SuccessMessage.Visible = false;
        }

        /// <summary>
        /// A method to close this form and return to the teacher dashboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// On class selection: fetch class, fetch existing class SOW from DB and display this, then retrieve topics which do not already exist on this SOW.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassSelected(object sender, EventArgs e)
        {
            try
            {
                SuccessMessage.Visible = false;
                SaveButton.Enabled = false;

                // fetch selected class SOW from database
                Class selectedClass = classList[ClassPicker.SelectedIndex];
                classSOWTopicList = dbh.GetClassSOWTopics(selectedClass);

                // list of topics to add contains all topics which are not already on the SOW
                topicToAddList = dbh.GetAllTopics().Where(x => !classSOWTopicList.Select(y => y.TopicId).Contains(x.TopicId)).ToList();
                RefreshTopicListAndPicker();

                SOWLabel.Text = $"{selectedClass.ClassName}'s SOW";

                SaveButton.Enabled = true;
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to test fields for data. Here: only allow the teacher to add a topic to the SOW if a topic has been selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicToAddChosen(object sender, EventArgs e)
        {
            AddTopicButton.Enabled = TopicPicker.SelectedIndex != -1;
        }

        /// <summary>
        /// A method to test fields for data. Here: only allow the teacher to remove a topic from the SOW if a topic from the SOW has been selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SOWTopicSelected(object sender, EventArgs e)
        {
            RemoveTopicButton.Enabled = TopicList.SelectedIndex != -1;
        }

        /// <summary>
        /// On topic addition: fetch topic, then add this to the class topic list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTopicEvent(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            try
            {
                // fetch topic
                Topic topicToAdd = topicToAddList[TopicPicker.SelectedIndex];
                
                // if selected topic not already in sow topic list
                if (!classSOWTopicList.Contains(topicToAdd))
                {
                    // add to class SOW and remove from remaining topic list
                    classSOWTopicList.Add(topicToAdd);
                    topicToAddList.Remove(topicToAdd);
                    RefreshTopicListAndPicker();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }   
        }

        /// <summary>
        /// A method to refresh listboxes to contain current list information.
        /// </summary>
        private void RefreshTopicListAndPicker()
        {
            TopicList.DataSource = classSOWTopicList.Select(x => x.TopicName).ToArray();
            TopicPicker.DataSource = topicToAddList.Select(x => x.TopicName).ToArray();
            TopicPicker.SelectedIndex = -1;

            // refresh buttons
            TopicToAddChosen(null, null);
            SOWTopicSelected(null, null);
        }

        /// <summary>
        /// On topic removal: fetch topic, remove it from the SOW and add it back to the remaining topic list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTopicEvent(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            try
            {
                // if a topic has been selected
                if (TopicList.SelectedIndex != -1)
                {
                    // fetch this topic
                    Topic topicToRemove = classSOWTopicList[TopicList.SelectedIndex];

                    // remove from class SOW and add to remaining topic list
                    classSOWTopicList.Remove(topicToRemove);
                    topicToAddList.Add(topicToRemove);
                    RefreshTopicListAndPicker();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// On SOW save: fetch class and save the new SOW to the DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveEvent(object sender, EventArgs e)
        {
            try
            {
                // if the SOW contains no topics, do not allow this to be saved
                if (classSOWTopicList.Count == 0) throw new Exception("SOW should contain at least one topic.");

                // fetch class and save the new SOW in the DB for this class
                Class selectedClass = classList[ClassPicker.SelectedIndex];
                dbh.ChangeClassSOW(selectedClass, classSOWTopicList);

                // display success message
                SuccessMessage.Visible = true;
                SuccessMessage.Text = $"Saved SOW for {selectedClass.ClassName}";
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }
    }
}
