using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusinessEntity.ClassModels;

namespace DataLayer.Repositories
{
    public class AlumnusRepository : Repository<Alumnus>, IAlumnusRepository
    {
        public AlumnusRepository(DataContext context) : base(context)
        {
        }
        public DataContext DataContexts
        {
            get { return dbContext as DataContext; }
        }
        public Alumnus GetAlumnus(string PersonCode)
        {
            return DataContexts.Alumnuses.Where(x => x.PersonCode == PersonCode).FirstOrDefault();
        }
        public Alumnus GetAlumnusActivity(int AlumnusId)
        {
            return DataContexts.Alumnuses.Include(x => x.Activities).Where(x => x.ID == AlumnusId).FirstOrDefault();
        }
        public List<Alumnus> GetAllAlumnusActivity()
        {
            return DataContexts.Alumnuses.Include(x => x.Activities).ToList();
        }

    }
}
