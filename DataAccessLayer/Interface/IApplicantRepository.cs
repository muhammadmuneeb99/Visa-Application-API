using Microsoft.AspNetCore.Mvc;

using Visa_Application_API.InsertModel;
using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;
using Visa_Application_API.ViewModel;

namespace Visa_Application_API.DataAccessLayer.Interface
{
    public interface IApplicantRepository
    {
        Result Authenticate([FromBody] Authenticate userDetails);
        Result GetApplicantInformation(string ApplicantId);
        Result RegisterApplicant([FromBody] AddApplicant applicant);
        Result UpdateApplicant([FromBody] AddApplicant applicant, string applicantId);
    }
}
