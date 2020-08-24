using BusinessEntity.ClassModels;
using BusinessEntity.CM_Interfaces;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form4 : Form
    {
        BusinessManager BusinessManager = new BusinessManager();
        public Form4()
        {
            InitializeComponent();
            message();
            StartUpdate();
           
        }
        public void StartUpdate()
        {
            
            ShowAlumnus();
            ShowActivities();
            ShowMailinglist();
            ShowAlumnsAtActivities();
            ShowAlumnsAtMailinglist();
        }

        private void message()
        {
            MessageBox.Show("log in successful -" + $" Welcome {BusinessManager.GetEmployeeOnline().Fname + " " + BusinessManager.GetEmployeeOnline().Lname}");

           
        }
        // List all alumns
        public void ShowAlumnus() // Eventuellt lägg till To string på personcode
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Social security number").Width = 100;
            listView1.Columns.Add("Firstname").Width = 150;
            listView1.Columns.Add("Lastname").Width = 150;
            listView1.Columns.Add("Emailadress").Width = 200;
            listView1.Columns.Add("Phonenumber").Width = 100;
            listView1.Columns.Add("Qualification").Width = 150;
            listView1.Columns.Add("Exam-date").Width = 100;

            foreach (Alumnus alumnusIndex in BusinessManager.GetAllAlumnuses())
            {
                listView1.Items.Add(new ListViewItem(new string[] { alumnusIndex.PersonCode, alumnusIndex.Fname, alumnusIndex.Lname, alumnusIndex.Email, alumnusIndex.PhoneNumber.ToString(), alumnusIndex.Qualification, alumnusIndex.ExamDate.ToString("yyyy-mm-dd") }));
            }

        }

        // List all activities
        public void ShowActivities()
        {
            listView3.Items.Clear();
            listView3.Columns.Clear();
            listView3.Columns.Add("ID").Width = 25;
            listView3.Columns.Add("Activityname").Width = 150;
            listView3.Columns.Add("Adress").Width = 200;
            listView3.Columns.Add("Category").Width = 100;
            listView3.Columns.Add("Date").Width = 150;

            foreach (Activity activityIndex in BusinessManager.GetAllActivities())
            {
                listView3.Items.Add(new ListViewItem(new string[] { activityIndex.ActivityID.ToString(), activityIndex.Event, activityIndex.Adress, activityIndex.Category, activityIndex.Date.ToString() }));
            }
            
        }

        public void ShowAlumnsAtActivities() 
        {
            listView4.Items.Clear();
            listView4.Columns.Clear();
            if (listView3.SelectedItems.Count !=0)
            {
                listView4.Columns.Add("Firstname").Width = 150;
                listView4.Columns.Add("Lastname").Width = 150;
                listView4.Columns.Add("Social security number").Width = 100;

                foreach (Activity activityIndex1 in BusinessManager.GetAllActivities().Where(x => x.ActivityID == int.Parse(listView3.SelectedItems[0].Text.ToString())))
                {
                    foreach (Alumnus alumnusIndex1 in activityIndex1.Alumnuses)
                    {
                        listView4.Items.Add(new ListViewItem(new string[] { alumnusIndex1.Fname, alumnusIndex1.Lname, alumnusIndex1.PersonCode }));
                    }
                }
                // Verkar inte fungera
            }
        }

        public void ShowMailinglist()
        {
            listView5.Items.Clear();
            listView5.Columns.Clear();
            listView5.Columns.Add("ID").Width = 25;
            listView5.Columns.Add("Mailinglist").Width = 150;

            foreach (SendList sendListIndex in BusinessManager.GetSendListsByID())
            {
                listView5.Items.Add(new ListViewItem(new string[] { sendListIndex.SendListID.ToString(), sendListIndex.Name }));
            }
        }
        public void ShowAlumnsAtMailinglist() 
        {
            listView2.Items.Clear();
            listView2.Columns.Clear();
            if (listView5.SelectedItems.Count !=0 )
            {
                listView2.Columns.Add("Firstname").Width = 150;
                listView2.Columns.Add("Lastname").Width = 150;
                listView2.Columns.Add("Social security number").Width = 100;

                foreach (SendList sendlistIndex1 in BusinessManager.GetSendListsByID().Where(x => x.SendListID == int.Parse(listView5.SelectedItems[0].Text.ToString())))
                {
                    foreach (Alumnus alumnusIndex1 in sendlistIndex1.Alumnuses)
                    {
                        listView2.Items.Add(new ListViewItem(new string[] { alumnusIndex1.Fname, alumnusIndex1.Lname, alumnusIndex1.PersonCode }));
                    }
                }
            }

           
        }


        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count !=0 && listView5.SelectedItems.Count !=0)
            {
                int SendListID = int.Parse(listView5.SelectedItems[0].Text);
                string Personcode = listView1.SelectedItems[0].Text;
                BusinessManager.AddAlumnusSenList(SendListID, Personcode);
                ShowAlumnsAtMailinglist();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count !=0)
            {
                ShowAlumnsAtActivities();
            }
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count !=0)
            {
                ShowAlumnsAtMailinglist();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count !=0)
            {
                string PersonCode = listView1.SelectedItems[0].Text; //ändrat denna
                BusinessManager.DeleteAlumnus2(PersonCode);
                StartUpdate();
            }
        }

        private void buttonDeletemailinglist_Click(object sender, EventArgs e)
        {
           if (listView5.SelectedItems.Count !=0)
            {
                int SendListID = int.Parse(listView5.SelectedItems[0].Text);
                BusinessManager.DeleteSendList(SendListID);
                listView2.Items.Clear();
                listView2.Columns.Clear();
                ShowMailinglist();
            }
        }

        private void buttonDeleteactivity_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                BusinessManager.DeleteActivity(int.Parse(listView3.SelectedItems[0].Text));
                StartUpdate();
            }
        }

        private void buttonDeleteAlumnfromActivity_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0 && listView4.SelectedItems.Count !=0)
            {
                int ActivityID = int.Parse(listView3.SelectedItems[0].Text);
                string PersonCode = listView4.SelectedItems[0].SubItems[2].Text;
                BusinessManager.RemoveAlumnusActivity(ActivityID, PersonCode);
                ShowAlumnsAtActivities();
            }
        }

        private void buttonCreateActivity_Click(object sender, EventArgs e)
        {
            Activity NewActivity = new Activity();
            NewActivity.Event = textBoxActivityname.Text;
            NewActivity.Adress = textBoxaActivityadress.Text;
            NewActivity.Category = textBoxActivitykategory.Text;
            bool Accepts = DateTime.TryParse(textBoxActivitydate.Text, out DateTime Date);

            if (Accepts == true)
            {
                NewActivity.Date = Date;
                BusinessManager.CreateActivity(NewActivity);
                ShowActivities();
                
            }
            textBoxActivityname.Text = string.Empty;
            textBoxaActivityadress.Text = string.Empty;
            textBoxActivitykategory.Text = string.Empty;
            textBoxActivitydate.Text = string.Empty;

        }

        private void ButtonCreatemailinglist_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                BusinessManager.CreateSendList(textBox1.Text);
                ShowMailinglist();
            }
        }

        private void buttondeletefrommailinglist_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count !=0 && listView2.SelectedItems.Count !=0)
            {
                int SendlistID = int.Parse(listView5.SelectedItems[0].Text);
                string PersonCode = listView2.SelectedItems[0].SubItems[2].Text;
                BusinessManager.RemoveAlumnusSendList(SendlistID, PersonCode);
                ShowAlumnsAtMailinglist();
            }
                      
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            IAlumnus temporaryalumn = new Alumnus();

            if (listView1.SelectedItems.Count > 0)
            {
                string OldPersonCode = listView1.SelectedItems[0].Text;

                bool Accept1 = int.TryParse(textBoxPhonenumber.Text, out int Phonenumber);
                bool Accept2 = DateTime.TryParse(textBoxExamDate.Text, out DateTime Examdate);

                List<bool> Accepts = new List<bool> { Accept1, Accept2 }; 

                if (!Accepts.Contains(false))
                {
                    temporaryalumn.Fname = textBoxFname.Text;
                    temporaryalumn.Lname = textBoxLname.Text;
                    temporaryalumn.PersonCode = textBoxPersonCode.Text;
                    temporaryalumn.Qualification = textBoxQuali.Text;
                    temporaryalumn.Email = textBoxEmail.Text;
                    temporaryalumn.PhoneNumber = Phonenumber;
                    temporaryalumn.ExamDate = Examdate;

                    BusinessManager.ChangeAlumnus2(temporaryalumn, OldPersonCode);
                    StartUpdate();

                }

            }
            textBoxFname.Text = string.Empty;
            textBoxLname.Text = string.Empty;
            textBoxPersonCode.Text = string.Empty;
            textBoxQuali.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxPhonenumber.Text = string.Empty;
            textBoxExamDate.Text = string.Empty;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBoxReset.Checked)
            {
                BusinessManager.Reset();
                BusinessManager = new BusinessManager();
                StartUpdate();
            }
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
