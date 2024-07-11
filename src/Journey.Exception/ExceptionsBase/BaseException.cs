using Journey.Communication.Responses;
using System.Net;

namespace Journey.Exceptions.ExceptionsBase;
public abstract class BaseException : SystemException
{
    protected BaseException(string? message) : base(message)
    {
    }

    public abstract HttpStatusCode GetStatusCode();

    public abstract ErrorResponseJson GetErrorModel();
}
