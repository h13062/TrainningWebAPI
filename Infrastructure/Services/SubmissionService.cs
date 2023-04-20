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
    public class SubmissionService : ISubmissionService
    {
        ISubmissionRepository _submissionRepository;
        ICandidatesRepository _candidateRepository;
        IStatusService _statusService;

        public SubmissionService(ISubmissionRepository submissions, ICandidatesRepository candidateRepository, IStatusService statusService)
        {
            _submissionRepository = submissions;
            _candidateRepository = candidateRepository;
            _statusService = statusService;
        }
        //Check if the candidate's submission is linked with jR to see if candidate has already submitted a submission to that same jR
        public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            var candidateJRSubs = await _candidateRepository.FirstOrDefaultWithIncludesAsync(x => x.Id == model.CandidateId, x => x.Submissions);
            var exists = candidateJRSubs.Submissions.FirstOrDefault(s => s.JobRequirementId == model.JobRequirementId);

            if (exists != null)
            {
                throw new Exception("Submission already made");
            }
            Submission submission = new Submission();

            //Id is assigned once the Submission enters the database (Identity column)
            // Submission created -> Id assigned -> add to status history

            /*
                public int Id { get; set; }
                public string State { get; set; }
                public DateTime? ChangedOn { get; set; }
                public string StatusMessage { get; set; }
                public int SubmissionId { get; set; }
                public Submission Submission { get; set; }
            */
            if (model != null)
            {
                submission.JobRequirementId = model.JobRequirementId;
                submission.CandidateId = model.CandidateId;
                submission.SubmittedOn = model.SubmittedOn;
                submission.ConfirmedOn = model.ConfirmedOn;
                submission.RejectedOn = model.RejectedOn;
                submission.CurrentStatus = "Submitted";
            }
            //returns number of rows affected, typically 1
            await _submissionRepository.InsertAsync(submission);
            await _statusService.AddStatusAsync(new StatusRequestModel()
            {
                CandidateId = submission.CandidateId,
                JobRequirementId = submission.JobRequirementId,
                State = submission.CurrentStatus,
                StatusMessage = "Submission created"
            });
            return 1; //Add in statusService for some reason with candidateid and job id
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await _submissionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissions()
        {
            throw new NotImplementedException();
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            var existingSubmission = await _submissionRepository.GetByIdAsync(model.Id);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            Submission submission = new Submission();
            if (model != null)
            {
                submission.Id = model.Id;
                submission.JobRequirementId = model.JobRequirementId;
                submission.CandidateId = model.CandidateId;
                submission.SubmittedOn = model.SubmittedOn;
                submission.ConfirmedOn = model.ConfirmedOn;
                submission.RejectedOn = model.RejectedOn;
                // Consider the impact of status history on this statement below
                submission.CurrentStatus = model.CurrentStatus;
                return await _submissionRepository.UpdateAsync(submission);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
