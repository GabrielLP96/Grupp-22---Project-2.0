using BusinessEntity.CM_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessEntity.ClassModels
{
    public class Employee : IEmployee, IPerson
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string PersonCode { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime EmployeerDate { get; set; }

        public ICollection<Activity> Activities { get; set; }
        public ICollection<SendList> SendLists { get; set; }
    }
}
