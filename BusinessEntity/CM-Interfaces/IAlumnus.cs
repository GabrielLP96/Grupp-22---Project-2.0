using System;
using System.Collections.Generic;

namespace BusinessEntity.ClassModels
{
    public interface IAlumnus
    {
        ICollection<Activity> Activities { get; set; }
        string Email { get; set; }
        string Ename { get; set; }
        DateTime ExamDate { get; set; }
        string Fname { get; set; }
        int Id { get; set; }
        string Password { get; set; }
        string PersonCode { get; set; }
        int PhoneNumber { get; set; }
        string Qualification { get; set; }
        ICollection<SendList> SendLists { get; set; }
    }
}