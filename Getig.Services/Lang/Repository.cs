using Microsoft.EntityFrameworkCore;

namespace Getig.Services.Language
{

    /// <inheritdoc />
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        ///     The database context.
        /// </summary>
        protected readonly DbContext _context;
        private DbSet<T> _entities;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        /// <param name="context">
        ///     The database context.
        /// </param>
        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T> GetByIdAsync(string id)
        {
            return await _entities.FindAsync(id);
        }

        /// <summary>
        ///     Asynchronously get an entity by its id where id is a Guid.
        /// </summary>
        /// <param name="id">The id of the entity to get.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the entity found, or null.</returns>
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T> AddAsync(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
