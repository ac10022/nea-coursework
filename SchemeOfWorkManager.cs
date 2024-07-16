using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_prototype_full
{
    public partial class SchemeOfWorkManager : Form
    {
        private List<Class> classList;
        private List<Topic> classSOWTopicList;
        private List<Topic> topicToAddList;

        private DatabaseHelper dbh = new DatabaseHelper();

        public SchemeOfWorkManager()
        {
            InitializeComponent();

            classList = dbh.GetAllClasses();
            ClassPicker.DataSource = classList.Select(x => x.ClassName).ToArray();
            ClassPicker.SelectedIndex = -1;

            ClassPicker.SelectedIndexChanged += ClassSelected;

            SaveButton.Enabled = false;
            AddTopicButton.Enabled = false;
            RemoveTopicButton.Enabled = false;
            SuccessMessage.Visible = false;
        }

        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        private void ClassSelected(object sender, EventArgs e)
        {
            try
            {
                SuccessMessage.Visible = false;
                SaveButton.Enabled = false;

                Class selectedClass = classList[ClassPicker.SelectedIndex];
                classSOWTopicList = dbh.GetClassSOWTopics(selectedClass);

                // list of topics to add contains all topics which are not already on the sow
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

        private void TopicToAddChosen(object sender, EventArgs e)
        {
            AddTopicButton.Enabled = TopicPicker.SelectedIndex != -1;
        }

        private void SOWTopicSelected(object sender, EventArgs e)
        {
            RemoveTopicButton.Enabled = TopicList.SelectedIndex != -1;
        }

        private void AddTopicEvent(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            try
            {
                Topic topicToAdd = topicToAddList[TopicPicker.SelectedIndex];
                // if selected topic not already in sow topic list
                if (!classSOWTopicList.Contains(topicToAdd))
                {
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

        private void RefreshTopicListAndPicker()
        {
            TopicList.DataSource = classSOWTopicList.Select(x => x.TopicName).ToArray();
            TopicPicker.DataSource = topicToAddList.Select(x => x.TopicName).ToArray();
            TopicPicker.SelectedIndex = -1;

            // refresh buttons
            TopicToAddChosen(null, null);
            SOWTopicSelected(null, null);
        }

        private void RemoveTopicEvent(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            try
            {
                if (TopicList.SelectedIndex != -1)
                {
                    Topic topicToRemove = classSOWTopicList[TopicList.SelectedIndex];
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

        private void SaveEvent(object sender, EventArgs e)
        {
            try
            {
                if (classSOWTopicList.Count == 0) throw new Exception("SOW should contain at least one topic.");
                Class selectedClass = classList[ClassPicker.SelectedIndex];
                dbh.ChangeClassSOW(selectedClass, classSOWTopicList);
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
