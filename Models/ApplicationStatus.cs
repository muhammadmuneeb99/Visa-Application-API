using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.Models
{
    public partial class ApplicationStatus
    {
        public int PkStatusId { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        public virtual Application Application { get; set; } // Required reference navigation to principal
    }
}
