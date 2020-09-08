using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metrict.Models
{
    public class EmployeeTask
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; }
        public string ApplicationUserFullName { get; set; }
        public string ManagerId { get; set; }
        public string ManagerUserName { get; set; }
        public string ManagerFullName { get; set; }
        public string TaskDescription { get; set; }
        public string Comments { get; set; }
        public LevelOfSeverity Severity { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public StatusOfTask Status { get; set; }
        public DateTime WorkInProgressDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool ManagerReply { get; set; }
        public bool EmployeeReply { get; set; }
        public int CompanyId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Company Company { get; set; }
    }
    public enum LevelOfSeverity
    {
        Lowest, Low, Normal, High, Highest
    }
    public enum StatusOfTask
    {
        Assigned, WorkInProgress, Review, Completed
    }
}
