using System.ComponentModel.DataAnnotations;

using Visa_Application_API.Models;

namespace Visa_Application_API.InsertModel
{
	public class AddApplication
	{
		public string Title { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FatherName { get; set; }

		public string MotherName { get; set; }

		public string Nationality { get; set; }

		public string PlaceOfBirth { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Gender { get; set; }

		public string PassportNo { get; set; }

		public string PlaceOfIssue { get; set; }

		public DateTime DateOfIssue { get; set; }

		public DateTime DateOfExpiry { get; set; }

		public string Country { get; set; }

		public string PermanentAddress { get; set; }

		public string Telephone { get; set; }

		public string Email { get; set; }
		public string PurposeOfEntry { get; set; }
		public int VisaType { get; set; }
		public DateTime CreationDateTime { get; set; }
		public int ApplicantId { get; set; }
		public _SponsorOrHost SponsorOrHost { get; set; }
		public List<_ApplicationDocument> ApplicationDocument { get; set; }
		public List<_ApplicationStatus> ApplicationStatus { get; set; }
	}

}
