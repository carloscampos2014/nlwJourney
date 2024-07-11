using Journey.Infrastructure.Repositories.Contracts;

namespace Journey.Application.UseCases.Activities.Delete;
public class DeleteActivityUseCase : IDeleteActivityUseCase
{
    private readonly IActivityRepository _activityRepository;

    public DeleteActivityUseCase(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _activityRepository.DeleteAsync(id);
    }
}
