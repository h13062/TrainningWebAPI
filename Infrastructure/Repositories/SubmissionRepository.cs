using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(HRAntraTrainningDbContext context) : base(context)
        {
        }
        public async Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where,
           params Expression<Func<Submission, object>>[] includes)
        {
            var query = _dbContext.Set<Submission>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }
        /*
        public async Task<Submission> GetSubmissionsByJobAndCandidateIdAsync(int jobReqId, int candidateId)
        {
            return await _dbContext.Submissions.Where(x => x.JobRequirementId == jobReqId && x.CandidateId == candidateId).FirstOrDefaultAsync();
        }
        */
    }
}
