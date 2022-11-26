namespace SparkPlug.Common;

public interface IRepository<TId, TEntity>
{
    Task<IEnumerable<TEntity>> ListAsync(IQueryRequest<TEntity> request);
    Task<TEntity> GetAsync(TId Id);
    Task<TEntity> CreateAsync(ICommandRequest<TEntity> entity);
    Task<TEntity> UpdateAsync(TId Id, ICommandRequest<TEntity> entity);
    Task<TEntity> PatchAsync(TId Id, ICommandRequest<TEntity> entity);
    Task<TEntity> ReplaceAsync(TId Id, ICommandRequest<TEntity> entity);
    Task<TEntity> DeleteAsync(TId Id);
    Task<long> GetCountAsync(IQueryRequest<TEntity> request);
}