using Journey.Communication.Requests;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.Update;
public interface IUpdateTripUseCase
{
    Task<ResponseTripJson> ExecuteAsync(Guid id, RequestRegisterTripJson request);
}
