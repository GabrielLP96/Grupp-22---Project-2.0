using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusinessEntity.ClassModels;

namespace DataLayer.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(DataContext context) : base(context)
        {

        }
        public DataContext DataContext
        {
            get { return dbContext as DataContext; }
        }

        public List<Activity> GetActivityWithAlumnus(int AlumnusId)
        {
            return DataContext.Activities.Where(x => x.Alumnuses.Any(z => z.Id == AlumnusId)).ToList();
        }

        public Activity GetAlumnusesWithActivity(int ActivityId)
        {
            return DataContext.Activities.Include(x => x.Alumnuses).Where(x => x.ActivityID == ActivityId).FirstOrDefault();
        }

        public List<Activity> GetAllActivitysWithAlumnus()
        {
            return DataContext.Activities.Include(x => x.Alumnuses).ToList();
        }
    }
}
