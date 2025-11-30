using System.Collections.ObjectModel;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class ResourceRepository : IRepository<IResource>
{
    private readonly List<IResource> models;

    public ResourceRepository()
    {
        models = new List<IResource>();
    }
    
    public IReadOnlyCollection<IResource> Models 
        => new ReadOnlyCollection<IResource>(models);
    
    public void Add(IResource model)
    {
        this.models.Add(model);
    }

    public IResource TakeOne(string modelName)
    {
        return models.FirstOrDefault(m => m.Name == modelName);
    }
}