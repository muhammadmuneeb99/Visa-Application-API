using System.ComponentModel.DataAnnotations;

namespace Visa_Application_API.Models
{
    public partial class Application
    {
        public Application()
        {
            ApplicationStatus = new HashSet<ApplicationStatus>();
            ApplicationDocument = new HashSet<ApplicationDocument>();
        }
        public int PkApplicationId { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Title should contains atleast 2 characters", MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "FirstName should contains atleast 4 characters", MinimumLength = 4)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "LastName should contains atleast 4 characters", MinimumLength = 4)]
        public string LastName { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "FatherName should contains atleast 4 characters", MinimumLength = 4)]
        public string FatherName { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "MotherName should contains atleast 4 characters", MinimumLength = 4)]
        public string MotherName { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Nationality should contains atleast 4 characters", MinimumLength = 4)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(56, ErrorMessage = "PlaceOfBirth should contains atleast 4 characters", MinimumLength = 4)]
        public string PlaceOfBirth { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "Gender should contains atleast 1 characters M or F", MinimumLength = 1)]
        public string Gender { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "PassportNo should contains atleast 4 characters", MinimumLength = 4)]
        public string PassportNo { get; set; }
        [Required]
        [StringLength(56, ErrorMessage = "PlaceOfIssue should contains atleast 4 characters", MinimumLength = 4)]
        public string PlaceOfIssue { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public DateTime DateOfExpiry { get; set; }
        [Required]
        [StringLength(56, ErrorMessage = "Country should contains atleast 10 characters", MinimumLength = 4)]
        public string Country { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name should contains atleast 10 characters", MinimumLength = 10)]
        public string PermanentAddress { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Telephone should contains atleast 7 characters", MinimumLength = 7)]
        public string Telephone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name should contains atleast 3 characters", MinimumLength = 3)]
        public string PurposeOfEntry { get; set; }
        public int VisaType { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }


        public int ApplicantId { get; set; }
        public virtual Applicant? Applicants { get; set; }
        public virtual SponsorOrHost? SponsorOrHost { get; set; } // Reference navigation to dependent
        public ICollection<ApplicationStatus> ApplicationStatus { get; set; } // Collection navigation containing dependents
        public ICollection<ApplicationDocument> ApplicationDocument { get; set; } // Collection navigation containing dependents
    }
}
