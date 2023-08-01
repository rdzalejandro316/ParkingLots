using ParkingLots.Domain.Entities;
using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace ParkingLots.Infrastructure.Ports;

public interface IRepository<T> where T : DomainEntity
{
    Task<T> GetOneAsync(Guid id);
    Task<IEnumerable<T>> GetManyAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeStringProperties = "",
    bool isTracking = false);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetByIdWithIncludesAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> include);    
    Task<T> AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
    Task<bool> UpdateConfirmationAsync(T entity);
    Task<bool> DeleteConfirmationAsync(T entity);

}
