using BigioHrServices.Model;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Employee;
using BigioHrServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BigioHrServices.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;
        private readonly string RequestNull = "Request cannot be null!";

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [AllowAnonymous]
        [HttpGet("get-list")]
        public Pageable<EmployeeResponse> GetEmployees([FromQuery] EmployeeSearchRequest request)
        {
            if(request == null) throw new Exception(RequestNull);

            request.Page = request.Page < 0 ? 0 : request.Page;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;

            return _employeeService.GetList(request);
        }
        
        [AllowAnonymous]
        [HttpGet("leave/{nik}")]
        public EmployeeLeaveResponse GetEmployeeLeaveByNik(string? nik)
        {
            if(nik == null) throw new Exception(RequestNull);

            return _employeeService.GetEmployeeLeaveByNik(nik);
        }
        
        [AllowAnonymous]
        [HttpGet("leave/{id:int}")]
        public EmployeeLeaveResponse GetEmployeeLeaveById(int? id)
        {
            if(id == null) throw new Exception(RequestNull);

            return _employeeService.GetEmployeeLeaveById(id.Value);
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public BaseResponse AddEmployee([FromBody] EmployeeAddRequest request)
        {
            if (request == null) throw new Exception(RequestNull);

            var getExisting = _employeeService.GetEmployeeByNIK(request.NIK);
            if (getExisting != null) throw new Exception("NIK already exist!");

            _employeeService.EmployeeAdd(request);

            return new BaseResponse(true,"Employee added successfully!");
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public BaseResponse UpdateEmployee([FromBody] EmployeeUpdateRequest request)
        {
            if (request == null) throw new Exception(RequestNull);

            var getExisting = _employeeService.GetEmployeeByNIK(request.NIK);
            if (getExisting == null) throw new Exception("NIK not found!");

            _employeeService.EmployeeUpdate(request);

            return new BaseResponse(true,"Employee updated successfully!");
        }

        [AllowAnonymous]
        [HttpDelete("delete")]
        public BaseResponse DeleteEmployee([FromQuery] string nik)
        {
            if (string.IsNullOrEmpty(nik)) throw new Exception(RequestNull);

            var getExisting = _employeeService.GetEmployeeByNIK(nik);
            if (getExisting == null) throw new Exception("NIK not found!");

            _employeeService.EmployeeDelete(nik);

            return new BaseResponse(true,"Employee deleted successfully!");
        }
    }
}
