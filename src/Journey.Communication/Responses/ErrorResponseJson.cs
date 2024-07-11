namespace Journey.Communication.Responses;
public class ErrorResponseJson
{
    public ErrorResponseJson(string status, string[] errors)
    {
        Status = status;
        Errors = errors;
    }

    public string Status { get; private set; }

    public string[] Errors { get; private set; }
}
