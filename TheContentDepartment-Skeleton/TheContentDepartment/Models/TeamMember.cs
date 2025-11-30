using System.Collections.ObjectModel;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class TeamMember : ITeamMember
{
    private string name;
    private readonly List<string> task;

    protected TeamMember(string name, string path)
    {
        this.Name = name;
        this.Path = path;
        this.task = new List<string>();
    }
    
    public string Name
    {
        get => this.name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(ExceptionMessages.NameNullOrWhiteSpace);
            }
            this.name = value;
        }
    }
    
    public string Path { get; protected set; }

    public IReadOnlyCollection<string> InProgress
    {
        get => new ReadOnlyCollection<string>(this.task);
    }
    
    public void WorkOnTask(string resourceName)
    {
        this.task.Add(resourceName);
    }

    public void FinishTask(string resourceName)
    {
        this.task.Remove(resourceName);
    }
}