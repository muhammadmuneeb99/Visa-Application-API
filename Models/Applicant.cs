using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.Models
{
    public partial class Applicant
    {
        public Applicant()
        {
            Application = new HashSet<Application>();
        }
        public int PkApplicantId { get; set; }
        
        [Required]
        [StringLength(250, ErrorMessage = "Name should contains atleast 4 characters", MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Username should contains atleast 4 characters", MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        public ICollection<Application> Application { get; set; }
        
    }
}
