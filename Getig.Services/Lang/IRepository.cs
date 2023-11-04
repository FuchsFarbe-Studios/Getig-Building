namespace Getig.Services.Language
{
    /// <summary>
    ///     A general purpose repository pattern interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        ///     Asynchronously get all entities.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        ///     Asynchronously get an entity by its id.
        /// </summary>
        /// <param name="id">The id of the entity to get.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the entity found, or null.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        ///     Asynchronously get an entity by its id where id is a string.
        /// </summary>
        /// <param name="id">The id of the entity to get.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the entity found, or null.</returns>
        Task<TEntity> GetByIdAsync(string id);

        /// <summary>
        ///     Asynchronously get an entity by its id.
        /// </summary>
        /// <param name="id">The id of the entity to get.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the entity found, or null.</returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        ///     Asynchronously add an entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the added entity.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        ///     Asynchronously update an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        ///     Asynchronously delete an entity by its id.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}
