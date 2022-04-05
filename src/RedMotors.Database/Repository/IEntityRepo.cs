namespace RedMotors.Database.Repository;

public interface IEntityRepo<TEntity>
    where TEntity : class
{

    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(Guid id, TEntity entity);
    Task DeleteAsync(Guid id);
}
