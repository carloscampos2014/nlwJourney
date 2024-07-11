using Journey.Communication.Enums;
using System.Text.Json.Serialization;

namespace Journey.Communication.Requests;
public class RequestRegisterActivityJson
{
    public string Name { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;

    [JsonIgnore]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
}
