using Journey.Communication.Requests;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Activities.Register;
public interface IRegisterActivityUseCase
{
    Task<ResponseActivityJson> ExecuteAsync(Guid tripId, RequestRegisterActivityJson request);
}
