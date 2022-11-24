namespace DomainServices.Repositories
{
    /// <summary>
    /// Generic repository class for basic operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all of <typeparamref name="TEntity"/>
        /// </summary>
        /// <returns>An IEnumerable object of TEntity</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the first entity that matches the ID and returns it
        /// </summary>
        /// <param name="ID">ID of the object to find</param>
        /// <returns>The first entity found</returns>
        TEntity FindByID(int ID);

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Removes a entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        // <summery>
        // Updates TEntity
        // </summary>
        // <param name="entity"></param>
        void Update(int id, TEntity entity);
    }
}

