using Journey.Communication.Responses;
using Journey.Exceptions;
using Journey.Exceptions.ExceptionsBase;
using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Activities.GetById;
public class GetByIdActivityUseCase : IGetByIdActivityUseCase
{
    private readonly IActivityRepository _activityRepository;

    public GetByIdActivityUseCase(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<ResponseActivityJson> ExecuteAsync(Guid id)
    {
        var activity = await _activityRepository.GetByIdAsync(id);
        if (activity is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound, "A atividade", id, "a"));
        }

        return new ResponseActivityJson()
        {
            Id = activity.Id,
            Date = activity.Date,
            Name = activity.Name,
            TripName = $"Viagem: {activity.Trip.Name}",
            Status = (Journey.Communication.Enums.ActivityStatus)activity.Status,
        };
    }
}
