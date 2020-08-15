using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.ClassModels
{
    public class Activity : IActivity
    {
        public int ActivityID { get; set; }
        public string Event { get; set; }
        public string Adress { get; set; }
        public string Category { get; set; }
        public Employee Employee { get; set; }

        public ICollection<Alumnus> Alumnuses { get; set; }

        private DateTime date;

        public DateTime Date
        {
            get
            {
                if (date == DateTime.MinValue)
                {
                    return date = DateTime.Now.AddDays(7);
                }
                return date;
            }
            set
            {
                date = value;
            }
        }
    }
}
