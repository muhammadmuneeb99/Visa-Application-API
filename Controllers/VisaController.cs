using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Visa_Application_API.BusinessObjects;
using Visa_Application_API.InsertModel;
using Visa_Application_API.Models;
using Visa_Application_API.ServiceModel;

using static System.Net.Mime.MediaTypeNames;

using Application = Visa_Application_API.Models.Application;

namespace Visa_Application_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaController : ControllerBase
    {
        private readonly VisaService _visaService;
        public VisaController(VisaService visaService)
        {
            _visaService = visaService;
        }

        #region Applicant
        [HttpPost("UserLogin")]
        public IActionResult UserLogin([FromBody] Authenticate model)
        {
            var result = _visaService.UserLogin(model);

            var response = GetActionResult(result) as ObjectResult;
            if (response.StatusCode == 200)
            {
                return Ok(response.Value);
            }
            return response;
        }
        [HttpGet("GetApplicantInformation")]
        public IActionResult GetApplicantInformation(string ApplicantId)
        {
            Result result = new Result();

            result = _visaService.GetApplicantInformation(ApplicantId);
            return GetActionResult(result);
        }
        [HttpPost("RegisterApplicant")]
        public IActionResult RegisterApplicant([FromBody] AddApplicant applicant)
        {
            Result result = new Result();

            result = _visaService.RegisterApplicant(applicant);
            return GetActionResult(result);

        }
        [HttpPost("UpdateApplicant")]
        public IActionResult UpdateApplicant([FromBody] AddApplicant applicant, string applicantId)
        {
            Result result = new Result();

            result = _visaService.UpdateApplicant(applicant, applicantId);
            return GetActionResult(result);
        }
        #endregion

        #region Application
        [HttpPost("CheckVisaApplicationStatus")]
        public IActionResult CheckVisaApplicationStatus(string applicantId)
        {
            Result result = new Result();

            result = _visaService.CheckVisaApplicationStatus(applicantId);
            return GetActionResult(result);
        }

        [HttpPost("AddVisaApplication")]
        public IActionResult AddVisaApplication([FromBody] AddApplication newApplication)
        {
            Result result = new Result();

            result = _visaService.AddVisaApplication(newApplication);
            return GetActionResult(result);
        }
        #endregion

        #region Visa Type
        [HttpGet("GetAllVisaType")]
        public IActionResult GetAllVisaType()
        {
            Result result = new Result();

            result = _visaService.GetAllVisaType();
            return GetActionResult(result);
        }
        [HttpPost("AddVisaType")]
        public IActionResult AddVisaType(VisaTypes visaTypes)
        {
            Result result = new Result();

            result = _visaService.AddVisaType(visaTypes);
            return GetActionResult(result);
        }
        #endregion


        [HttpPost("GetActionResult")]
        public IActionResult GetActionResult(Result result)
        {
            try
            {
                if (result.Error)
                {
                    return Conflict(new { message = result.ErrMsg });
                }
                else if (result.AuthorizationError)
                {
                    return Unauthorized(new { message = result.ErrMsg });
                }
                else
                {
                    if (result.Obj != null)
                    {
                        return Ok(result.Obj);
                    }
                    else
                    {
                        return Ok(new { message = result.Msg });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
