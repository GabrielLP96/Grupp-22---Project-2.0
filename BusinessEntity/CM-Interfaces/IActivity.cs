using System;
using System.Collections.Generic;

namespace BusinessEntity.ClassModels
{
    public interface IActivity
    {
        int ActivityID { get; set; }
        string Adress { get; set; }
        ICollection<Alumnus> Alumnuses { get; set; }
        string Category { get; set; }
        DateTime Date { get; set; }
        Employee Employee { get; set; }
        string Event { get; set; }
    }
}