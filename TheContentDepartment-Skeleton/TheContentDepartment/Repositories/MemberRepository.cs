using System.Collections.ObjectModel;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class MemberRepository : IRepository<ITeamMember>
{
    private readonly List<ITeamMember> models;
    
    public IReadOnlyCollection<ITeamMember> Models
            => new ReadOnlyCollection<ITeamMember>(models);


    public MemberRepository()
    {
        models = new List<ITeamMember>();
    }
    
    public void Add(ITeamMember model)
    {
        this.models.Add(model);
    }

    public ITeamMember TakeOne(string modelName)
    {
        return models.FirstOrDefault(m => m.Name == modelName);
    }
}