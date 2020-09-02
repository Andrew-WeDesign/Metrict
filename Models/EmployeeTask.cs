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
        public string ManagerId { get; set; }
        public string ManagerUserName { get; set; }

        // Add some text fields
        // 
        // Task Name
        // Manager's instruction
        // Comments for back and forth dialog
        // Severity Level
        // Due Date
        // Status Assigned, WorkInProgress, Review, Completed
        // Bool for something like need manager response OR an unread message field to notify employees/managers when someone has responded on a task

        public ApplicationUser ApplicationUser { get; set; }

    }
}
