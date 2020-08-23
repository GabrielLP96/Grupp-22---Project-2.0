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
                Activities = new List<Activity>(),
                SendLists = new List<SendList>()
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
                Activities = new List<Activity>(),
                SendLists = new List<SendList>()
            };
            dataContext.Employees.Add(employee2);

            // Alumnuses
            Alumnus alumnus1 = new Alumnus()
            {
                Fname = "Lindah",
                Lname = "Dahl",
                PersonCode = "19860302-9999",
                Password = "d1234",
                Email = "Lindah@hotmail.com",
                PhoneNumber = 0708555788,
                Qualification = "DataEkonomutbildningen",
                ExamDate = new DateTime(2020, 03, 12),
            };
            dataContext.Alumnuses.Add(alumnus1);

            Alumnus alumnus2 = new Alumnus()
            {
                Fname = "Robin",
                Lname = "Sten",
                PersonCode = "19790302-9999",
                Password = "r1234",
                Email = "Robin@hotmail.com",
                PhoneNumber = 0708666711,
                Qualification = "DataEkonomutbildningen",
                ExamDate = new DateTime(2019, 03, 12),
            };
            dataContext.Alumnuses.Add(alumnus2);

            Alumnus alumnus3 = new Alumnus()
            {
                Fname = "Daniel",
                Lname = "White",
                PersonCode = "19990302-9999",
                Password = "d1234",
                Email = "Daniel@hotmail.com",
                PhoneNumber = 0708666711,
                Qualification = "Systemvetarutbildning",
                ExamDate = new DateTime(2019, 03, 12),
            };
            dataContext.Alumnuses.Add(alumnus3);

            Alumnus alumnus4 = new Alumnus()
            {
                Fname = "Erik",
                Lname = "White",
                PersonCode = "19990302-9999",
                Password = "e1234",
                Email = "Erik@hotmail.com",
                PhoneNumber = 0708666711,
                Qualification = "Systemvetarutbildning",
                ExamDate = new DateTime(2019, 03, 12),
            };
            dataContext.Alumnuses.Add(alumnus4);

            Alumnus alumnus5 = new Alumnus()
            {
                Fname = "Sara",
                Lname = "Sol",
                PersonCode = "19860302-9999",
                Password = "s1234",
                Email = "Sara@hotmail.com",
                PhoneNumber = 0708666711,
                Qualification = "Textilekonom",
                ExamDate = new DateTime(2019, 03, 12),
            };
            dataContext.Alumnuses.Add(alumnus5);
            
            Alumnus alumnus6 = new Alumnus()
            {
                Fname = "Stina",
                Lname = "Lima",
                PersonCode = "19950302-9999",
                Password = "ss12345",
                Email = "Stina@hotmail.com",
                PhoneNumber = 0708668866,
                Qualification = "Textilekonom",
                ExamDate = new DateTime(2019, 03, 12),
            };
            dataContext.Alumnuses.Add(alumnus6);

            //Aktivitis
            Activity activity1 = new Activity()
            {
                Event = "Introduktion",
                Adress = "Allégatan 1, 503 32 Borås",
                Date = new DateTime(2020, 04, 01, 10, 30, 00),
                Category = "Möte",
                Alumnuses = new List<Alumnus>(),
                Employee = employee1
            };
            activity1.Alumnuses.Add(alumnus1);
            activity1.Alumnuses.Add(alumnus2);
            activity1.Alumnuses.Add(alumnus5);
            dataContext.Activities.Add(activity1);

            Activity activity2 = new Activity()
            {
                Event = "Invignings Fest",
                Adress = "Allégatan 1, 503 32 Borås",
                Date = new DateTime(2020, 04, 01, 18, 30, 00),
                Category = "Nöje",
                Alumnuses = new List<Alumnus>(),
                Employee = employee2
            };
            activity1.Alumnuses.Add(alumnus3);
            activity1.Alumnuses.Add(alumnus4);
            activity1.Alumnuses.Add(alumnus6);
            dataContext.Activities.Add(activity2);

            // SendLists
            SendList sendList1 = new SendList()
            {
                Name = "Dataekonomer",
                Alumnuses = new List<Alumnus>(),
                Employee = employee1
            };
            sendList1.Alumnuses.Add(alumnus1);
            sendList1.Alumnuses.Add(alumnus2);
            dataContext.SendLists.Add(sendList1);

            SendList sendList2 = new SendList()
            {
                Name = "Systemvetare",
                Alumnuses = new List<Alumnus>(),
                Employee = employee1
            };
            sendList1.Alumnuses.Add(alumnus4);
            sendList1.Alumnuses.Add(alumnus3);
            dataContext.SendLists.Add(sendList2);

            SendList sendList3 = new SendList()
            {
                Name = "Textilekonomer",
                Alumnuses = new List<Alumnus>(),
                Employee = employee2
            };
            sendList1.Alumnuses.Add(alumnus5);
            sendList1.Alumnuses.Add(alumnus6);
            dataContext.SendLists.Add(sendList3);

            dataContext.SaveChanges();
        }
    }
}
