using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IRegUserRepository RegUser { get; }
        IEmployeeRepository Employee { get; }
        Task Save();
    }
}
