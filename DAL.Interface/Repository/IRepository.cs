using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Bank service repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Entity with ID property.</typeparam>
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Gets all elements of repository.
        /// </summary>
        /// <returns><see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Operating for adding new entity in repository.
        /// </summary>
        /// <param name="entity">Specific entity.</param>
        void Create(TEntity entity);

        /// <summary>
        /// Operating for deleting entity from repository.
        /// </summary>
        /// <param name="entity">Specific entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Operation for updating entity with specific identification number.
        /// </summary>
        /// <param name="entity">Specific entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Gets element with specific ID.
        /// </summary>
        /// <param name="id">ID of element.</param>
        /// <returns><see cref="TEntity"/>.</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Gets element with specific identification number.
        /// </summary>
        /// <param name="number">Identification number of element.</param>
        /// <returns><see cref="TEntity"/>.</returns>
        TEntity GetByNumber(string number);
    }
}
