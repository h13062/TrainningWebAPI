using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repositories
{
    public interface ISubmissionRepository: IBaseRepository<Submission>
    {
        public Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where,
           params Expression<Func<Submission, object>>[] includes);
    }
}
