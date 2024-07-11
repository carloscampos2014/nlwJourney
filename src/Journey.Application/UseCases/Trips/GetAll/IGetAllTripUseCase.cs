using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.GetAll;
public interface IGetAllTripUseCase
{
    Task<ResponseTripsJson> ExecuteAsync();
}
