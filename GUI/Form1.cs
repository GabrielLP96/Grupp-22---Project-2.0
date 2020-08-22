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
    public partial class Form1 : Form
    {

        BusinessManager businessManager = new BusinessManager();
        ISubject subjectObject = new Subject();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subjectObject.Notify(); 
            string PersonCode = textBox1.Text;
            string Password = textBox2.Text;

            IPerson personOnline = businessManager.Authentication(PersonCode, Password);

            textBox2.Text = string.Empty;

            if (personOnline is Alumnus)
            {
                textBox1.Text = string.Empty;
                new Form3().ShowDialog();
            }
            else if (personOnline is Employee)
            {
                textBox1.Text = string.Empty;
                new Form4().ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password");
            }

            businessManager = new BusinessManager();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }
}
