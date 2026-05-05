using Microsoft.EntityFrameworkCore;
using Ntp.Application.Interfaces.Repositories;
using Ntp.Domain.Common;

namespace Ntp.Persistance.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{
    private readonly DbContext _context;
    public WriteRepository(DbContext context)
    {
        this._context = context;
    }
    private DbSet<T> Table { get => _context.Set<T>(); }
    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public async Task HardDeleteAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;
    }
    public async Task HardDeleteRangeAsync(IList<T> entity)
    {
        await Task.Run(() => Table.RemoveRange(entity));
    }
}
