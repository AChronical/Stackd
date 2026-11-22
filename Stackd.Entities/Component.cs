using System.ComponentModel.DataAnnotations;

namespace Stackd.Entities
{
    // One layer of a tech stack: a language, library, framework, API, IDE, engine, tool, etc.
    //
    // List-style fields are stored as ONE string with items separated by a line break ("\n").
    // Split them in code: value.Split('\n')
    public class Component
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // e.g. "Language", "Library", "Framework", "IDE", "Game Engine", "Database", "Tool"
        public string Type { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // Line-break separated list of pros.
        public string? Pros { get; set; }

        // Line-break separated list of cons.
        public string? Cons { get; set; }

        // Line-break separated feature tags used by Search (e.g. "Web\nBackend\nCross-platform").
        public string? Tags { get; set; }

        // Line-break separated list of other Component IDs this one depends on (e.g. "4" or "8\n10").
        public string? Dependencies { get; set; }

        // Line-break separated list of documentation URLs.
        public string? DocumentationLinks { get; set; }

        // Line-break separated list of popular project URLs that use this component.
        public string? PopularProjects { get; set; }

        // URL to the logo image.
        public string? LogoUrl { get; set; }
    }
}
