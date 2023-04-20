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
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(HRAntraTrainningDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Status>> GetStatusByState(string state)
        {
            var statuses = await _dbContext.Statuses.Where(s => s.State == state).Include(s => s.Submission).ToListAsync();
            return statuses;
        }
    }
}
