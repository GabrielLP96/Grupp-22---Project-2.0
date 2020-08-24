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
using System.Windows.Controls;

namespace GUI_Wpf1.ViewModels
{
    class EmployeeViewModel : NotifyPropertyChanged
    {
        public static Employee OnlineEmployee;
        private UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private EmployeeView View;
        private bool Hide;

       
        public ObservableCollection<Alumnus> RegistratedAlumnus { get; set; }
        public ObservableCollection<Activity> AvailableActivities { get; set; }
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

        public MainCommand LogOut { get; }


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
       // public EmployeeViewModel(EmployeeView view) // ingen referens?
        public EmployeeViewModel(EmployeeView view)
        {
            this.View = view;
            Hide = true;
            RegistratedAlumnus = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            AvailableActivities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetAllActivitysWithAlumnus());
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

            LogOut = new MainCommand(CloseView);

            
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
            if (PickedAlumnusGroup1 != null && PickedSendList !=null)
            {
                PickedSendList.Alumnuses.Add(PickedAlumnusGroup1);
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
            if(PickedActivity != null && PickedActivity.Alumnuses !=null)
            {
                PickedActivityAlumn = new ObservableCollection<Alumnus>(PickedActivity.Alumnuses);
                OnPropertyChanged("PickedActivityAlumn");
                Hide = false;
            }
        }

        private void ShowHideAlumnAtActivity()
        {
            if (PickedActivity != OldActivity && PickedActivity != null && PickedActivity.Alumnuses !=null)
            {
                PickedActivityAlumn = new ObservableCollection<Alumnus>(PickedActivity.Alumnuses);
                Hide = false;
            }
            else if (Hide == false)
            {
                PickedActivityAlumn = null;
                Hide = true;
            }
            else if (PickedActivity != null && PickedActivity.Alumnuses != null)
            {
                PickedActivityAlumn = new ObservableCollection<Alumnus>(PickedActivity.Alumnuses);
                Hide = false;
            }
            OnPropertyChanged("PickedActivityAlumn");
            OldActivity = PickedActivity;
        }

        private void SaveActivities()
        {
            foreach (Activity activityIndex in AvailableActivities)
            {
                activityIndex.Employee = UnitOfWork.Employees.Get(OnlineEmployee.ID);
                UnitOfWork.Activities.AddUppdate(activityIndex);
            }
            UnitOfWork.Save();
        }

        private void DeleteAlumnAtActivity()
        {
            if(PickedActivityAlumn != null && !PickedActivityAlumn.Any())
            {
                Hide = true;
            }
            if (PickedAlumnusGroup2 != null && Hide == false)
            {
                PickedActivity.Alumnuses.Remove(PickedAlumnusGroup2);
                UnitOfWork.Save();

                PickedActivityAlumn = new ObservableCollection<Alumnus>(PickedActivity.Alumnuses);
                OnPropertyChanged("PickedActivityAlumn");
            }
            else if (PickedActivity != null && Hide == true)
            {
                bool controller = UnitOfWork.Activities.GetAll().Where(x => x == PickedActivity).Any();

                if (controller == true)
                {
                    UnitOfWork.Activities.Remover(PickedActivity);
                    UnitOfWork.Save();
                }
                AvailableActivities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetAll());
                OnPropertyChanged("AvailableActivities");

            }
        }








        //3
        private void ShowSendLists()
        {
            if(PickedSendList !=null)
            {
                pickedSendlistAlumn = new ObservableCollection<Alumnus>(UnitOfWork.SendLists.Get(PickedSendList.SendListID).Alumnuses);
                OnPropertyChanged("pickedSendlistAlumn");
            }
        }

        private void CreateSendLists()
        {
            if(SendListName != null && SendListName != string.Empty)
            {
                SendList NewSendList = new SendList();
                NewSendList.Employee = UnitOfWork.Employees.Get(OnlineEmployee.ID);
                NewSendList.Name = SendListName;

                UnitOfWork.SendLists.Add(NewSendList);
                UnitOfWork.Save();

                SendLists = new ObservableCollection<SendList>(UnitOfWork.SendLists.GettAllSendListWithAlumnuses(OnlineEmployee.ID));
                OnPropertyChanged("SendLists");

                SendListName = string.Empty;
                OnPropertyChanged("SendListName");
            }
        }

        private void DeleteAlumns2()
        {
            if (PickedSendList != null && PickedAlumnusGroup3 != null )
            {
                UnitOfWork.SendLists.Get(PickedSendList.SendListID).Alumnuses.Remove(PickedAlumnusGroup3);
                UnitOfWork.Save();

                PickedSendList = UnitOfWork.SendLists.Get(PickedSendList.SendListID);
                OnPropertyChanged("pickedSendList");
            }
        }

        private void DeleteSendLists()
        {
            if (PickedSendList != null)
            {
                UnitOfWork.SendLists.Remover(UnitOfWork.SendLists.Get(PickedSendList.SendListID));
                UnitOfWork.Save();

                SendLists = new ObservableCollection<SendList>(UnitOfWork.SendLists.GettAllSendListWithAlumnuses(OnlineEmployee.ID));
                pickedSendlistAlumn = null;
                OnPropertyChanged("SendLists");
                OnPropertyChanged("pickedSendlistAlumn");
            }
        }

        private void CloseView()
        {
            View.Close();
        }




    }
}
    

