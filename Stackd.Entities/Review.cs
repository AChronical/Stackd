using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackd.Entities
{
    // A review is about EITHER a component (ComponentId) OR a project (ProjectName), never both.
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        // 0 to 10, one decimal place (e.g. 7.5). Displayed as a 10-star bar.
        [Range(0, 10)]
        public double Rating { get; set; }

        public DateTime Date { get; set; }

        // Set when the review is about a component.
        [ForeignKey("Component")]
        public int? ComponentId { get; set; }

        // Navigation property
        public virtual Component? Component { get; set; }

        // Set when the review is about a project instead of a component.
        public string? ProjectName { get; set; }
    }
}
