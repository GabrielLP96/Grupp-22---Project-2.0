using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataLayer;
using DataLayer.Repositories;
using BusinessEntity.ClassModels;
using BusinessEntity.CM_Interfaces;


namespace BusinessLayer
{
    public class BusinessManager
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new DataContext());
        static IPerson PersonOnline;

        public BusinessManager()
        {
            if (!unitOfWork.Employees.GetAll().Any())
            {
                unitOfWork.Reset();
            }
        }
        public void Reset ()
        {
            unitOfWork = new UnitOfWork(new DataContext());
            unitOfWork.Reset();
        }

        // Get
        public IPerson Authentication(string PersonCode, string Password) //form1
        {
            PersonOnline = unitOfWork.Alumnuses.GetAll().Where(x => x.PersonCode == PersonCode && x.Password == Password).FirstOrDefault();
            if (PersonOnline == null)
            {
                PersonOnline = unitOfWork.Employees.GetAll().Where(x => x.PersonCode == PersonCode && x.Password == Password).FirstOrDefault();
            }
            return PersonOnline;
        }

        public IAlumnus GetAlumnusOnline() // form 2 and form 3
        {
            if(PersonOnline != null)
            {
                return unitOfWork.Alumnuses.Get(PersonOnline.ID);
            }
            return null;
        }
        public IEmployee GetEmployeeOnline() // form 4
        {
            if(PersonOnline != null)
            {
                return unitOfWork.Employees.Get(PersonOnline.ID);
            }
            return null;
        }
        public List<Activity> GetAllActivities() //form 3-4
        {
            return unitOfWork.Activities.GetAllActivitysWithAlumnus();
        }
        public List<Activity> GetBookedActivities() //form3
        {
            return unitOfWork.Activities.GetActivityWithAlumnus(PersonOnline.ID);
        }
        public List<Alumnus> GetAllAlumnuses() //form4
        {
            return unitOfWork.Alumnuses.GetAll();
        }
        public List<SendList>GetSendListsByID() //form4
        {
            return unitOfWork.SendLists.GettAllSendListWithAlumnuses(PersonOnline.ID);
        }

        //Create
        public bool CreateAlumnus(Alumnus NewAlumnus) //form 2
        {
            if (!unitOfWork.Alumnuses.GetAll().Any(x => x.PersonCode == NewAlumnus.PersonCode))
            {
                unitOfWork.Alumnuses.Add(NewAlumnus);
                unitOfWork.Save();
                return true;
            }
            return false;
        }
        public void CreateSendList(string Name) //form4
        {
            Employee Employee = unitOfWork.Employees.Get(PersonOnline.ID);
            SendList NewSendList = new SendList();
            NewSendList.Name = Name;
            NewSendList.Employee = Employee;
            unitOfWork.SendLists.Add(NewSendList);
            unitOfWork.Save();
        }
        public void CreateActivity(Activity NewActivity) // form4
        {
            NewActivity.Employee = unitOfWork.Employees.Get(PersonOnline.ID);
            unitOfWork.Activities.Add(NewActivity);
            unitOfWork.Save();
        }

        //Change
        public void ChangeAlumnus(IAlumnus TemporaryAlumn) //form 2
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.Get(PersonOnline.ID);
            alumnusX.Fname = TemporaryAlumn.Fname;
            alumnusX.Lname = TemporaryAlumn.Lname;
            alumnusX.PersonCode = TemporaryAlumn.PersonCode;
            alumnusX.Email = TemporaryAlumn.Email;
            alumnusX.Password = TemporaryAlumn.Password;
            alumnusX.Qualification = TemporaryAlumn.Qualification;
            alumnusX.ExamDate = TemporaryAlumn.ExamDate;
            unitOfWork.Save();
        }
        public void ChangeAlumnus2(IAlumnus alumnus, string PersonCode) // form4
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.GetAlumnus(PersonCode);
            alumnusX.Fname = alumnus.Fname;
            alumnusX.Lname = alumnus.Lname;
            alumnusX.PersonCode = alumnus.PersonCode;
            alumnusX.Email = alumnus.Email;
            alumnusX.Password = alumnus.Password;
            alumnusX.Qualification = alumnus.Qualification;
            alumnusX.ExamDate = alumnus.ExamDate;
            unitOfWork.Save();
        }
        public void ChangeActivity(IActivity activity) // form 4
        {
            Activity activityX = unitOfWork.Activities.Get(activity.ActivityID);
            activityX.Event = activity.Event;
            activityX.Adress = activity.Adress;
            activityX.Category = activity.Category;
            activityX.Date = activity.Date;
            activityX.Employee = unitOfWork.Employees.Get(PersonOnline.ID);
            unitOfWork.Save();
        }

        //Delete
        public void DeleteAlumnus() //form 3
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.Get(PersonOnline.ID);
            unitOfWork.Alumnuses.Remover(alumnusX);
            unitOfWork.Save();
        }
        public void DeleteAlumnus2(string PersonCode) //form 4
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.GetAlumnus(PersonCode);
            unitOfWork.Alumnuses.Remover(alumnusX);
            unitOfWork.Save();
        }
        public void DeleteSendList(int SendListId) //form 4
        {
            SendList sendListX = unitOfWork.SendLists.Get(SendListId);
            unitOfWork.SendLists.Remover(sendListX);
            unitOfWork.Save();
        }
        public void DeleteActivity(int ActivityId) //form 4
        {
            unitOfWork.Activities.Remover(unitOfWork.Activities.Get(ActivityId));
            unitOfWork.Save();
        }

        // Add booking and SendList
        public bool CreateBooking(int ActivityId) //form 3
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.GetAlumnusActivity(PersonOnline.ID);
            Activity activityX = unitOfWork.Activities.Get(ActivityId);
            if(!alumnusX.Activities.Contains(activityX))
            {
                alumnusX.Activities.Add(activityX);
                unitOfWork.Save();
                return true;
            }
            return false;
        }
        public void AddAlumnusSenList(int SendListId, string PersonCode) //form 4
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.GetAlumnus(PersonCode);
            unitOfWork.SendLists.Get(SendListId).Alumnuses.Add(alumnusX);
            unitOfWork.Save();
        }
        
        // Remove objekt
        public void RemoveAlumnusActivity(int ActivityId, string PersonCode) //form 4
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.GetAlumnus(PersonCode);
            unitOfWork.Activities.Get(ActivityId).Alumnuses.Remove(alumnusX);
            unitOfWork.Save();
        }
        public void RemoveAlumnusSendList(int SendListId, string PersonCode)
        {
            Alumnus alumnusX = unitOfWork.Alumnuses.GetAlumnus(PersonCode);
            unitOfWork.SendLists.Get(SendListId).Alumnuses.Remove(alumnusX);
            unitOfWork.Save();
        }
    }
}
