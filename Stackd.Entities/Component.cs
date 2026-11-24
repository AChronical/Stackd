using System.ComponentModel.DataAnnotations;

namespace Stackd.Entities
{
    // One layer of a tech stack: a language, library, framework, API, IDE, engine, tool, etc.
    //
    // Every list that belongs to a component lives in its own table and points back here by ComponentId:
    //   ComponentProCon      - pros and cons
    //   ComponentLink        - documentation and popular project links
    //   ComponentTag         - which shared Tags this component has
    //   ComponentDependency  - which other components this one depends on
    //   Review               - reviews
    public class Component
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // e.g. "Language", "Library", "Framework", "IDE", "Game Engine", "Database", "Tool"
        public string Type { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // URL to the logo image.
        public string? LogoUrl { get; set; }
    }
}
