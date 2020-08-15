using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public IActivityRepository Activities { get; private set; }
        public IAlumnusRepository Alumnuses { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public ISendListRepository SendLists { get; private set; }

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;

            Activities = new ActivityRepository(this.dataContext);
            Alumnuses = new AlumnusRepository(this.dataContext);
            Employees = new EmployeeRepository(this.dataContext);
            SendLists = new SendListRepository(this.dataContext);
        }
        public void Save()
        {
            dataContext.SaveChanges();
        }

        public void Reset()
        {
            dataContext.Reset();
            new Preintputs().Add(dataContext);
        }
    }
}
