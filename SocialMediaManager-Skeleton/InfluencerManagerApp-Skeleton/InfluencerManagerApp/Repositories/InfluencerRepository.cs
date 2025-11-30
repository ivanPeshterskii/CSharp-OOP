using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class InfluencerRepository : IRepository<IInfluencer>
{
    private readonly List<IInfluencer> models;

    public InfluencerRepository()
    {
        this.models = new List<IInfluencer>();
    }
    
    public IReadOnlyCollection<IInfluencer> Models => this.models;
    
    public void AddModel(IInfluencer model)
    {
        this.models.Add(model);
    }

    public bool RemoveModel(IInfluencer model)
    {
        return this.models.Remove(model);
    }

    public IInfluencer FindByName(string name)
    {
        return this.models.FirstOrDefault(m=> m.Username == name);
    }
}