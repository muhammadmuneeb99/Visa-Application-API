using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Visa_Application_API.Models
{
    public partial class SponsorOrHost
    {
        public int PkId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "NameOfSponsorOrHost should contains atleast 4 characters", MinimumLength = 4)]
        public string NameOfSponsorOrHost{ get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Profession should contains atleast 2 characters", MinimumLength = 2)]
        public string Profession { get; set; }
        [Required]
        [StringLength(56, ErrorMessage = "Nationality should contains atleast 4 characters", MinimumLength = 4)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Telephone should contains atleast 7 characters", MinimumLength = 7)]
        public string Telephone { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "PassportNo should contains atleast 4 characters", MinimumLength = 4)]
        public string PassportNo { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Address should contains atleast 10 characters", MinimumLength = 10)]
        public string Address { get; set; }
        [StringLength(56, ErrorMessage = "Country should contains atleast 4 characters", MinimumLength = 4)]
        public string Country { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public int ApplicationId { get; set; } // Required foreign key property
        public Application Application { get; set; } // Required reference navigation to principal
    }
}
