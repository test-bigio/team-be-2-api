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
        
        [AllowAnonymous]
        [HttpGet("list-by-reviewer")]
        public BaseResponse ListReviewLeave([FromQuery] DatatableRequest request)
        {
            if(request == null) throw new Exception(_requestNull);

            request.Page = request.Page < 0 ? 0 : request.Page;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            
            return new BaseResponse(_leaveApplicationService.ListReviewLeave(request), "success");
        }
        
        [AllowAnonymous]
        [HttpGet("list-by-nik")]
        public BaseResponse ListLeaveByNik([FromQuery] DatatableRequest request)
        {
            if(request == null) throw new Exception(_requestNull);

            request.Page = request.Page < 0 ? 0 : request.Page;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            
            return new BaseResponse(_leaveApplicationService.ListLeaveByNik(request), "success");
        }
        
        [AllowAnonymous]
        [HttpPost("review/{id:long}")]
        public BaseResponse ReviewLeave([FromRoute] long id, [FromBody] ReviewRequest request)
        {
            return new BaseResponse(true, _leaveApplicationService.ReviewLeave(id, request));
        }
    }
}