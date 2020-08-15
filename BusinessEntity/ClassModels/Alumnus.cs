using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.ClassModels
{
    public class Alumnus
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Ename { get; set; }
        public string PersonCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Qualification { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<SendList> SendLists { get; set; }

        private DateTime examDate;
        public DateTime ExamDate
        {
            get
            {
                if (examDate == DateTime.MinValue)
                {
                    return examDate = DateTime.Today;
                }
                return examDate;
            }
            set
            {
                examDate = value;
            }
        }

    }
}
