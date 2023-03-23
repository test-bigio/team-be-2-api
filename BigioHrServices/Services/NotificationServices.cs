using BigioHrServices.Constant;
using BigioHrServices.Db;
using BigioHrServices.Db.Entities;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Notification;
using Microsoft.EntityFrameworkCore;

namespace BigioHrServices.Services;

public interface INotificationService
{
    public Pageable<NotificationResponse> GetList(NotificationSearchRequest request);
    public NotificationResponse GetNotificationById(long id);
    public void NotificationAdd(NotificationAddRequest request);
    public void NotificationUpdate(NotificationUpdateRequest request);
    public void NotificationDelete(long? id);
}

public class NotificationServices : INotificationService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IAuditLogService _auditLogService;

    public NotificationServices(ApplicationDbContext dbContext, IAuditLogService auditLogService)
    {
        _dbContext = dbContext;
        _auditLogService = auditLogService;
    }

    public Pageable<NotificationResponse> GetList(NotificationSearchRequest request)
    {
        var query = _dbContext.Notification
            .AsNoTracking()
            .AsQueryable();

        var data = query
            .Select(notification => new NotificationResponse
            {
                Id = notification.Id,
                Employee = notification.Employee,
                Leave = notification.Leave,
                IsView = notification.IsView,
                Content = notification.Content,
                CreatedBy = notification.CreatedBy,
                CreatedDate = notification.CreatedDate,
                UpdatedBy = notification.UpdatedBy,
                UpdatedDate = notification.UpdatedDate,
            }).ToList();

        // update is_view to true
        foreach (var item in data)
        {
            var notification = _dbContext.Notification.Find(item.Id);
            notification.IsView = true;

            _dbContext.Notification.Update(notification);
            _dbContext.SaveChanges();
        }
        
        _auditLogService.AddAuditLog(AuditLogConstant.Employee, "Read notification all notification", AuditLogConstant.List, 0);

        return new Pageable<NotificationResponse>(data, request.Page, request.PageSize);
    }

    public NotificationResponse GetNotificationById(long id)
    {
        var notification = _dbContext.Notification.Find(id);
        if (notification == null) throw new Exception("ID not found!");

        notification.IsView = true;

        _dbContext.Notification.Update(notification);
        _dbContext.SaveChanges();
        
        _auditLogService.AddAuditLog(AuditLogConstant.Employee, $"Read notification with id {id}", AuditLogConstant.GetDetail, 0);

        return _dbContext.Notification.Select(
            notification => new NotificationResponse
            {
                Id = notification.Id,
                Employee = notification.Employee,
                Leave = notification.Leave,
                IsView = notification.IsView,
                Content = notification.Content,
            }).First();
    }

    public void NotificationAdd(NotificationAddRequest request)
    {
        var data = _dbContext.Notification.Find(request.Id);
        if (data != null) throw new Exception("ID already exist!");

        _dbContext.Notification.Add(new Notification
        {
            Id = request.Id,
            EmployeeId = request.EmployeeId,
            LeaveId = request.LeaveId,
            IsView = request.IsView,
            Content = request.Content,
            CreatedBy = 0,
            CreatedDate = DateTime.UtcNow,
        });

        _dbContext.SaveChanges();
    }

    public void NotificationUpdate(NotificationUpdateRequest request)
    {
        var data = _dbContext.Notification.Find(request.Id);
        if (data == null) throw new Exception("ID not found!");

        data.Id = request.Id;
        data.EmployeeId = request.EmployeeId;
        data.LeaveId = request.LeaveId;
        data.IsView = request.IsView;
        data.Content = request.Content;
        data.UpdatedBy = 0;
        data.UpdatedDate = DateTime.UtcNow;

        _dbContext.Update(data);
        _dbContext.SaveChanges();
    }

    public void NotificationDelete(long? id)
    {
        var data = _dbContext.Notification.Find(id);
        if (data == null) throw new Exception("ID not found!");

        _dbContext.Notification.Remove(data);
        _dbContext.SaveChanges();
    }
}