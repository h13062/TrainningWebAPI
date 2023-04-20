using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repositories
{
    public interface ICandidatesRepository : IBaseRepository<Candidates>
    {
        Task<Candidates> GetUserByEmail(string email);
        Task<Candidates> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidates, bool>> where,
          params Expression<Func<Candidates, object>>[] includes);
    }
}
