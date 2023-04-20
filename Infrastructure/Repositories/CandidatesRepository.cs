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
    public class CandidatesRepository : BaseRepository<Candidates>, ICandidatesRepository
    {
        public CandidatesRepository(HRAntraTrainningDbContext context) : base(context)  
        {

        }

        public async Task<Candidates> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidates, bool>> where,
             params Expression<Func<Candidates, object>>[] includes)
        {
            var query = _dbContext.Set<Candidates>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }


        public async Task<Candidates> GetUserByEmail(string email)
        {
            return await _dbContext.Candidates.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
