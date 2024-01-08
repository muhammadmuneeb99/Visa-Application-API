using Microsoft.IdentityModel.Tokens;

using Visa_Application_API.DataAccessLayer.Interface;
using Visa_Application_API.InsertModel;
using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;

namespace Visa_Application_API.BusinessObjects
{
    public class VisaService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IVisaTypeRepository _visaTypeRepository;
        public VisaService(IApplicationRepository applicationRepository, IApplicantRepository applicantRepository, IVisaTypeRepository visaTypeRepository)
        {
            _applicantRepository = applicantRepository;
            _applicationRepository = applicationRepository;
            _visaTypeRepository = visaTypeRepository;
        }

        #region Applicant
        public Result UserLogin(Authenticate model)
        {
            return _applicantRepository.Authenticate(model);
        }

        public Result GetApplicantInformation(string ApplicantId)
        {
            return _applicantRepository.GetApplicantInformation(ApplicantId);
        }
        public Result RegisterApplicant(AddApplicant applicant)
        {
            return _applicantRepository.RegisterApplicant(applicant);
        }
        public Result UpdateApplicant(AddApplicant applicant, string applicantId)
        {
            return _applicantRepository.UpdateApplicant(applicant, applicantId);
        }
        #endregion

        #region Application
        public Result CheckVisaApplicationStatus(string applicantId)
        {
            return _applicationRepository.CheckVisaApplicationStatus(applicantId);
        }

        public Result AddVisaApplication(AddApplication newApplication)
        {
            return _applicationRepository.AddVisaApplication(newApplication);
        }
        #endregion

        #region Visa Type
        public Result GetAllVisaType()
        {
            return _visaTypeRepository.GetAllVisaType();
        }
        public Result AddVisaType(VisaTypes visaTypes)
        {
            return _visaTypeRepository.AddVisaType(visaTypes);
        }
        #endregion
    }
}
