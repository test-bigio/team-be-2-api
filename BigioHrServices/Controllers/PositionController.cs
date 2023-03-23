using BigioHrServices.Db.Entities;
using BigioHrServices.Model;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Position;
using BigioHrServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BigioHrServices.Controllers;

[ApiController]
[Route("Position")]
public class PositionController
{
    private readonly IPositionService _service;
    private const string RequestNull = "Request cannot be null!";

    public PositionController(IPositionService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet("get-list")]
    public Pageable<PositionResponse> GetPositions([FromQuery] PositionSearchRequest request)
    {
        if (request == null) throw new Exception(RequestNull);

        request.Page = request.Page < 0 ? 0 : request.Page;
        request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;

        return _service.GetList(request);
    }
    
    [AllowAnonymous]
    [HttpGet("get-detail")]
    public Position? GetPosition([FromQuery] long id)
    {
        return _service.GetPositionById(id);
    }

    [AllowAnonymous]
    [HttpPost("add")]
    public BaseResponse AddPosition([FromBody] PositionAddRequest request)
    {
        if (request == null) throw new Exception(RequestNull);
        _service.PositionAdd(request);
    
        return new BaseResponse() { Data = true, Message = "Add success!" };
    }
    
    [AllowAnonymous]
    [HttpPut("update")]
    public BaseResponse UpdatePosition([FromBody] PositionUpdateRequest request)
    {
        if(request == null) throw new Exception(RequestNull);
        _service.PositionUpdate(request);
    
        return new BaseResponse() { Data = true, Message = "Update Success!" };
    }
    
    [AllowAnonymous]
    [HttpPut("deactivate")]
    public BaseResponse PositionDeactive([FromQuery] long? id)
    {
        _service.PositionDeactive(id);
    
        return new BaseResponse() { Data = true, Message = "Position deactivated!" };
    }
}