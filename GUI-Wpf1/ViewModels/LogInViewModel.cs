using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity.ClassModels;
using System.Collections.ObjectModel;
using BusinessEntity.CM_Interfaces;

namespace GUI_Wpf1.ViewModels
{
    class LogInViewModel : NotifyPropertyChanged
    {
        UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private MainWindow view;

        ObservableCollection<Alumnus> Alumnuses { get; set; }
        ObservableCollection<Employee> Employees { get; set; }


        public MainCommand LogIn { get; }
        public MainCommand Register { get; }

        public string WrongMessage { get; set; } = string.Empty;
        public string PasswordBox { get; set; } = string.Empty;
        public string personCodeBox = string.Empty;

        public string PersonCodeBox
        {
            get
            {
                return personCodeBox;
            }
            set
            {
                personCodeBox = value;
                
            }
        }

        public string WelcomeMessage
        {
            get
            {
                IPerson person;
                person = Alumnuses.Where(x => x.PersonCode.ToString() == personCodeBox).FirstOrDefault();
                if(person is Alumnus)
                {
                    return person.Fname;
                }
                person = Alumnuses.Where(x => x.PersonCode.ToString() == personCodeBox).FirstOrDefault();
                if (person is Employee)
                {
                    return person.Fname;
                }
                else
                {
                    return string.Empty;
                }
            }
        }


        public LogInViewModel(MainWindow view)
        {
            this.view = view;
            Alumnuses = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            Employees = new ObservableCollection<Employee>(UnitOfWork.Employees.GetAll());
            LogIn = new MainCommand();
        }


        private void Update()
        {
            UnitOfWork = new UnitOfWork(new DataContext());
            Alumnuses = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            Employees = new ObservableCollection<Employee>(UnitOfWork.Employees.GetAll());
        }

        private void InPutControll()
        {
            if (personCodeBox.ToCharArray().Where(x => !char.IsDigit(x)).Any())
            {
                WrongMessage = "May only contain numbers";
            }
            else if (personCodeBox != string.Empty)
            {
                WrongMessage = string.Empty;
            }
            OnPropertyChanged("WrongMessage");
        }

        private void Authentication()
        { 
            if (long.TryParse(PersonCodeBox, out long PersonCode) && PasswordBox !=null)
            {
                Alumnus alumnus = Alumnuses.Where(x => x.PersonCode = PersonCode && x.Password == PasswordBox).FirstOrDefault();
            }
        }
    }
}
