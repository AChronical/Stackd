using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackd.Entities
{
    // One row = "Component depends on DependsOnComponent" (e.g. Unity depends on C#).
    // Both columns point at the Components table.
    public class ComponentDependency
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Component")]
        public int ComponentId { get; set; }

        // Navigation property: the component that has the dependency
        public virtual Component? Component { get; set; }

        [ForeignKey("DependsOnComponent")]
        public int DependsOnComponentId { get; set; }

        // Navigation property: the component it depends on
        public virtual Component? DependsOnComponent { get; set; }
    }
}
