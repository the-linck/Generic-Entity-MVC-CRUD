using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Generic_Entity_CRUD.Model
{
    /// <summary>
    /// A row that registers creation and update date.
    /// </summary>
    public interface IDated
    {
        /// <summary>
        /// Creation date/time.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        DateTime Created
        {
            get;
            set;
        }
        
        /// <summary>
        /// Updated date/time.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        DateTime Updated
        {
            get;
            set;
        }
    }
}