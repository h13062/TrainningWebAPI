using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface ICandidatesService
    {
        Task<int> AddCandidateAsync(CandidatesRequestModel model);
        Task<int> UpdateCandidateAsync(CandidatesRequestModel model);
        Task<int> DeleteCandidateAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<CandidatesResponseModel>> GetAllCandidates();
        Task<CandidatesResponseModel> GetCandidateByIdAsync(int id);
    }
}
