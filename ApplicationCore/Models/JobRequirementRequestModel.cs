using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class JobRequirementRequestModel
    {
        public int Id { get; set; }
        public int NumberOfPosition { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(256, ErrorMessage = "Max 256 characters")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int HiringManagerId { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(256, ErrorMessage = "Max 256 characters")]
        public string? HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ClosedOn { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ClosedReason { get; set; }
        public DateTime CreatedOn { get; set; }
        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; } //Manager, employee, Lead, Senior, 
        public List<EmployeeRequirementType> EmployeeRequirementTypes { get; set; } //Parttime, intern, Fulltime
        public List<Submission> Submissions { get; set; }
    }
}
