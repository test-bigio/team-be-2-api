namespace BigioHrServices.Model.Notification;

public class NotificationResponse: BaseModelResponse
{
    public long Id { get; set; }
    public Db.Entities.Employee Employee { get; set; }
    public Db.Entities.Leave Leave { get; set; }
    public bool IsView { get; set; }
    public string Content { get; set; }
}