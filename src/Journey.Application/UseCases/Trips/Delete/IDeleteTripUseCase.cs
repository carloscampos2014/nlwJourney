namespace Journey.Application.UseCases.Trips.Delete;
public interface IDeleteTripUseCase
{
    Task ExecuteAsync(Guid id);
}
