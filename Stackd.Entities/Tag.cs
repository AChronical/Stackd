using System.ComponentModel.DataAnnotations;

namespace Stackd.Entities
{
    // A shared feature tag (e.g. "Web", "Game Dev"). Each tag exists once;
    // components are connected to it through ComponentTag.
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
