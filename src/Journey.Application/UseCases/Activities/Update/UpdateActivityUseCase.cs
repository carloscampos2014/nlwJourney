using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exceptions.ExceptionsBase;
using Journey.Exceptions;
using Journey.Infrastructure.Repositories.Contracts;
using FluentValidation;

namespace Journey.Application.UseCases.Activities.Update;
public class UpdateActivityUseCase : IUpdateActivityUseCase
{
    private readonly IValidator<RequestRegisterActivityJson> _validator;
    private readonly IActivityRepository _activityRepository;

    public UpdateActivityUseCase(
        IValidator<RequestRegisterActivityJson> validator,
        IActivityRepository activityRepository)
    {
        _validator = validator;
        _activityRepository = activityRepository;
    }

    public async Task<ResponseActivityJson> ExecuteAsync(Guid id, RequestRegisterActivityJson request)
    {
        var activity = await _activityRepository.GetByIdAsync(id);
        if (activity is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound, "A atividade", id, "a"));
        }

        request.StartDate = activity.Trip.StartDate;
        request.EndDate = activity.Trip.EndDate;

        var validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            throw new ValidationsException(String.Join(
                Environment.NewLine,
                validation.Errors.Select(error => error.ErrorMessage)));
        }

        activity.Name = request.Name;
        activity.Date = request.Date;
        activity.Status = (Infrastructure.Enums.ActivityStatus)request.Status;

        await _activityRepository.UpdateAsync(activity);

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
