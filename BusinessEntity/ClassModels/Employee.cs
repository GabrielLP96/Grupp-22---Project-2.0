using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.ClassModels
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string PersonCode { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime EmployeerDate { get; set; }

        public ICollection<Activity> activities { get; set; }
        public ICollection<SendList> sendLists { get; set; }
    }
}
