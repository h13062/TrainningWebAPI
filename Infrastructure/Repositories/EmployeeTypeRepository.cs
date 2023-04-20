using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeTypeRepository : BaseRepository<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(HRAntraTrainningDbContext context) : base(context)
        {
        }

        public async Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName)
        {
            return await _dbContext.EmployeeTypes.Where(x => x.TypeName == typeName.ToLower()).FirstOrDefaultAsync();
        }
    }
}
