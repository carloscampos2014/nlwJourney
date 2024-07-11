using Journey.Communication.Responses;
using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Activities.GetAll;
public class GetAllActivityUseCase : IGetAllActivityUseCase
{
    private readonly IActivityRepository _activityRepository;

    public GetAllActivityUseCase(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<ResponseActivitiesJson> ExecuteAsync()
    {
        var activities = await _activityRepository.GetAllAsync();
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
