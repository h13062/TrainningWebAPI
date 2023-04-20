using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApplicationCore.Entities
{
    public class EmployeeRequirementType
    {
        public int Id { get; set; }
        public int JobRequirementId { get; set; }
        public int EmployeeTypeId { get; set; }

        public JobRequirement JobRequirement { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}