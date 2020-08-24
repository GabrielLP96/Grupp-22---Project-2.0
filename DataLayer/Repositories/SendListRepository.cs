using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusinessEntity.ClassModels;

namespace DataLayer.Repositories
{
    public class SendListRepository : Repository<SendList>, ISendListRepository
    {
        public SendListRepository(DataContext context) : base(context)
        {

        }
        public DataContext DataContext
        {
            get { return dbContext as DataContext; }
        }

        public List<SendList> GettAllSendListWithAlumnuses(int EmployeeID)
        {
            return DataContext.SendLists.Include(x => x.Alumnuses).Where(x => x.Employee.ID == EmployeeID).ToList();
        }
    }
}
