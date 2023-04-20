using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class StatusRequestModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequirementId { get; set; }
        public string State { get; set; }
        public string StatusMessage { get; set; }
        public int SubmissionId { get; set; }
    }
}
