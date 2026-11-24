using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackd.Entities
{
    // One pro or one con of a component. Pros and cons share this table; IsPro says which.
    public class ComponentProCon
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        // true = pro, false = con
        public bool IsPro { get; set; }

        [ForeignKey("Component")]
        public int ComponentId { get; set; }

        // Navigation property
        public virtual Component? Component { get; set; }
    }
}
