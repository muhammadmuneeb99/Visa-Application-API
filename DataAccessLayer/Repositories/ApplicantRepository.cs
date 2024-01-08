using Microsoft.AspNetCore.Mvc;

using Visa_Application_API.DataAccessLayer.Helpers;
using Visa_Application_API.DataAccessLayer.Interface;
using Visa_Application_API.InsertModel;
using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;
using Visa_Application_API.ViewModel;

namespace Visa_Application_API.DataAccessLayer.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly VisaApiDBContext _dbContext;
        public ApplicantRepository(VisaApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Result Authenticate([FromBody] Authenticate userDetails)
        {
            Result result = new Result();
            try
            {
                var userCheck = _dbContext.Applicants.FirstOrDefault(x => x.Email == userDetails.email && x.Password == userDetails.password);
                if (userCheck != null)
                {
                    var user = _dbContext.Applicants.FirstOrDefault(x => x.Email == userDetails.email);
                    result.SetSuccess("Success");
                    ApplicantInformationModel applicantInformationModel = new ApplicantInformationModel()
                    {
                        Name = user.Name,
                        ContactNo = user.ContactNo,
                        Email = userDetails.email,
                        PkApplicantId = user.PkApplicantId,
                        Username = user.Username
                    };
                    result.Obj = applicantInformationModel;
                    return result;
                }
                result.SetAuthorizationError("User Not Found");
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }

        public Result GetApplicantInformation(string ApplicantId)
        {
            Result result = new Result();
            try
            {
                var applicantInformation = _dbContext.Applicants.FirstOrDefault(x => x.PkApplicantId == int.Parse(ApplicantId));
                if (applicantInformation != null)
                {
                    ApplicantInformationModel applicantInformationModel = new ApplicantInformationModel()
                    {
                        PkApplicantId = applicantInformation.PkApplicantId,
                        ContactNo = applicantInformation.ContactNo,
                        Email = applicantInformation.Email,
                        Name = applicantInformation.Name,
                        Username = applicantInformation.Username
                    };
                    result.SetSuccess("Success");
                    result.Obj = applicantInformationModel;
                    return result;
                }
                result.SetError("Information not found");
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }

        public Result RegisterApplicant(AddApplicant applicant)
        {
            Result result = new Result();
            try
            {
                var checkApplicant = _dbContext.Applicants.FirstOrDefault(x => x.Email == applicant.Email && x.Username == applicant.Username);
                if (checkApplicant != null)
                {
                    result.SetError("User Already Exist");
                    return result;
                }

                Applicant addApplicant = new Applicant()
                {
                    Name = applicant.Name,
                    Username = applicant.Username,
                    ContactNo = applicant.ContactNo,
                    Email = applicant.Email,
                    Password = applicant.Password
                };

                _dbContext.Add(addApplicant);
                _dbContext.SaveChanges();

                result.SetSuccess("User Created successfully");
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }

        public Result UpdateApplicant(AddApplicant applicant, string applicantId)
        {
            Result result = new Result();
            try
            {
                var applicantToUpdate = _dbContext.Applicants.FirstOrDefault(x => x.PkApplicantId == int.Parse(applicantId));
                if (applicantToUpdate != null)
                {
                    applicantToUpdate.Name = applicant.Name;
                    applicantToUpdate.Username = applicant.Username;
                    applicantToUpdate.ContactNo = applicant.ContactNo;
                    applicantToUpdate.Email = applicant.Email;

                    _dbContext.Update(applicantToUpdate);
                    _dbContext.SaveChanges();

                    result.SetSuccess("Record Updated!");
                    return result;
                }

                result.SetError("Unable To Update Record!");
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }

    }
}
