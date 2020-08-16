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
        public List<SendList>GetSendListsByID()
        {
            return unitOfWork.SendLists.GettAllSendListWithAlumnuses(PersonOnline.ID);
        }

        //Create
        public bool CreateAlumnus(Alumnus NewAlumnus) //form 2
        {
            if (unitOfWork.Alumnuses.GetAll().Any(x => x.PersonCode == NewAlumnus.PersonCode))
            {
                unitOfWork.Alumnuses.Add(NewAlumnus);
                unitOfWork.Save();
                return true;
            }
            return false;
        }
        public void CreateSendList(string Name)
        {
            Employee Employee = unitOfWork.Employees.Get(PersonOnline.ID);
            SendList NewSendList = new SendList();
            NewSendList.Name = Name;
            NewSendList.Employee = Employee;
            unitOfWork.SendLists.Add(NewSendList);
        }

    }
}
