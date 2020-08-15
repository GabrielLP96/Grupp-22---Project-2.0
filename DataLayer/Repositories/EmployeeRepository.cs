using BusinessEntity.ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context)
        {

        }
        public DataContext DataContext
        {
            get { return dbContext as DataContext; }
        }
    }
}
