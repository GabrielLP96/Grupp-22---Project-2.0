using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity.ClassModels;
using DataLayer;
using GUI_Wpf1.Views;

namespace GUI_Wpf1.ViewModels
{
    class AlumnusViewModel : NotifyPropertyChanged
    {
        public static Alumnus AlumnusOnline;
        private UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private AlumnusView view;

        public ObservableCollection<Activity> AvailableActivities { get; set; }
        public ObservableCollection<Activity> BookedActivities { get; set; }
        
        public MainCommand Book { get; }
        public MainCommand CancelBooking { get; }
        public MainCommand Change { get; }
        public MainCommand LogOut { get; }

        public string AlumnusOnlineFirstname { get { return AlumnusOnline.Fname; } }
        public string AlumnusOnlineLastname { get { return AlumnusOnline.Lname; } }
        public Activity PickedBookedActivity { get; set; }
        public Activity PickedCanceledBookedAktivity { get; set; }

        public AlumnusViewModel(AlumnusView view)
        {
            this.view = view;
            AvailableActivities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetAll());
            BookedActivities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetActivityWithAlumnus(AlumnusOnline.ID));
            Book = new MainCommand(BookActivity);
            CancelBooking = new MainCommand(CanceledAktivity);
            Change = new MainCommand(ChangeAlumnus);
            LogOut = new MainCommand(CloseVy);
        }

        private void BookActivity()
        {
            if (PickedBookedActivity != null)
            {
                UnitOfWork.Alumnuses.GetAlumnusActivity(AlumnusOnline.ID).Activities.Add(PickedBookedActivity);
                UnitOfWork.Save();

                BookedActivities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetActivityWithAlumnus(AlumnusOnline.ID));
                OnPropertyChanged("BookedAktivities");
            }
        }

        private void CanceledAktivity()
        {
            if (PickedCanceledBookedAktivity !=null)
            {
                UnitOfWork.Alumnuses.GetAlumnusActivity(AlumnusOnline.ID).Activities.Remove(PickedBookedActivity);
                UnitOfWork.Save();

                BookedActivities = new ObservableCollection<Activity>(UnitOfWork.Activities.GetActivityWithAlumnus(AlumnusOnline.ID));
                OnPropertyChanged("BookedAktivities");
            }
        }
        private void ChangeAlumnus()
        {
            ChangeViewModel.AlumnusOnline = AlumnusOnline;
            ChangeView change = new ChangeView();
            change.Show();
            CloseVy();
        }

        private void CloseVy()
        {
            view.Close();
        }
    }
}
