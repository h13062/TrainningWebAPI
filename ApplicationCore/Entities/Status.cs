using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApplicationCore.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTime? ChangedOn { get; set; }
        public string StatusMessage { get; set; }
        public int SubmissionId { get; set; }
        //naviagational property
        public Submission Submission { get; set; }
    }
}