using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class Resource : IResource
{
    private string name;

    public Resource(string name, string creator, int priority)
    {
        this.Name = name;
        this.Creator = creator;
        this.Priority = priority;
    }

    public string Name
    {
        get => name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(ExceptionMessages.NameNullOrWhiteSpace);
            }
            this.name = value;
        }
    }

    public string Creator { get; private set; }
    
    public int Priority { get; private set; }
    
    public bool IsTested { get; private set; }
    
    public bool IsApproved { get;private set; }
    
    public void Test()
    {
        IsTested = !IsTested;
    }

    public void Approve()
    {
        IsApproved = true;
    }

    public override string ToString()
    {
        return $"{this.Name} ({this.GetType().Name}), Created By: {this.Creator}";
    }
}