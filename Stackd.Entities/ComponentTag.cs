using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackd.Entities
{
    // Link table: one row = "this component has this tag".
    public class ComponentTag
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Component")]
        public int ComponentId { get; set; }

        // Navigation property
        public virtual Component? Component { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }

        // Navigation property
        public virtual Tag? Tag { get; set; }
    }
}
