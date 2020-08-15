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
        public DataContext DataContext
        {
            get { return DataContext as DataContext; }
        }
        public Alumnus GetAlumnus(String PersonCode)
        {
            return DataContext.Alumnuses.Where(x => x.PersonCode == PersonCode).FirstOrDefault();
        }
        public Alumnus GetAlumnusActivity(int AlumnusId)
        {
            return DataContext.Alumnuses.Include(x => x.Activities).Where(x => x.Id == AlumnusId).FirstOrDefault();
        }
        public List<Alumnus> GetAllAlumnusActivity()
        {
            return DataContext.Alumnuses.Include(x => x.Activities).ToList();
        }

    }
}
