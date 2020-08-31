using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metrict.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string ManagerId { get; set; }
        public int CompanyId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public bool IsActive { get; set; }

        public int DataColumnNumber1 { get; set; }
        public int DataColumnNumber2 { get; set; }
        public int DataColumnNumber3 { get; set; }
        public int DataColumnNumber4 { get; set; }
        public int DataColumnNumber5 { get; set; }
        public int DataColumnNumber6 { get; set; }
        public int DataColumnNumber7 { get; set; }
        public int DataColumnNumber8 { get; set; }
        public int DataColumnNumber9 { get; set; }
        public int DataColumnNumber10 { get; set; }

        public string DataColumnTextA { get; set; }
        public string DataColumnTextB { get; set; }
        public string DataColumnTextC { get; set; }
        public string DataColumnTextD { get; set; }
        public string DataColumnTextE { get; set; }
        public string DataColumnTextF { get; set; }
        public string DataColumnTextG { get; set; }
        public string DataColumnTextH { get; set; }
        public string DataColumnTextI { get; set; }
        public string DataColumnTextJ { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Campaign Campaign { get; set; }
    }
}
