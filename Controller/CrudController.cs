using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Generic_Entity_CRUD.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;



namespace Generic_Entity_CRUD
{
    /// <summary>
    /// Base class for using generic CRUD in MVC patter, encapsulatting database logic in fast operations.
    /// <param name="TEntity">Database entity in wich this controller will act</param>
    /// </summary>
    public abstract class CrudController<TEntity, TKey>
    where TEntity : class, IRow<TKey>
    {
        /// <summary>
        /// If changes on the database will be saved automatically.
        /// </summary>
        protected bool AutoSave
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Database context reference to perform operations.
        /// Must be implemented by children classes.
        /// </summary>
        protected abstract DbContext Context
        {
            get;
            set;
        }

        /// <summary>
        /// Database Set (table) in wich perform operations.
        /// If not implemented by child class, will be automatically get from the current DBContext at initialization.
        /// </summary>
        protected DbSet<TEntity> Set
        {
            get;
            set;
        }

        #region Init
            /// <summary>
            /// Parameterless constructor to allow use of initializers.
            /// </summary>
            public CrudController()
            {
                GetDbSet();
            }

            /// <summary>
            /// Tries to automatically get the right DBSet com current DBContext.
            /// </summary>
            protected void GetDbSet()
            {
                if (Context != null && Set == null)
                {
                    Set = Context.Set<TEntity>();
                }
            }
        #endregion

        #region Create
            /// <summary>
            /// Saves new registers to the database.
            /// </summary>
            /// <param name="Rows">Rows registers to save</param>
            public void Create(params TEntity[] Rows)
            {
                Set.AddRange(Rows);

                // Autosave freature
                if (AutoSave)
                {
                    Context.SaveChanges();
                }
            }
            
            /// <summary>
            /// Saves new registers to the database.
            /// </summary>
            /// <param name="Row">Rows registers to save</param>
            public void Create(IEnumerable<TEntity> Rows)
            {
                Set.AddRange(Rows);

                // Autosave freature
                if (AutoSave)
                {
                    Context.SaveChanges();
                }
            }

            /// <summary>
            /// Asynchronously saves a new register to the database.
            /// </summary>
            /// <param name="Row">New register to save</param>
            public async void CreateAsync(params TEntity[] Rows)
            {
                await Set.AddRangeAsync(Rows);

                // Autosave freature
                if (AutoSave)
                {
                    await Context.SaveChangesAsync();
                }
            }

            /// <summary>
            /// Asynchronously saves new registers to the database.
            /// </summary>
            /// <param name="Row">Rows registers to save</param>
            /// <param name="CancellationToken">CancellationToken to observe while task is not complete</param>
            public async void CreateAsync(IEnumerable<TEntity> Rows, CancellationToken CancellationToken = default(CancellationToken))
            {
                await Set.AddRangeAsync(Rows, CancellationToken);

                // Autosave freature
                if (AutoSave)
                {
                    await Context.SaveChangesAsync();
                }
            }
        #endregion

        #region Read
            /// <summary>
            /// Exposes an IQueryable for custom searches in database.
            /// </summary>
            /// <param name="Tracking">If the results sould use Entity tracking</param>
            public IQueryable<TEntity> Read(bool Tracking = false)
            {
                IQueryable<TEntity> Result;

                if (Tracking)
                {
                    Result = Set.AsTracking();
                }
                else
                {
                    Result = Set.AsNoTracking();
                }
                
                return Result;
            }

            /// <summary>
            /// Searches for registers on the database with given keys.
            /// </summary>
            /// <param name="Keys">Keys to find registers</param>
            public TEntity Read(params object[] Keys)
            {
                return Set.Find(Keys);
            }

            /// <summary>
            /// Asynchronously searches for registers on the database with given keys.
            /// </summary>
            /// <param name="Keys">Keys to find registers</param>
            public async Task<TEntity> ReadAsync(params object[] Keys)
            {
                return await ReadAsync(Keys, default(CancellationToken));
            }

            /// <summary>
            /// Asynchronously searches for registers on the database with given keys.
            /// </summary>
            /// <param name="Keys">Keys to find registers</param>
            /// <param name="CancellationToken">CancellationToken to observe while task is not complete</param>
            public async Task<TEntity> ReadAsync(object[] Keys, CancellationToken CancellationToken)
            {
                return await Set.FindAsync(Keys, CancellationToken);
            }
        #endregion

        #region Update
            /// <summary>
            /// Saves existing registers in the database.
            /// </summary>
            /// <param name="Row">Existing registers to save</param>
            public void Update(params TEntity[] Rows)
            {
                Set.UpdateRange(Rows);

                // Autosave freature
                if (AutoSave)
                {
                    Context.SaveChanges();
                }
            }

            /// <summary>
            /// Saves existing registers in the database.
            /// </summary>
            /// <param name="Row">Existing registers to save</param>
            public void Update(IEnumerable<TEntity> Rows)
            {
                Set.UpdateRange(Rows);

                // Autosave freature
                if (AutoSave)
                {
                    Context.SaveChanges();
                }
            }
        #endregion

        #region Delete
            /// <summary>
            /// Deletes registers from database.
            /// </summary>
            /// <param name="Row">Registers to delete</param>
            public void Delete(TEntity[] Rows)
            {
                Set.RemoveRange(Rows);

                // Autosave freature
                if (AutoSave)
                {
                    Context.SaveChanges();
                }
            }

            /// <summary>
            /// Deletes registers from database.
            /// </summary>
            /// <param name="Row">Registers to delete</param>
            public void Delete(IEnumerable<TEntity> Rows)
            {
                Set.RemoveRange(Rows);

                // Autosave freature
                if (AutoSave)
                {
                    Context.SaveChanges();
                }
            }
        #endregion
    }
}