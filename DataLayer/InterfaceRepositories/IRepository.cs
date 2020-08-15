using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Repositories
{
    public interface IRepository<Design>
    {
        void AddMore(IEnumerable<Design> design);
        void AddUppdate(Design design);
        Design Get(int ID);
        List<Design> GetAll();
        void RemoveMore(IEnumerable<Design> Designs);
        void Remover(Design design);
    }
}