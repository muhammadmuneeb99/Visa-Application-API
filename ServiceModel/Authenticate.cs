using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.ServiceModel
{
    public class Authenticate
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
