using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Generic_Entity_CRUD.Model
{
    /// <summary>
    /// A row that is identified by an int key
    /// </summary>
    public interface IIdentified : IEntity<int>
    {
        /// <summary>
        /// Integer primary key.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        new int ID
        {
            get;
            set;
        }
    }

}