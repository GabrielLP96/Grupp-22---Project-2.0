using BusinessEntity.ClassModels;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IAlumnusRepository : IRepository<Alumnus>
    {
        DataContext DataContext { get; }

        List<Alumnus> GetAllAlumnusActivity();
        Alumnus GetAlumnus(string PersonCode);
        Alumnus GetAlumnusActivity(int AlumnusId);
    }
}