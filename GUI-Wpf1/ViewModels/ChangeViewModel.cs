using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity.ClassModels;
using DataLayer;
using GUI_Wpf1.Views;

namespace GUI_Wpf1.ViewModels
{
    class ChangeViewModel : NotifyPropertyChanged
    {
        public static Alumnus AlumnusOnline;
        private UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private ChangeView view;

        public MainCommand Change { get; }
        public MainCommand Cancel { get; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonCode { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string ExamDate { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
        public string Information { get; set; }


        public ChangeViewModel(ChangeView view)
        {
            this.view = view;
            Firstname
        }

    }
}
