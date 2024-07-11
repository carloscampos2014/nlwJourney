using Journey.Communication.Responses;
using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Trips.GetAll;
public class GetAllTripUseCase : IGetAllTripUseCase
{
    private readonly ITripRepository _tripRepository;

    public GetAllTripUseCase(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<ResponseTripsJson> ExecuteAsync()
    {
        var trips = await _tripRepository.GetAllAsync();
        var maps = trips.Select(trip => new ResponseShortTripJson
        {
            Id = trip.Id,
            Name = trip.Name,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate
        }).ToList();

        return new ResponseTripsJson()
        {
            Trips = maps,
        };
    }
}
