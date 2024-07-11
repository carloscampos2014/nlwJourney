using Journey.Communication.Responses;
using System.Net;

namespace Journey.Exceptions.ExceptionsBase;
public class ValidationsException : BaseException
{
    public ValidationsException(string? message) : base(message)
    {
    }

    public override ErrorResponseJson GetErrorModel()
    {
        return new ErrorResponseJson(
            ErrorMessages.TypeErrorValidation,
            Message.Split(Environment.NewLine));
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }
}
