using BusinessEntity.ClassModels;

namespace DataLayer.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        DataContext DataContext { get; }
    }
}