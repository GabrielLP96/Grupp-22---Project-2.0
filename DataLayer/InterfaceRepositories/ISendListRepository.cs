using BusinessEntity.ClassModels;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface ISendListRepository : IRepository<SendList>
    {
        DataContext DataContext { get; }

        List<SendList> GettAllSendListWithAlumnuses(int PersonID);
    }
}