using Visa_Application_API.InsertModel;
using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;

namespace Visa_Application_API.DataAccessLayer.Interface
{
    public interface IApplicationRepository
    {
        Result CheckVisaApplicationStatus(string applicantId);
        Result AddVisaApplication(AddApplication newApplication);
    }
}
