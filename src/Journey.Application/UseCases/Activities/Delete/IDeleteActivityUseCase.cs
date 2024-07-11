namespace Journey.Application.UseCases.Activities.Delete;
public interface IDeleteActivityUseCase
{
    Task ExecuteAsync(Guid id);
}
