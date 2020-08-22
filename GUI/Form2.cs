using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity.ClassModels;
using BusinessEntity.CM_Interfaces;
using BusinessLayer;



namespace GUI
{
    public partial class Form2 : Form
    {
        BusinessManager BusinessManager = new BusinessManager();
        ISubject subject = new Subject();

        public Form2()
        {
            InitializeComponent();
            alumnusLoggedIn();
            
        }

        public void alumnusLoggedIn()
        {
            IAlumnus LoggedInAlumnus = BusinessManager.GetAlumnusOnline();
            if (LoggedInAlumnus != null)
            {
                label1.Text = "Change personal info";
                button1.Text = "Change";
                textBox1.Text = LoggedInAlumnus.Fname;
                textBox2.Text = LoggedInAlumnus.Lname;
                textBox3.Text = LoggedInAlumnus.PersonCode;
                textBox4.Text = LoggedInAlumnus.Email;
                textBox5.Text = LoggedInAlumnus.PhoneNumber.ToString();
                textBox6.Text = LoggedInAlumnus.Qualification;
                textBox7.Text = LoggedInAlumnus.ExamDate.ToString("yyyy-mm-dd");


                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string Fname = textBox1.Text;
            string Lname = textBox2.Text;
            string Email = textBox4.Text;
            string Qualification = textBox6.Text;
            string PersonCode = textBox3.Text;

            
            bool Accept1 = int.TryParse(textBox5.Text, out int PhoneNumber);
            bool Accept2 = DateTime.TryParse(textBox7.Text, out DateTime ExamDate);
          
          

            bool Accept3 = false;
            bool Accept4 = false;

            string Password = textBox8.Text;
            string RepeatPassword = textBox9.Text;
            if (Password == RepeatPassword && Password !="")
            {
                Accept3 = true;
            }

            if (checkBox1.Checked)
            {
                Accept4 = true;
            }

            List<bool> Accepts = new List<bool> { Accept1, Accept2, Accept3, Accept4,};
            if (!Accepts.Contains(false) && BusinessManager.GetAlumnusOnline() != null)
            {
                IAlumnus TemporaryAlumn = new Alumnus();
                TemporaryAlumn.Fname = Fname;
                TemporaryAlumn.Lname = Lname;
                TemporaryAlumn.PersonCode = PersonCode;
                TemporaryAlumn.Email = Email;
                TemporaryAlumn.PhoneNumber = PhoneNumber;
                TemporaryAlumn.Password = Password;
                TemporaryAlumn.Qualification = Qualification;
                TemporaryAlumn.ExamDate = ExamDate;
                BusinessManager.ChangeAlumnus(TemporaryAlumn);
                Close();
            }
            else if (!Accepts.Contains(false))
            {
                Alumnus NewAlumnus = new Alumnus();
                NewAlumnus.Fname = Fname;
                NewAlumnus.Lname = Lname;
                NewAlumnus.PersonCode = PersonCode;
                NewAlumnus.Email = Email;
                NewAlumnus.PhoneNumber = PhoneNumber;
                NewAlumnus.Password = Password;
                NewAlumnus.Qualification = Qualification;
                NewAlumnus.ExamDate = ExamDate;

                bool Accept6 = BusinessManager.CreateAlumnus(NewAlumnus);
                if (Accept6 == false)
                {
                    MessageBox.Show("User alredy registrated, please try again");
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
