using System.ComponentModel.DataAnnotations;



namespace Generic_Entity_CRUD.Model
{

    /// <summary>
    /// Empty standart interface to represent a row in a table.
    /// </summary>
    public interface IEntity {
    }

    /// <summary>
    /// Standart interface to represent a row in a table.
    /// </summary>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        [Key]
        TKey ID
        {
            get;
            set;
        }
    }
}