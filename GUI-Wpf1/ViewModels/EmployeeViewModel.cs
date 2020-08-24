using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessEntity.ClassModels;
using GUI_Wpf1.ViewModels;
using GUI_Wpf1.Views;
using System.Collections.ObjectModel;

namespace GUI_Wpf1.ViewModels
{
    class EmployeeViewModel
    {
        public static Employee OnlineEmployee;
        private UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private EmployeeView View;
        private bool Hide;

       
        public ObservableCollection<Alumnus> RegistratedAlumnus { get; set; }
        public ObservableCollection<Activity> Activities { get; set; }
        public ObservableCollection<Alumnus> AlumnAtActivity { get; set; }
        public ObservableCollection<SendList> SendLists { get; set; }
        public ObservableCollection<Alumnus> AlumnAtSendList { get; set; }

        public MainCommand addActivity { get; }
        public MainCommand AddSendList { get; }
        public MainCommand SaveAlumn { get; }
        public MainCommand DeleteAlumn { get; }

        public MainCommand ShowActivity { get; }
        public MainCommand SaveActivity { get; }
        public MainCommand DeleteActivity { get; }

        public MainCommand CreateSendList { get; }
        public MainCommand DeleteSendlist { get; }
        public MainCommand DeleteAlumnAtSendList { get; }

        public MainCommand Logout { get; }


        public string loggedInEmployeeName { get; } //{ return OnlineEmployee.Name; } }

        public string SendListName { get; set; }

        public Activity Activity { get; set; }
        public Activity OldActivity { get; set; }

        public Alumnus AlumnusGroup1 { get; set; }
        public Alumnus AlumnusGroup2 { get; set; }
        public Alumnus AlumnusGroup3 { get; set; }

        private SendList sendList;
        public SendList SendList
        {
            get { return sendList; }
            set
            {
                sendList = value;
                ShowSendLists();
            }
        }
        public EmployeeViewModel(EmployeeView view)
        {
            this.View = view;
            Hide = true;
            RegistratedAlumnus = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            Activities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetAllActivitysWithAlumnus());
            SendList = new ObservableCollection<SendList>(UnitOfWork.SendLists.GettAllSendListWithAlumnuses(OnlineEmployee.ID));
        }




        private void AddAlumnToActivity()
        {

        }
        private void AddAlumnToSendList()
        {

        }
        private void SaveAlumnus()
        {

        }
        private void DeleteAlumnus()
        {

        }

        private void ShowAlumnAtActivities()
        {

        }

        private void ShowHideAlumnAtActivity()
        {

        }

        private void SaveActivities()
        {

        }

        private void DeleteAlumnAtActivity()
        {

        }

        private void ShowSendLists()
        {

        }

        private void CreateSendLists()
        {

        }

        private void DeleteAlumns()
        {

        }

        private void DeleteSendLists()
        {

        }

        private void OFF()
        {
            View.Close();
        }




    }
}
    

