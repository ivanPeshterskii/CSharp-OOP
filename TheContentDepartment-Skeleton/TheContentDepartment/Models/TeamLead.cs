using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class TeamLead : TeamMember
{
    public TeamLead(string name, string path) 
        : base(name, Validate(path))
    {
    }

    private static string Validate(string path)
    {
        if (path != "Master")
        {
            throw new ArgumentException(ExceptionMessages.PathIncorrect, path);
        }
        return path;
    }

    public override string ToString()
    {
        return $"{Name} ({GetType().Name}) – Currently working on {InProgress.Count} tasks.";
    }
}