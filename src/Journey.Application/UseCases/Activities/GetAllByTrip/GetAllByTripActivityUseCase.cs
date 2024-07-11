using Journey.Communication.Responses;
using Journey.Exceptions.ExceptionsBase;
using Journey.Exceptions;
using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Activities.GetAllByTrip;
public class GetAllByTripActivityUseCase : IGetAllByTripActivityUseCase
{
    private readonly ITripRepository _tripRepository;
    private readonly IActivityRepository _activityRepository;

    public GetAllByTripActivityUseCase(
        ITripRepository tripRepository,
        IActivityRepository activityRepository)
    {
        _tripRepository = tripRepository;
        _activityRepository = activityRepository;
    }

    public async Task<ResponseActivitiesJson> ExecuteAsync(Guid tripId)
    {
        var trip = await _tripRepository.GetByIdAsync(tripId);

        if (trip is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound, "A viagem", tripId, "a"));
        }

        var activities = await _activityRepository.GetAllByTripAsync(tripId);
        var map = activities.Select(activity => new ResponseActivityJson
        {
            Id = activity.Id,
            Date = activity.Date,
            Name = activity.Name,
            TripName = $"Viagem: {activity.Trip.Name}",
            Status = (Journey.Communication.Enums.ActivityStatus)activity.Status,
        });

        return new ResponseActivitiesJson()
        {
            Activities = map,
        };
    }
}
