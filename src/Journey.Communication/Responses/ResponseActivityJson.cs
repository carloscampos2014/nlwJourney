using Journey.Communication.Enums;

namespace Journey.Communication.Responses;
public class ResponseActivityJson
{
    public Guid Id { get; set; }  = Guid.NewGuid();
    
    public string Name { get; set; } = string.Empty;
    
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;

    public string  TripName { get; set; } = string.Empty;
}
