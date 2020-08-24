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
    class RegisterViewModel : NotifyPropertyChanged
    {
        private UnitOfWork UnitOfWork = new UnitOfWork(new DataContext());
        private RegisterView view;

        public MainCommand Register { get; }
        public MainCommand Cancel { get; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Qualification { get; set; }
        public string ExamDate { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
        public bool Consent { get; set; }
        public string Information { get; set; }


        public RegisterViewModel(RegisterView view)
        {
            this.view = view;
            Register = new MainCommand(CreateAlumnus);
            Cancel = new MainCommand(CloseView);
        }

        private void CreateAlumnus()
        {
            List<string> vs1 = new List<string>() { Firstname, Lastname, PersonCode, Email, PhoneNumber, Qualification, ExamDate, Password, Confirm };
            if (!vs1.Contains(string.Empty))
            {
                bool Accepted1 = int.TryParse(this.PhoneNumber, out int Phonenumber);
                bool Accepted2 = DateTime.TryParse(this.ExamDate, out DateTime ExamDate);
                List<bool> vs2 = new List<bool> { Accepted1, Accepted2, Consent};
                if (!vs2.Contains(false) && Password == Confirm)
                {
                    Alumnus alumnus = new Alumnus();
                    alumnus.Fname = Firstname;
                    alumnus.Lname = Lastname;
                    alumnus.PersonCode = PersonCode;
                    alumnus.Email = Email;
                    alumnus.PhoneNumber = Phonenumber;
                    alumnus.Qualification = Qualification;
                    alumnus.ExamDate = ExamDate;
                    alumnus.Password = Password;
                    UnitOfWork.Alumnuses.Add(alumnus);
                    UnitOfWork.Save();
                    CloseView();
                }
                else
                {
                    Information = "Something whent wrong";
                    OnPropertyChanged("Information");
                }
            }
            else
            {
                Information = "Make sure you filled everything in";
                OnPropertyChanged("Information");
            }
        }
        private void CloseView()
        {
            view.Close();
        }
    }
}
