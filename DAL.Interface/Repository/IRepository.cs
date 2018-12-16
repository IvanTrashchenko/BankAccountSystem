using System;
using System.Collections.Generic;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Bank service repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    public interface IRepository<TEntity>
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
        /// <exception cref="ArgumentNullException">Thrown when <see cref="TEntity"/> value is null.</exception>
        void Create(TEntity entity);

        /// <summary>
        /// Operating for deleting entity from repository.
        /// </summary>
        /// <param name="entity">Specific entity.</param>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="TEntity"/> value is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="TEntity"/> is not found.</exception>
        void Delete(TEntity entity);

        /// <summary>
        /// Operation for updating entity.
        /// </summary>
        /// <param name="entity">Specific entity.</param>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="TEntity"/> value is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="TEntity"/> is not found.</exception>
        void Update(TEntity entity);

        /// <summary>
        /// Gets element with specific identification number.
        /// </summary>
        /// <param name="number">Identification number of element.</param>
        /// <returns><see cref="TEntity"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when number is null or empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when number is not found.</exception>
        TEntity GetByNumber(string number);
    }
}
