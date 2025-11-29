using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Campaign : ICampaign
{
    private string brand;
    private readonly List<string> contributors;

    public string Brand
    {
        get => this.brand;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(ExceptionMessages.BrandIsrequired);
            }
            this.brand = value;
        } 
    }
    
    public double Budget { get; private set; }
    
    public IReadOnlyCollection<string> Contributors 
        => this.contributors;

    public Campaign(string brand, double budget)
    {
        this.Brand = brand;
        this.Budget = budget;
        
        this.contributors = new List<string>();
    }

    public override string ToString()
    {
        return
            $"{this.GetType().Name} - Brand: {this.Brand}, Budget: {this.Budget}, Contributors: {this.contributors.Count}";
    }
    
    public void Gain(double amount)
    {
        this.Budget += amount;
    }

    public void Engage(IInfluencer influencer)
    {
        this.contributors.Add(influencer.Username);
        this.Budget -= influencer.CalculateCampaignPrice();
    }
}