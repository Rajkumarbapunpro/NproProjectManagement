using ContributionsGraphQL.Models;
using ContributionsGraphQL.Type;

namespace ContributionsGraphQL.Repository.Interface
{
    public interface IContributionRepository
    {
        Task<List<Contributions>> GetContributionsAsync();
        Task<Contributions> GetContributionByIdAsync(int id);
        Task<Contributions> InsertContributionAsync(Contributions contributions);
        Task<Contributions> UpdateContributionAsync(Contributions contributions);
        Task<bool> DeleteContributionAsync(int contributionId);
    }
}
