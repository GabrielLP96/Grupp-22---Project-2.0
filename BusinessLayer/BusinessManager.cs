using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataLayer;
using DataLayer.Repositories;
using BusinessEntity.ClassModels;
using BusinessEntity;

namespace BusinessLayer
{
    public class BusinessManager
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new DataContext());

        public BusinessManager()
        {
            if (!unitOfWork.Employees.GetAll().Any())
            {
                unitOfWork.Reset();
            }
        }
        public void Reset ()
        {
            unitOfWork = new UnitOfWork(new DataContext());
            unitOfWork.Reset();
        }

    }
}
