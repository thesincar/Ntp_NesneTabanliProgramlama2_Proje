using Ntp.Application.Interfaces.Repositories;
using Ntp.Application.UnitOfWorks;
using Ntp.Persistance.Context;
using Ntp.Persistance.Repositories;

namespace Ntp.Persistance.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        this._context = context;
    }
    public async ValueTask DisposeAsync() => await _context.DisposeAsync();

    public int Save() => _context.SaveChanges();

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_context);

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_context);
}