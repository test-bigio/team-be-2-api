using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Notification;
using BigioHrServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BigioHrServices.Controllers;

[ApiController]
[Route("Notification")]
public class NotificationController
{
    private readonly INotificationService _service;
    private const string RequestNull = "Request cannot be null!";

    public NotificationController(INotificationService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet("get-list")]
    public Pageable<NotificationResponse> GetNotifications([FromQuery] NotificationSearchRequest request)
    {
        if (request == null) throw new Exception(RequestNull);

        request.Page = request.Page < 0 ? 0 : request.Page;
        request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;

        return _service.GetList(request);
    }
    
    [AllowAnonymous]
    [HttpGet("get-detail")]
    public NotificationResponse GetPosition([FromQuery] long id)
    {
        return _service.GetNotificationById(id);
    }
    

    // [AllowAnonymous]
    // [HttpPost("add")]
    // public BaseResponse AddNotification([FromBody] NotificationAddRequest request)
    // {
    //     _service.NotificationAdd(request);
    //
    //     return new BaseResponse();
    // }
    //
    // [AllowAnonymous]
    // [HttpPut("update")]
    // public BaseResponse UpdateNotification([FromBody] NotificationUpdateRequest request)
    // {
    //     _service.NotificationUpdate(request);
    //
    //     return new BaseResponse { Data = true, Message = "Update success!" };
    // }
    //
    // [AllowAnonymous]
    // [HttpDelete("delete")]
    // public BaseResponse DeleteNotification([FromQuery] long? id)
    // {
    //     _service.NotificationDelete(id);
    //
    //     return new BaseResponse { Data = true, Message = "Delete success!" };
    // }
}