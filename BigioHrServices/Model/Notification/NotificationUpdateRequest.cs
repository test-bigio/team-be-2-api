namespace BigioHrServices.Model.Notification;

public class NotificationUpdateRequest
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long LeaveId { get; set; }
    public bool IsView { get; set; }
    public string Content { get; set; }
}