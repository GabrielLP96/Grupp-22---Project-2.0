using DataLayer.Repositories;

namespace DataLayer
{
    public interface IUnitOfWork
    {
        IActivityRepository Activities { get; }
        IAlumnusRepository Alumnuses { get; }
        IEmployeeRepository Employees { get; }
        ISendListRepository SendLists { get; }

        void Reset();
        void Save();
    }
}