using Journey.Infrastructure.Entities;

namespace Journey.Infrastructure.Repositories.Contracts;
public interface ITripRepository
{
    Task<IEnumerable<Trip>> GetAllAsync();

    Task<Trip?> GetByIdAsync(Guid id);

    Task InsertAsync(Trip entity);

    Task UpdateAsync(Trip entity);

    Task DeleteAsync(Guid id);
}
