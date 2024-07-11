using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Trips.Delete;
public class DeleteTripUseCase : IDeleteTripUseCase
{
    private readonly ITripRepository _tripRepository;

    public DeleteTripUseCase(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _tripRepository.DeleteAsync(id);
    }
}
