using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Generic_Entity_CRUD.Model;

namespace Generic_Entity_CRUD
{
    /// <summary>
    /// Specifies the CRUD operation methods, with their variations.
    /// <param name="TEntity">Database entity in wich this controller will act</param>
    /// </summary>
    public interface ICrudController<TEntity>
    where TEntity : class, IEntity
    {
        #region Create
            /// <summary>
            /// Saves new registers to the database.
            /// </summary>
            /// <param name="Rows">Rows registers to save</param>
            void Create(params TEntity[] Rows);

            /// <summary>
            /// Saves new registers to the database.
            /// </summary>
            /// <param name="Rows">Rows registers to save</param>
            void Create(IEnumerable<TEntity> Rows);

            /// <summary>
            /// Asynchronously saves new registers to the database.
            /// </summary>
            /// <param name="Rows">Rows registers to save</param>
            void CreateAsync(params TEntity[] Rows);

            /// <summary>
            /// Asynchronously saves new registers to the database.
            /// </summary>
            /// <param name="Rows">Rows registers to save</param>
            void CreateAsync(IEnumerable<TEntity> Rows, CancellationToken CancellationToken = default(CancellationToken));
        #endregion

        #region Read
            /// <summary>
            /// Exposes an IQueryable object to seach registers.
            /// </summary>
            IQueryable<TEntity> Read(bool Tracking = false);

            /// <summary>
            /// Searches for registers on the database with given keys.
            /// </summary>
            /// <param name="Keys">Keys to find registers</param>
            TEntity Read(params object[] Keys);

            /// <summary>
            /// Asynchronously searches for registers on the database with given keys.
            /// </summary>
            /// <param name="Keys">Keys to find registers</param>
            Task<TEntity> ReadAsync(params object[] Keys);

            /// <summary>
            /// Asynchronously searches for registers on the database with given keys.
            /// </summary>
            /// <param name="Keys">Keys to find registers</param>
            /// <param name="CancellationToken">CancellationToken to observe while task is not complete</param>
            Task<TEntity> ReadAsync(object[] Keys, CancellationToken CancellationToken);
        #endregion

        #region Update
            /// <summary>
            /// Saves existing registers in the database.
            /// </summary>
            /// <param name="Row">Existing registers to save</param>
            void Update(TEntity[] Rows);

            /// <summary>
            /// Saves existing registers in the database.
            /// </summary>
            /// <param name="Row">Existing registers to save</param>
            void Update(IEnumerable<TEntity> Rows);
        #endregion

        #region Delete
            /// <summary>
            /// Deletes registers from database.
            /// </summary>
            /// <param name="Row">Registers to delete</param>
            void Delete(TEntity[] Rows);
            /// <summary>
            /// Deletes registers from database.
            /// </summary>
            /// <param name="Row">Registers to delete</param>
            void Delete(IEnumerable<TEntity> Rows);
        #endregion
    }
}
