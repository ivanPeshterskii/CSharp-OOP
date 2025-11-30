using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Influencer : IInfluencer
{
    private string name;
    private int followers;
    private readonly List<string> participants;

    public string Username
    {
        get => name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            }
            this.name = value;
        }
    }

    public int Followers
    {
        get => followers;
        
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            }
            this.followers = value;
        }
    }
    
    public double EngagementRate { get; private set; }
    
    public double Income { get; private set; }

    public IReadOnlyCollection<string> Participations => participants;

    public Influencer(string username, int followers, double engagementRate)
    {
        this.Username = username;
        this.Followers = followers;
        this.EngagementRate = engagementRate;
        
        this.participants = new List<string>();
        this.Income = 0;
    }

    public override string ToString()
    {
        return $"{this.Username} - Followers: {this.Followers}, Total Income: {this.Income}";
    }
    
    public void EarnFee(double amount)
    {
        this.Income += amount;
    }

    public void EnrollCampaign(string brand)
    {
        this.participants.Add(brand);
    }

    public void EndParticipation(string brand)
    {
        this.participants.Remove(brand);
    }

    public abstract int CalculateCampaignPrice();
}