using Journey.Exceptions.ExceptionsBase;
using Journey.Exceptions;
using Journey.Infrastructure.Context;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure.Repositories;
public class ActivityRepository : IActivityRepository
{
    private readonly JourneyDbContext _context;

    public ActivityRepository(JourneyDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            throw new NotFoundException(string.Format(ErrorMessages.NotFound, "A atividade", id, "a"));
        }

        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await _context.Activities
            .Include(i => i.Trip)
            .ToListAsync();
    }

    public async Task<IEnumerable<Activity>> GetAllByTripAsync(Guid tripId)
    {
        return await _context.Activities
            .Include(i => i.Trip)
            .Where(w => w.TripId == tripId)
            .ToListAsync();
    }

    public async Task<Activity?> GetByIdAsync(Guid id)
    {
        return await _context.Activities
            .Include(i => i.Trip)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task InsertAsync(Activity entity)
    {
        if (entity is null)
        {
            throw new ValidationsException($"{string.Format(ErrorMessages.RequestRegisterNullExeptionMessage, "atividade")}{Environment.NewLine}");
        }

        await _context.Activities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Activity entity)
    {
        if (entity is null)
        {
            throw new ValidationsException($"{string.Format(ErrorMessages.RequestRegisterNullExeptionMessage, "atividade")}{Environment.NewLine}");
        }

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
