using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IRepository<Design> where Design : class
    {
        void Add(Design design);
        void AddMore(IEnumerable<Design> design);
        void AddUppdate(Design design);
        Design Get(int ID);
        List<Design> GetAll();
        void RemoveMore(IEnumerable<Design> Designs);
        void Remover(Design design);
    }
}