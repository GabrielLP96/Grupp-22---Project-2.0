using BusinessEntity.ClassModels;
using BusinessEntity.CM_Interfaces;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Message()
        {
            label3.Text = $"Welcome {BusinessManager.GetAlumnusOnline().Fname + BusinessManager.GetAlumnusOnline().Lname}";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
