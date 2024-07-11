using FluentValidation;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exceptions;
using Journey.Exceptions.ExceptionsBase;
using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Trips.Update;
public class UpdateTripUseCase : IUpdateTripUseCase
{
    private readonly IValidator<RequestRegisterTripJson> _validator;
    private readonly ITripRepository _tripRepository;

    public UpdateTripUseCase(
        IValidator<RequestRegisterTripJson> validator, 
        ITripRepository tripRepository)
    {
        _validator = validator;
        _tripRepository = tripRepository;
    }

    public async Task<ResponseTripJson> ExecuteAsync(Guid id, RequestRegisterTripJson request)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            throw new ValidationsException(String.Join(
                Environment.NewLine,
                validation.Errors.Select(error => error.ErrorMessage)));
        }

        var trip = await _tripRepository.GetByIdAsync(id);
        if (trip is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound, "A viagem", id, "a"));
        }

        trip.StartDate = request.StartDate;
        trip.EndDate = request.EndDate;
        trip.Name = request.Name;

        await _tripRepository.UpdateAsync(trip);
        return new ResponseTripJson()
        {
            Id = trip.Id,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            Name = trip.Name,
            Activities = trip.Activities.Select(activity => new ResponseActivityJson
            {
                Id = activity.Id,
                Name = activity.Name,
                Date = activity.Date,
                Status = (Journey.Communication.Enums.ActivityStatus)activity.Status,
                TripName = $"Viagem: {trip.Name}",
            }).ToList(),
        };
    }
}
