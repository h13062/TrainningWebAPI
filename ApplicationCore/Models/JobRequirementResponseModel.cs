using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class JobRequirementResponseModel
    {
        public int Id { get; set; }
        public int NumberOfPosition { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? HiringManagerId { get; set; }
        public string? HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string? ClosedReason { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? JobCategoryId { get; set; }

        public string ActionRoute { get; set; }
    }
}
