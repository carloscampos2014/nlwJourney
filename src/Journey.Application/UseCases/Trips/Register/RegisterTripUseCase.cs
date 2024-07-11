using FluentValidation;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exceptions.ExceptionsBase;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Trips.Register;
public class RegisterTripUseCase : IRegisterTripUseCase
{
    private readonly IValidator<RequestRegisterTripJson> _validator;
    private readonly ITripRepository _tripRepository;

    public RegisterTripUseCase(
        IValidator<RequestRegisterTripJson> validator,
        ITripRepository tripRepository)
    {
        _validator = validator;
        _tripRepository = tripRepository;
    }

    public async Task<ResponseTripJson> ExecuteAsync(RequestRegisterTripJson request)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            throw new ValidationsException(String.Join(
                Environment.NewLine,
                validation.Errors.Select(error => error.ErrorMessage)));
        }

        var trip = new Trip()
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };

        await _tripRepository.InsertAsync(trip);

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
