using Journey.Exceptions;
using Journey.Exceptions.ExceptionsBase;
using Journey.Infrastructure.Context;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure.Repositories;
public class TripRepository : ITripRepository
{
    private readonly JourneyDbContext _context;

    public TripRepository(JourneyDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound, "A viagem", id, "a"));
        }

        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Trip>> GetAllAsync()
    {
        return await _context.Trips
            .ToListAsync();
    }

    public async Task<Trip?> GetByIdAsync(Guid id)
    {
        return await _context.Trips
            .Include(i => i.Activities)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task InsertAsync(Trip entity)
    {
        if (entity is null)
        {
            throw new ValidationsException($"{ErrorMessages.RequestRegisterNullExeptionMessage}{Environment.NewLine}");
        }

        await _context.Trips.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Trip entity)
    {
        if (entity is null)
        {
            throw new ValidationsException($"{ErrorMessages.RequestRegisterNullExeptionMessage}{Environment.NewLine}");
        }

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
