using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity.ClassModels;
using System.Collections.ObjectModel;
using BusinessEntity.CM_Interfaces;
using System.Windows.Controls;
using DataLayer.Repositories;
using GUI_Wpf1.Views;
using System.Runtime.Remoting.Services;

namespace GUI_Wpf1.ViewModels
{
    class LogInViewModel : NotifyPropertyChanged
    {
        UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private MainWindow view;

        ObservableCollection<Alumnus> Alumnuses { get; set; }
        ObservableCollection<Employee> Employees { get; set; }


        public MainCommand LogIn { get; }
        public MainCommand Registration { get; }

        public string ErrorMessage { get; set; } = string.Empty;
        public string PasswordBox { get; set; } = string.Empty;
        public string PersonCodeBox { get; set; } = string.Empty;

        //public string PersonCodeBox
        //{
        //    get
        //    {
        //        return personCodeBox;
        //    }
        //    set
        //    {
        //        personCodeBox = value;
                
        //    }
        //}

        //public string WelcomeMessage
        //{
        //    get
        //    {
        //        IPerson person;
        //        person = Alumnuses.Where(x => x.PersonCode.ToString() == personCodeBox).FirstOrDefault();
        //        if(person is Alumnus)
        //        {
        //            return person.Fname;
        //        }
        //        person = Alumnuses.Where(x => x.PersonCode.ToString() == personCodeBox).FirstOrDefault();
        //        if (person is Employee)
        //        {
        //            return person.Fname;
        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }
        //    }
        //}


        public LogInViewModel(MainWindow view)
        {
            this.view = view;
            Alumnuses = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            Employees = new ObservableCollection<Employee>(UnitOfWork.Employees.GetAll());
            LogIn = new MainCommand(Authentication);
            Registration = new MainCommand(CreateUser);
        }

        public LogInViewModel()
        {
            PersonCodeBox = "hej";
        }

        private void Update()
        {
            UnitOfWork = new UnitOfWork(new DataContext());
            Alumnuses = new ObservableCollection<Alumnus>(UnitOfWork.Alumnuses.GetAll());
            Employees = new ObservableCollection<Employee>(UnitOfWork.Employees.GetAll());
        }

        private void InPutControll()
        {
            if (PersonCodeBox.ToCharArray().Where(x => !char.IsDigit(x)).Any())
            {
                ErrorMessage = "May only contain numbers";
            }
            else if (PersonCodeBox != string.Empty)
            {
                ErrorMessage = string.Empty;
            }
            OnPropertyChanged("ErrorMessage");
        }

        private void Authentication()
        {
            Alumnus Alumnus = Alumnuses.Where(x => x.PersonCode == PersonCodeBox && x.Password == PasswordBox).FirstOrDefault();
            Employee employee = Employees.Where(x => x.PersonCode == PersonCodeBox && x.Password == PasswordBox).FirstOrDefault();


            if (Alumnus is Alumnus)
            {
                AlumnusViewModel.AlumnusOnline = Alumnus;
                AlumnusView Oppen = new AlumnusView();
                Oppen.Show();
            }
            else if (employee is Employee)
            {
                EmployeeViewModel.OnlineEmployee = employee;
                EmployeeView Open = new EmployeeView();
                Open.Show();
            }
            else
            {
                ErrorMessage = "Incorrect login";
            }
            PersonCodeBox = string.Empty;
            PasswordBox = string.Empty;
            OnPropertyChanged("PersonCodeBox");
            OnPropertyChanged("PasswordBox");
            OnPropertyChanged("ErrorMessage");
        }
       private void CreateUser()
        {
            RegisterView view = new RegisterView();
            view.Show();
        }
    }
}
