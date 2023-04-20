using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface IStatusService
    {
        Task<int> AddStatusAsync(StatusRequestModel model);
        Task<int> UpdateStatusAsync(StatusRequestModel model);
        Task<int> DeleteStatusAsync(int id);
        Task<IEnumerable<StatusResponseModel>> GetAllStatus();
        Task<StatusResponseModel> GetStatusByIdAsync(int id);
    }
}
