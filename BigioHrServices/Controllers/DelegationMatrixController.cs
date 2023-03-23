using BigioHrServices.Model;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.DelegationMatrix;
using BigioHrServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BigioHrServices.Controllers;

[ApiController]
[Route("DelegationMatrix")]
public class DelegationMatrixController
{
    private readonly IDelegationMatrixService _delegationMatrixService;
    private readonly string RequestNull = "Request cannot be null";

    public DelegationMatrixController(IDelegationMatrixService delegationMatrixService)
    {
        _delegationMatrixService = delegationMatrixService;
    }

    [AllowAnonymous]
    [HttpGet("get-list")]
    public Pageable<DelegationMatrixResponse> GetDelegationMatrix([FromQuery] DelegationMatrixRequest request)
    {
        if (request == null) throw new Exception(RequestNull);

        request.Page = request.Page < 0 ? 0 : request.Page;
        request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;

        return _delegationMatrixService.GetList(request);
    }

    [AllowAnonymous]
    [HttpPost("add")]
    public BaseResponse AddDelegationMatrix([FromBody] DelegationMatrixAddRequest request)
    {
        if (request == null) throw new Exception(RequestNull);
        
        _delegationMatrixService.DelegationMatrixAdd(request);

        return new BaseResponse();
    }

    [AllowAnonymous]
    [HttpPut("update")]
    public BaseResponse UpdateDelegationMatrix([FromQuery] long id, [FromBody] DelegationMatrixUpdateRequest request)
    {
        if (string.IsNullOrEmpty(id.ToString())) throw new Exception(RequestNull);

        var getExisiting = _delegationMatrixService.getById(id);
        if (getExisiting == null) throw new Exception("Data not found");
        
        _delegationMatrixService.DelegationMatrixUpdate(id, request);

        return new BaseResponse() { Data = true, Message = "Update Success!" };
    }

    [AllowAnonymous]
    [HttpGet("get-by-employee-id")]
    public List<DelegationMatrixResponse> GetByEmployeeId([FromQuery] long id)
    {
        return _delegationMatrixService.GetByEmployeeId(id);
    }
}