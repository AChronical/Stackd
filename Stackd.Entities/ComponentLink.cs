using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackd.Entities
{
    // One hyperlink of a component. Documentation links and popular project links share this table;
    // LinkType says which.
    public class ComponentLink
    {
        public const string Documentation = "Documentation";
        public const string PopularProject = "PopularProject";

        [Key]
        public int Id { get; set; }

        // Text shown for the link, e.g. "Django"
        public string DisplayName { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        // ComponentLink.Documentation or ComponentLink.PopularProject
        public string LinkType { get; set; } = string.Empty;

        [ForeignKey("Component")]
        public int ComponentId { get; set; }

        // Navigation property
        public virtual Component? Component { get; set; }
    }
}
