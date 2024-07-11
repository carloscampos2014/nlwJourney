using Journey.Communication.Requests;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Activities.Update;
public interface IUpdateActivityUseCase
{
    Task<ResponseActivityJson> ExecuteAsync(Guid id, RequestRegisterActivityJson request);
}
