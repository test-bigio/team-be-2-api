using BigioHrServices.Model;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Employee;
using BigioHrServices.Model.LeaveApplication;
using BigioHrServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BigioHrServices.Model;
using BigioHrServices.Model.Employee;
using Microsoft.AspNetCore.Authorization;

namespace BigioHrServices.Controllers
{
    [ApiController]
    [Route("LeaveApplication")]
    public class LeaveApplicationController
    {
        private readonly ILeaveApplicationService _leaveApplicationService;
        private readonly string _requestNull = "Request cannot be null!";

        public LeaveApplicationController(ILeaveApplicationService leaveApplicationService)
        {
            _leaveApplicationService = leaveApplicationService;
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public BaseResponse AddLeave(LeaveAddRequest request)
        {
            if (request == null) throw new Exception(_requestNull);
            return _leaveApplicationService.LeaveAdd(request);
        }
    }
}