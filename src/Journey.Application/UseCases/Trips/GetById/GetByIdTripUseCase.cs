using Journey.Communication.Responses;
using Journey.Exceptions;
using Journey.Exceptions.ExceptionsBase;
using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Trips.GetById;
public class GetByIdTripUseCase : IGetByIdTripUseCase
{
    private readonly ITripRepository _tripRepository;

    public GetByIdTripUseCase(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<ResponseTripJson> ExecuteAsync(Guid id)
    {
        var trip = await _tripRepository.GetByIdAsync(id);

        if (trip is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound,"A viagem", id, "a"));
        }

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
