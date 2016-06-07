using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
   public class ContractViewModels
    {
        public Contract Contract { get; set; }
        //public string content { get; set; }
        //public List<DealInContract> DealsInContract { get; set; }
        
        //[MaxLength(3500, ErrorMessageResourceName = "TooLongError", ErrorMessageResourceType = typeof(Resources.Domain))]
        //public string Content { get; set; }
        //[MaxLength(128)]
        //public string Title { get; set; }
        public SelectList CampaignsList { get; set; }
        public Campaign GetCampaign { get; set; }
    }
}
