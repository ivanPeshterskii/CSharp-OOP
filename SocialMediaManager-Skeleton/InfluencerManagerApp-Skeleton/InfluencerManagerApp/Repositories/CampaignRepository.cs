using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class CampaignRepository : IRepository<ICampaign>
{
    private readonly List<ICampaign> models;
    
    public IReadOnlyCollection<ICampaign> Models => this.models;

    public CampaignRepository()
    {
        this.models = new List<ICampaign>();
    }
    
    public void AddModel(ICampaign model)
    {
        this.models.Add(model);
    }

    public bool RemoveModel(ICampaign model)
    {
        return this.models.Remove(model);
    }

    public ICampaign FindByName(string name)
    {
        return this.models.FirstOrDefault(m => m.Brand == name);
    }
}