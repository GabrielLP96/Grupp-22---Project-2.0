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
        }

        private void message()
        {
            MessageBox.Show("log in successful -" + $" Welcome {BusinessManager.GetEmployeeOnline().Fname + " " + BusinessManager.GetEmployeeOnline().Lname}");

           
        }
        public void ShowAlumnus()
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

        public void ShowActivities()
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateActivity_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {

        }
    }
}
