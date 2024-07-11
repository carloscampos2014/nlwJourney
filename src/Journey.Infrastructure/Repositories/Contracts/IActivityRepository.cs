using Journey.Infrastructure.Entities;

namespace Journey.Infrastructure.Repositories.Contracts;
public interface IActivityRepository
{
    Task<IEnumerable<Activity>> GetAllAsync();

    Task<IEnumerable<Activity>> GetAllByTripAsync(Guid tripId);

    Task<Activity?> GetByIdAsync(Guid id);

    Task InsertAsync(Activity entity);

    Task UpdateAsync(Activity entity);

    Task DeleteAsync(Guid id);
}
