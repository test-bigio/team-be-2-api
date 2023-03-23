using BigioHrServices.Db.Entities;
using BigioHrServices.Model;
using BigioHrServices.Model.Auth;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Employee;
using BigioHrServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace BigioHrServices.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController
    {
        private readonly IEmployeeService _employeeService;
        private readonly string _requestNull = "Request cannot be null!";

        public AuthController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpPost("login")]
        public AuthLoginResponse GetEmployees([FromQuery] AuthLoginRequest request)
        {
            var employee =  _employeeService.AuthenticateUser(request.NIK, request.Password);

            return employee;
        }
        
        [HttpPost("reset-password")]
        public BaseResponse ResetPassword([FromQuery] ResetPassword request)
        {
            BaseResponse response =  _employeeService.ResetPassword(request.NIK, request.password);
        
            return response;
        }

        [HttpPost("update-pin-signature")]
        public BaseResponse UpdatePinSignature([FromQuery] UpdateSignatureRequest request)
        {
            BaseResponse response =  _employeeService.UpdatePinSignature(request.NIK, request.lastSignature,  request.newSignature);

            return response;

        }
        
        [HttpPost("add-pin-signature")]
        public BaseResponse AddPinSignature([FromQuery] AddSignatureRequest request)
        {
            BaseResponse response =  _employeeService.AddPinSignature(request.NIK, request.newSignature);

            return response;
        }
    }
}
