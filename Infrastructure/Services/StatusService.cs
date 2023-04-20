using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StatusService : IStatusService
    {
        IStatusRepository statusRepository;
        ISubmissionRepository submissionRepository;
        public StatusService(IStatusRepository _status, ISubmissionRepository submissionRepository)
        {
            statusRepository = _status;
            this.submissionRepository = submissionRepository;
        }
        public async Task<int> AddStatusAsync(StatusRequestModel model)
        {
            //Looks for the associated submission to compare status states.If it isnt changed, reject status addition.
            var relevantSubmission = await submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.CandidateId == model.CandidateId &&
                s.JobRequirementId == model.JobRequirementId, s => s.Status);
            //Last changed status
            var statusList = relevantSubmission.Status.Count - 1;
            var existingStatus = relevantSubmission.Status.FirstOrDefault(s => s.Id == relevantSubmission.Status[statusList].Id);
            if (existingStatus != null && existingStatus.State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if (model != null)
            {
                status.SubmissionId = relevantSubmission.Id;
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                status.Submission = relevantSubmission;
            }
            //returns number of rows affected, typically 1
            return await statusRepository.InsertAsync(status);
        }

        public async Task<int> DeleteStatusAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await statusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StatusResponseModel>> GetAllStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<StatusResponseModel> GetStatusByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateStatusAsync(StatusRequestModel model)
        {
            // Could be improved because now we have status Id but its fine 
            var relevantSubmission = await submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.Id == model.SubmissionId, s => s.Status);
            //Last changed status
            var statusList = relevantSubmission.Status.Count - 1;
            var existingStatus = relevantSubmission.Status.FirstOrDefault(s => s.Id == relevantSubmission.Status[statusList].Id);
            if (existingStatus != null && existingStatus.State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if (model != null)
            {
                status.Id = model.Id;
                status.SubmissionId = model.SubmissionId;
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                return await statusRepository.UpdateAsync(status);
            }

            else
            {
                //unsuccessful update
                return -1;
            }
        }
    }
}
