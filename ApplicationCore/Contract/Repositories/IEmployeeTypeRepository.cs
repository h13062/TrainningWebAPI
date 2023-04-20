using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repositories
{
    public interface IEmployeeTypeRepository: IBaseRepository<EmployeeType>
    {
        Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName);
    }
}
