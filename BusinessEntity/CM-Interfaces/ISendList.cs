using System.Collections.Generic;

namespace BusinessEntity.ClassModels
{
    public interface ISendList
    {
        ICollection<Alumnus> Alumnuses { get; set; }
        Employee Employee { get; set; }
        string Name { get; set; }
        int SendListID { get; set; }
    }
}