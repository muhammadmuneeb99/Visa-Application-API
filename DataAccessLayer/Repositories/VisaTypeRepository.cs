using Visa_Application_API.DataAccessLayer.Helpers;
using Visa_Application_API.DataAccessLayer.Interface;
using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;
using Visa_Application_API.ViewModel;

namespace Visa_Application_API.DataAccessLayer.Repositories
{
    public class VisaTypeRepository : IVisaTypeRepository
    {
        private readonly VisaApiDBContext _dbContext;
        public VisaTypeRepository(VisaApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Result GetAllVisaType()
        {
            Result result = new Result();
            try
            {
                var visaTypes = _dbContext.VisaTypes.ToList();
                if (visaTypes.Count > 0)
                {
                    result.SetSuccess("Success");
                    result.Obj = visaTypes;
                    return result;
                }
                result.SetError("Accessory not found");
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }
        public Result AddVisaType(VisaTypes visaTypes)
        {
            Result result = new Result();
            try
            {
                var visaType = _dbContext.VisaTypes.FirstOrDefault(x => x.PkVisaTypeId == visaTypes.PkVisaTypeId && x.VisaType == visaTypes.VisaType);
                if (visaType != null)
                {

                    result.SetError("Visa Type already Exist!");
                    return result;

                }
                _dbContext.Add(visaTypes);
                _dbContext.SaveChanges();

                result.SetSuccess("New VisaType Added!");
                result.Obj = visaTypes;
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, result);
            }
        }
    }
}
