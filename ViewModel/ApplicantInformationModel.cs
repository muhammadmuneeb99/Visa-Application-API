using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.ViewModel
{
    public class ApplicantInformationModel
    {
        public int PkApplicantId { get; set; }

        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public string ContactNo { get; set; }
        
        public string Email { get; set; }
    }
}
