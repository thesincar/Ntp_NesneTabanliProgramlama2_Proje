using Microsoft.EntityFrameworkCore.Query;
using Ntp.Domain.Common;
using System.Linq.Expressions;

namespace Ntp.Application.Interfaces.Repositories;

public interface IReadRepository<T> where T : class, IEntityBase, new()
{
    Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false);


    //await data.getAllAsync(
    //    x=>x.Isactive=true,      x=>x.Date>01.02.2026,     x=>x.Name.Contains("a"),   x=>x.Id>5,    x=>x.Id<10   predicate
    //    t=>t.include(x=>x.Category)
    //    t=>t.orderBy(x=>x.Name)
    //    false)
    //    
    // await data.getAllAsync()

    Task<List<T>> GetAllByPagingAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false,
        int currentPage = 1,
        int pageSize = 3);

    //await data.getAllByPagingAsync(
    //    x=>x.Isactive=true,      x=>x.Date>01.02.2026,     x=>x.Name.Contains("a"),   x=>x.Id>5,    x=>x.Id<10   predicate
    //    t=>t.include(x=>x.Category)
    //    t=>t.orderBy(x=>x.Name)
    //    false,
    //    1,
    //    10)

    //Skip (Atla) ((currentPage-1) * pageSize Take (al) pagesize)
    //(1-1)*10=0  skip 0 take 10 => 1-10
    //(2-1)*10=10 skip 10 take 10 => 11-20
    //(3-1)*10=20 skip 20 take 10 => 21-30


    Task<T> GetAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = false);

    //await data.GetAsync(
    //    x=>x.Id=10  
    //    t=>t.include(x=>x.Category)
    //    false)

    IQueryable<T> Find(
        Expression<Func<T, bool>> predicate,
        bool enableTracking = false);

    //var sonuc= data.Find( x=>x.Isactive)

    // var netice=sonuc. OderBy(x=>x.Id)

    //var sonuc2=netice.Take(5).tolist()

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    //var total=await data.CountAsync(x=>x.Isactive)
}
