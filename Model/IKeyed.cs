using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Generic_Entity_CRUD.Model
{
    /// <summary>
    /// A row that is identified by an string key
    /// </summary>
    public interface IKeyed : IEntity<string>
    {
        /// <summary>
        /// Textual primary key.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        new string ID
        {
            get;
            set;
        }
    }
}