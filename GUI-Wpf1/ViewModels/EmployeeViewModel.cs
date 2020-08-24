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
    class EmployeeViewModel : NotifyPropertyChanged
    {
        public static Employee OnlineEmployee;
        private UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private EmployeeView View;
        private bool Hide;

       
        public ObservableCollection<Alumnus> RegistratedAlumnus { get; set; }
        public ObservableCollection<Activity> Activities { get; set; }
        public ObservableCollection<Alumnus> PickedActivityAlumn { get; set; }
        public ObservableCollection<SendList> SendLists { get; set; }
        public ObservableCollection<Alumnus> pickedSendlistAlumn { get; set; }


        //1
        public MainCommand AddActivity { get; }
        public MainCommand AddSendList { get; }
        public MainCommand SaveAlumn { get; }
        public MainCommand DeleteAlumn { get; }
        //2
        public MainCommand ShowActivity { get; }
        public MainCommand SaveActivity { get; }
        public MainCommand DeleteActivity { get; }
        //3
        public MainCommand CreateSendList { get; }
        public MainCommand DeleteSendlist { get; }
        public MainCommand DeleteAlumnAtSendList { get; }

        public MainCommand Logout { get; }


        public string loggedInEmployeeFirstname { get { return OnlineEmployee.Fname; } }

        public string SendListName { get; set; }

        public Activity PickedActivity { get; set; }
        public Activity OldActivity { get; set; }

        public Alumnus PickedAlumnusGroup1 { get; set; }
        public Alumnus PickedAlumnusGroup2 { get; set; }
        public Alumnus PickedAlumnusGroup3 { get; set; }

        private SendList pickedSendList;
        public SendList PickedSendList
        {
            get { return pickedSendList; }
            set
            {
                pickedSendList = value;
                ShowSendLists();
            }
        }
        public EmployeeViewModel(EmployeeView view)
        {
            this.View = view;
            Hide = true;
            RegistratedAlumnus = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            Activities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetAllActivitysWithAlumnus());
            SendLists = new ObservableCollection<SendList>(UnitOfWork.SendLists.GettAllSendListWithAlumnuses(OnlineEmployee.ID));

            //1
            AddActivity = new MainCommand(AddAlumnToActivity);
            AddSendList = new MainCommand(AddAlumnToSendList);
            DeleteAlumn = new MainCommand(DeleteAlumnus1);
            SaveAlumn = new MainCommand(SaveAlumnus);

            //2
            ShowActivity = new MainCommand(ShowHideAlumnAtActivity);
            SaveActivity = new MainCommand(SaveActivities);
            DeleteActivity = new MainCommand(DeleteAlumnAtActivity);
            //3 
            CreateSendList = new MainCommand(CreateSendLists);
            DeleteAlumnAtSendList = new MainCommand(DeleteAlumns2);
            DeleteSendlist = new MainCommand(DeleteSendLists);

        }



        //1
        private void AddAlumnToActivity()
        {
            if(PickedAlumnusGroup1 != null && PickedActivity !=null)
                
                if(PickedActivity.Alumnuses == null)
                {
                    SaveActivities();
                    PickedActivity = UnitOfWork.Activities.GetAlumnusesActivity(PickedActivity.ActivityID);
                  
                }
            PickedActivity.Alumnuses.Add(PickedAlumnusGroup1);
            UnitOfWork.Save();

            PickedActivityAlumn = new ObservableCollection<Alumnus>(PickedActivity.Alumnuses);
            OnPropertyChanged("PickedActivityAlumn");
            
            
        }



        private void AddAlumnToSendList()
        {
            if (PickedAlumnusGroup1 != null && pickedSendList !=null)
            {
                pickedSendList.Alumnuses.Add(PickedAlumnusGroup1);
                UnitOfWork.Save();

                pickedSendlistAlumn = new ObservableCollection<Alumnus>(PickedSendList.Alumnuses);
                OnPropertyChanged("pickedSendlistAlumn");
            }


        }
        private void SaveAlumnus()
        {
            foreach (Alumnus alumnusIndex in RegistratedAlumnus)
            {
                UnitOfWork.Alumnuses.AddUppdate(alumnusIndex);
            }
            UnitOfWork.Save();
        }

        private void DeleteAlumnus1()
        {
            bool controller = UnitOfWork.Alumnuses.GetAll().Where(x => x == PickedAlumnusGroup1).Any();

            if (controller == true)
            {
                UnitOfWork.Alumnuses.Remover(PickedAlumnusGroup1);
                UnitOfWork.Save();
            }
            RegistratedAlumnus = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            OnPropertyChanged("RegistratedAlumnus");

            ShowAlumnAtActivities();
            ShowSendLists();
        }





        //2
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








        //3
        private void ShowSendLists()
        {

        }

        private void CreateSendLists()
        {

        }

        private void DeleteAlumns2()
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
    

