namespace InfluencerManagerApp.Models;

public class BusinessInfluencer : Influencer
{
    private const double engagemontRate = 3.0;
    private const double factor = 0.15;
    
    
    public BusinessInfluencer(string username, int followers) 
        : base(username, followers, engagemontRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)Math.Floor(Followers * EngagementRate * factor);
    }
}