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
    public class CandidatesService : ICandidatesService
    {
        ICandidatesRepository candidateRepository;
        public CandidatesService(ICandidatesRepository _candidates)
        {
            candidateRepository = _candidates;
        }
        public async Task<int> AddCandidateAsync(CandidatesRequestModel model)
        {
            // Get User By Email uses FirstorDefault which allows Null as return. 
            var existingCandidate = await candidateRepository.GetUserByEmail(model.Email);
            if (existingCandidate != null)
            {
                throw new Exception("Email is already used");
            }
            Candidates candidate = new Candidates();
            if (model != null)
            {
                candidate.FirstName = model.FirstName;
                candidate.MiddleName = model.MiddleName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
            }
            //returns number of rows affected, typically 1
            return await candidateRepository.InsertAsync(candidate);
        }

        public async Task<int> DeleteCandidateAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await candidateRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidatesResponseModel>> GetAllCandidates()
        {
            var collection = await candidateRepository.GetAllAsync();
            if (collection != null)
            {
                List<CandidatesResponseModel> result = new List<CandidatesResponseModel>();
                foreach (var item in collection)
                {
                    CandidatesResponseModel model = new CandidatesResponseModel();
                    model.Id = item.Id;
                    model.FirstName = item.FirstName;
                    model.MiddleName = item.MiddleName;
                    model.LastName = item.LastName;
                    model.Email = item.Email;
                    model.ResumeURL = item.ResumeURL;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CandidatesResponseModel> GetCandidateByIdAsync(int id)
        {
                var collection = await candidateRepository.GetByIdAsync(id);
                if (collection != null)
                {
                   
                    CandidatesResponseModel model = new CandidatesResponseModel();
                    model.Id = collection.Id;
                    model.FirstName = collection.FirstName;
                    model.MiddleName = collection.MiddleName;
                    model.LastName = collection.LastName;
                    model.Email = collection.Email;
                    model.ResumeURL = collection.ResumeURL;
                    return model;  
                }
                return null;
        }

            public async Task<int> UpdateCandidateAsync(CandidatesRequestModel model)
            {
                var existingCandidate = await candidateRepository.GetByIdAsync(model.Id);
                if (existingCandidate == null)
                {
                    throw new Exception("Candidate does not exist");
                }
                Candidates candidate = new Candidates();
                if (model != null)
                {
                    candidate.Id = model.Id;
                    candidate.FirstName = model.FirstName;
                    candidate.MiddleName = model.MiddleName;
                    candidate.LastName = model.LastName;
                    candidate.Email = model.Email;
                    candidate.ResumeURL = model.ResumeURL;
                    return await candidateRepository.UpdateAsync(candidate);
                }
                else
                {
                    //unsuccessful update
                    return -1;
                }

            }
        }

    }
