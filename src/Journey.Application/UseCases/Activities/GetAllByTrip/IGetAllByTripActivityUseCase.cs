using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Activities.GetAllByTrip;
public interface IGetAllByTripActivityUseCase
{
    Task<ResponseActivitiesJson> ExecuteAsync(Guid tripId);
}
