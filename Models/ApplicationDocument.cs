using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.Models
{
    public partial class ApplicationDocument
    {
        public int PkDocumentId { get; set; }
        [Required]
        public string DocumentName { get; set; }
        [Required]
        public string DocumentType { get; set; }
        [Required]
        public string DocumentPath { get; set; }
        public virtual Application Application { get; set; }
    }
}
