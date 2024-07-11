namespace Journey.Communication.Responses;
public class ResponseShortTripJson
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; } = string.Empty;
    
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
}
