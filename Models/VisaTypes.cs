using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.Models
{
    public partial class VisaTypes
    {
        
        public int PkVisaTypeId { get; set; }
        [Required]
        public string VisaType { get; set; }
    }
}
