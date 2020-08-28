using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrict.Models.CampaignViewModels
{
    public class CampaignUserData
    {
        public IEnumerable<Campaign> Campaigns { get; set; }
        public IEnumerable<CampaignUser> CampaignUsers { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

    }
}
