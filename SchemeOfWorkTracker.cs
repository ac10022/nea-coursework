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
    public partial class SchemeOfWorkTracker : Form
    {
        private List<Class> studentClasses;
        private List<Topic> classSOW;

        private DatabaseHelper dbh = new DatabaseHelper();

        public SchemeOfWorkTracker()
        {
            InitializeComponent();

            studentClasses = dbh.GetClassesOfStudent(Program.loggedInUser);
            ClassPicker.DataSource = studentClasses.Select(x => x.ClassName).ToArray();
            ClassPicker.SelectedIndex = -1;
            ClassPicker.SelectedIndexChanged += ClassSelected;
        }

        private void ClassSelected(object sender, EventArgs e)
        {
            if (ClassPicker.SelectedIndex != -1)
            {
                SOWDisplay.Items.Clear();

                Class selectedClass = studentClasses[ClassPicker.SelectedIndex];
                classSOW = dbh.GetClassSOWTopics(selectedClass);

                foreach (Topic topic in classSOW)
                {
                    SOWDisplay.Items.Add(topic.TopicName);
                }

                List<int> studentChecklistData = dbh.GetStudentChecklistData(selectedClass, Program.loggedInUser);

                // if checklist data exists and is up to date (no. of elements is the same for both lists)
                if (studentChecklistData != null && studentChecklistData.Count == classSOW.Count)
                {
                    for (int i = 0; i < studentChecklistData.Count; i++)
                    {
                        if (studentChecklistData[i] == 1)
                            SOWDisplay.SetItemChecked(i, true);
                    }
                }
            }

            SOWDisplay.ItemCheck += ItemCheckedEvent;
        }

        private void ItemCheckedEvent(object sender, ItemCheckEventArgs e)
        {
            Console.WriteLine("checked");

            Class selectedClass = studentClasses[ClassPicker.SelectedIndex];
            string serialisedChecklistData = SerialiseChecklistData();

            dbh.UpdateSeralisedSOWData(selectedClass, Program.loggedInUser, serialisedChecklistData);
        }

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
