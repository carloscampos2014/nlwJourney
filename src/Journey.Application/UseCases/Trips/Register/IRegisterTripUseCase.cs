using Journey.Communication.Requests;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.Register;
public interface IRegisterTripUseCase
{
    Task<ResponseTripJson> ExecuteAsync(RequestRegisterTripJson request);
}
