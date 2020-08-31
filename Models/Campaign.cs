using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metrict.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public bool CampaignActive { get; set; }
        public string ManagerId { get; set; }
        public int CompanyId { get; set; }
        //Allow 10 number fields used to present data in graphs and charts
        public int NumberDataColumnCount { get; set; }
        public string DataColumnNumber1Title { get; set; }
        public string DataColumnNumber2Title { get; set; }
        public string DataColumnNumber3Title { get; set; }
        public string DataColumnNumber4Title { get; set; }
        public string DataColumnNumber5Title { get; set; }
        public string DataColumnNumber6Title { get; set; }
        public string DataColumnNumber7Title { get; set; }
        public string DataColumnNumber8Title { get; set; }
        public string DataColumnNumber9Title { get; set; }
        public string DataColumnNumber10Title { get; set; }

        //Allow 10 text fields for other data to be tracked
        public int TextDataColumnCount { get; set; }
        public string DataColumnTextATitle { get; set; }
        public string DataColumnTextBTitle { get; set; }
        public string DataColumnTextCTitle { get; set; }
        public string DataColumnTextDTitle { get; set; }
        public string DataColumnTextETitle { get; set; }
        public string DataColumnTextFTitle { get; set; }
        public string DataColumnTextGTitle { get; set; }
        public string DataColumnTextHTitle { get; set; }
        public string DataColumnTextITitle { get; set; }
        public string DataColumnTextJTitle { get; set; }

    }
}
