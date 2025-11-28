using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class ContentMember : TeamMember
{
    public ContentMember(string name, string path) 
        : base(name, Validate(path))
    {
    }

    private static readonly HashSet<string> AllowedPaths =
        new HashSet<string> { "CSharp", "JavaScript", "Python", "Java"};

    private static string Validate(string path)
    {
        if (!AllowedPaths.Contains(path))
        {
            throw new ArgumentException(ExceptionMessages.PathIncorrect, path);
        }
        
        return path;
        ;
    }

    public override string ToString()
    {
        return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
    }
}