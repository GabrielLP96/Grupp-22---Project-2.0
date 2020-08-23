using BusinessEntity.ClassModels;
using System;
using System.Windows.Forms;
using BusinessLayer;

namespace GUI
{
    public partial class Form3 : Form
    {
        BusinessManager BusinessManager = new BusinessManager();
        public Form3()
        {
            InitializeComponent();
            Message();
            ShowActivitis();
            ShowBookedActivitis();
        }

        public void ShowActivitis()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("ID").Width = 25;
            listView1.Columns.Add("Event").Width = 150;
            listView1.Columns.Add("Address").Width = 200;
            listView1.Columns.Add("Date").Width = 150;
            listView1.Columns.Add("Category").Width = 100;

            foreach(Activity activity in BusinessManager.GetAllActivities())
            {
                listView1.Items.Add(new ListViewItem(new string[] { activity.ActivityID.ToString(), activity.Event, activity.Adress, activity.Date.ToString(), activity.Category }));
            }
        }

        public void ShowBookedActivitis()
        {
            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.Columns.Add("ID").Width = 25;
            listView2.Columns.Add("Event").Width = 150;
            listView2.Columns.Add("Address").Width = 200;
            listView2.Columns.Add("Date").Width = 150;
            listView2.Columns.Add("Category").Width = 100;

            foreach (Activity activity in BusinessManager.GetBookedActivities())
            {
                listView2.Items.Add(new ListViewItem(new string[] { activity.ActivityID.ToString(), activity.Event, activity.Adress, activity.Date.ToString(), activity.Category }));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count !=0)
            {
                bool Confirmed = BusinessManager.CreateBooking(int.Parse(listView1.SelectedItems[0].Text));
                if (Confirmed == true)
                {
                    MessageBox.Show("Thank you for your booking, the booking is now completed");
                    ShowBookedActivitis();
                }
                else
                {
                    MessageBox.Show("You've already made the booking before.");
                }
            }
            else
            {
                MessageBox.Show("You need to select an activity to be able to book");
            }
        }
        private void Message()
        {
            label3.Text = $"{BusinessManager.GetAlumnusOnline().Fname + " " + BusinessManager.GetAlumnusOnline().Lname}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Change = new Form2();
            Change.Text = "Change";
            Change.ShowDialog();
            BusinessManager = new BusinessManager();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
