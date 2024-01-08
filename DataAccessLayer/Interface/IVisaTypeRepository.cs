using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;
using Visa_Application_API.ViewModel;

namespace Visa_Application_API.DataAccessLayer.Interface
{
    public interface IVisaTypeRepository
    {
        Result GetAllVisaType();
        Result AddVisaType(VisaTypes visaTypes);
    }
}
