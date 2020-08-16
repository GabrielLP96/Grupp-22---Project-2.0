using BusinessEntity.ClassModels;
using System.Collections.Generic;

namespace BusinessEntity.CM_Interfaces
{
    public interface IPerson
    {
        ICollection<Activity> Activities { get; set; }
        string Email { get; set; }
        string Fname { get; set; }
        int ID { get; set; }
        string Lname { get; set; }
        string Password { get; set; }
        string PersonCode { get; set; }
        int PhoneNumber { get; set; }
        ICollection<SendList> SendLists { get; set; }
    }
}