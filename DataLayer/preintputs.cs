using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity.ClassModels;

namespace DataLayer
{
    public class Preintputs
    {
        public void Add(DataContext dataContext)
        {
            //Employees
            Employee employee1 = new Employee()
            {
                Fname = "Gabriel",
                Lname = "Lundberg Puglia",
                PersonCode = "19961106-9999",
                Password = "g1234",
                Email = "GabreilLP196@hotmail.com",
                PhoneNumber = 0706555233,
                EmployeerDate = new DateTime(2019, 03, 04),
                activities = new List<Activity>(),
                sendLists = new List<SendList>()
            };
            dataContext.Employees.Add(employee1);


            Employee employee2 = new Employee()
            {
                Fname = "Olle",
                Lname = "Sandahl",
                PersonCode = "19960306-9999",
                Password = "o1234",
                Email = "Olle@hotmail.com",
                PhoneNumber = 0706555768,
                EmployeerDate = new DateTime(2018, 08, 04),
                activities = new List<Activity>(),
                sendLists = new List<SendList>()
            };
            dataContext.Employees.Add(employee2);

            // Alumnuses

        }
    }
}
