using Visa_Application_API.DataAccessLayer.Helpers;
using Visa_Application_API.DataAccessLayer.Interface;
using Visa_Application_API.InsertModel;
using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;
using Visa_Application_API.ViewModel;

namespace Visa_Application_API.DataAccessLayer.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {

        private readonly VisaApiDBContext _dbContext;
        public ApplicationRepository(VisaApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Result CheckVisaApplicationStatus(string applicantId)
        {
            Result result = new Result();
            try
            {
                List<ApplicationStatusModel> statusModel = new List<ApplicationStatusModel>();

                var applicationStatuses = _dbContext.ApplicationStatus.Where(x => x.Application.ApplicantId == int.Parse(applicantId)).ToList();

                if (applicationStatuses.Count > 0)
                {
                    foreach (var item in applicationStatuses)
                    {
                        ApplicationStatusModel applicationStatusModel = new ApplicationStatusModel()
                        {
                            ApplicationId = item.Application.PkApplicationId,
                            ApplicantName = item.Application.FirstName + item.Application.LastName.ToString(),
                            ApplicationCreationDate = item.Application.CreationDateTime.ToString(),
                            ApplicationStatus = item.Status
                        };
                        statusModel.Add(applicationStatusModel);
                    }
                    result.SetSuccess("Success");
                    result.Obj = statusModel;
                    return result;
                }
                result.SetError("Visa Application Status not found");
                return result;

            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }

        public Result AddVisaApplication(AddApplication newApplication)
        {
            Result result = new Result();
            try
            {
                Application application = new Application()
                {
                    FirstName = newApplication.FirstName,
                    LastName = newApplication.LastName,
                    PassportNo = newApplication.PassportNo,
                    Country = newApplication.Country,
                    PurposeOfEntry = newApplication.PurposeOfEntry,
                    PermanentAddress = newApplication.PermanentAddress,
                    Gender = newApplication.Gender,
                    Telephone = newApplication.Telephone,
                    CreationDateTime = newApplication.CreationDateTime,
                    DateOfBirth = newApplication.DateOfBirth,
                    FatherName = newApplication.FatherName,
                    MotherName = newApplication.MotherName,
                    DateOfExpiry = newApplication.DateOfExpiry,
                    Nationality = newApplication.Nationality,
                    DateOfIssue = newApplication.DateOfIssue,
                    Email = newApplication.Email,
                    PlaceOfBirth = newApplication.PlaceOfBirth,
                    PlaceOfIssue = newApplication.PlaceOfIssue,
                    VisaType = newApplication.VisaType,
                    Title = newApplication.Title,
                    ApplicantId = newApplication.ApplicantId
                };

                _dbContext.Add(newApplication);

                SponsorOrHost sponsorOrHost = new SponsorOrHost()
                {
                    NameOfSponsorOrHost = newApplication.SponsorOrHost.NameOfSponsorOrHost,
                    Address = newApplication.SponsorOrHost.Address,
                    Country = newApplication.SponsorOrHost.Country,
                    PassportNo = newApplication.SponsorOrHost.PassportNo,
                    CreationDateTime = newApplication.SponsorOrHost.CreationDateTime,
                    Profession = newApplication.SponsorOrHost.Profession,
                    Nationality = newApplication.SponsorOrHost.Nationality,
                    Telephone = newApplication.SponsorOrHost.Telephone,
                    ApplicationId = application.PkApplicationId
                };

                _dbContext.Add(newApplication);

                foreach (var item in application.ApplicationDocument)
                {
                    ApplicationDocument applicationDocument = new ApplicationDocument()
                    {
                        DocumentName = item.DocumentName,
                        DocumentPath    = item.DocumentPath,
                        DocumentType = item.DocumentType,
                        Application = application
                    };
                    _dbContext.Add(applicationDocument);
                }

                foreach (var item in application.ApplicationStatus)
                {
                    ApplicationStatus applicationStatus = new ApplicationStatus()
                    {
                        Status=item.Status,
                        LastUpdated=item.LastUpdated,
                        Application = application

                    };
                    _dbContext.Add(applicationStatus);
                }

                _dbContext.SaveChanges();

                result.SetSuccess("Application Request Created successfully");
                return result;

            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }

    }
}
