using FluentValidation;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exceptions.ExceptionsBase;
using Journey.Exceptions;
using Journey.Infrastructure.Repositories.Contracts;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Activities.Register;
public class RegisterActivityUseCase : IRegisterActivityUseCase
{
    private readonly IValidator<RequestRegisterActivityJson> _validator;
    private readonly ITripRepository _tripRepository;
    private readonly IActivityRepository _activityRepository;

    public RegisterActivityUseCase(
        IValidator<RequestRegisterActivityJson> validator, 
        ITripRepository tripRepository, 
        IActivityRepository activityRepository)
    {
        _validator = validator;
        _tripRepository = tripRepository;
        _activityRepository = activityRepository;
    }

    public async Task<ResponseActivityJson> ExecuteAsync(Guid tripId, RequestRegisterActivityJson request)
    {
        var trip = await _tripRepository.GetByIdAsync(tripId);

        if (trip is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound, "A viagem", tripId, "a"));
        }

        request.StartDate = trip.StartDate;
        request.EndDate = trip.EndDate;

        var validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            throw new ValidationsException(String.Join(
                Environment.NewLine,
                validation.Errors.Select(error => error.ErrorMessage)));
        }

        var activity = new Activity()
        {
            TripId = tripId,
            Name = request.Name,
            Date = request.Date,
            Status = (Infrastructure.Enums.ActivityStatus)request.Status,
            Trip = trip,
        };

        await _activityRepository.InsertAsync(activity);

        return new ResponseActivityJson()
        {
            Id = activity.Id,
            Date = activity.Date,
            Name = activity.Name,
            TripName = $"Viagem: {trip.Name}",
            Status = (Journey.Communication.Enums.ActivityStatus)activity.Status,
        };
    }
}
