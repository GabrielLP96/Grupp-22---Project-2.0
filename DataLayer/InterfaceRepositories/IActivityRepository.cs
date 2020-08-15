using BusinessEntity.ClassModels;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        DataContext DataContext { get; }

        List<Activity> GetActivityWithAlumnus(int AlumnusId);
        List<Activity> GetAllActivitysWithAlumnus();
        Activity GetAlumnusesWithActivity(int ActivityId);
    }
}