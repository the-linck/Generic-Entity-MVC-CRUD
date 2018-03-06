using System.ComponentModel.DataAnnotations;



namespace Generic_Entity_CRUD.Model
{
    /// <summary>
    /// Standart interface to represent a row in a table.
    /// </summary>
    public interface IRow<TKey>
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