using Journey.Communication.Responses;
using System.Net;

namespace Journey.Exceptions.ExceptionsBase;
public class NotFoundException : BaseException
{
    public NotFoundException(string? message) : base(message)
    {
    }

    public override ErrorResponseJson GetErrorModel()
    {
        return new ErrorResponseJson(
            ErrorMessages.TypeErrorNotFound,
            [ Message ]);
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }
}
