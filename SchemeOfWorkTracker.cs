using nea_ui_testing;
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
    /// <summary>
    /// A form through which a student can view the schemes-of-work of their classes.
    /// </summary>
    public partial class SchemeOfWorkTracker : Form
    {
        private List<Class> studentClasses;
        private List<Topic> classSOW;

        private DatabaseHelper dbh = new DatabaseHelper();

        public SchemeOfWorkTracker()
        {
            InitializeComponent();

            // fetch the classes the student is in, allow the student to switch between the SOWs of these classes
            studentClasses = dbh.GetClassesOfStudent(Program.loggedInUser);
            ClassPicker.DataSource = studentClasses.Select(x => x.ClassName).ToArray();

            // remove selection
            ClassPicker.SelectedIndex = -1;
            ClassPicker.SelectedIndexChanged += ClassSelected;
        }

        /// <summary>
        /// On class selection: get the SOW of the selected class, then display each topic of this SOW in the SOW display. Load student SOW data (i.e. the topics they have checked off previously)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassSelected(object sender, EventArgs e)
        {
            if (ClassPicker.SelectedIndex != -1)
            {
                SOWDisplay.Items.Clear();

                // fetch selected classes and get the corresponding SOW
                Class selectedClass = studentClasses[ClassPicker.SelectedIndex];
                classSOW = dbh.GetClassSOWTopics(selectedClass);

                // add each topic to the SOW display
                foreach (Topic topic in classSOW)
                {
                    SOWDisplay.Items.Add(topic.TopicName);
                }

                // load student SOW data
                List<int> studentChecklistData = dbh.GetStudentChecklistData(selectedClass, Program.loggedInUser);

                // if checklist data exists and is up to date (no. of elements is the same for both lists)
                if (studentChecklistData != null && studentChecklistData.Count == classSOW.Count)
                {
                    for (int i = 0; i < studentChecklistData.Count; i++)
                    {
                        // tick off each item the student has checked off previously
                        if (studentChecklistData[i] == 1)
                            SOWDisplay.SetItemChecked(i, true);
                    }
                }
            }

            SOWDisplay.ItemCheck += ItemCheckedEvent;
        }

        /// <summary>
        /// On checking a topic off: update the seralised data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCheckedEvent(object sender, ItemCheckEventArgs e)
        {
            // fetch selected class and produce a new set of seralised data
            Class selectedClass = studentClasses[ClassPicker.SelectedIndex];
            string serialisedChecklistData = SerialiseChecklistData();

            // update seralised SOW data in the DB
            dbh.UpdateSeralisedSOWData(selectedClass, Program.loggedInUser, serialisedChecklistData);
        }

        /// <summary>
        /// A method to fetch all items from a SOW, see if they're checked off, and produce a seralised binary string to store this information. If a topic is checked off, produce a 1, if not, produce a 0.
        /// </summary>
        /// <returns>A seralised binary string.</returns>
        private string SerialiseChecklistData()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < SOWDisplay.Items.Count; i++)
            {
                if (SOWDisplay.GetItemChecked(i)) sb.Append("1");
                else sb.Append("0");
            }
            return sb.ToString();
        }
    }
}