using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.InsertModel
{
    public class AddApplicant
    {
        
        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public string ContactNo { get; set; }
        
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public DateTime CreationDateTime { get; set; }
    }
}
