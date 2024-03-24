using ContributionsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContributionsApi.BusinessService.Interface
{
    public interface IContributionsService
    {
        Task<Contributions> GetContributionByIdAsync(int contributionId);

        Task<List<Contributions>> GetContributionsAsync();
        Task<Contributions> PostContributionAsync(Contributions model);
        Task<Contributions> PutContributionAsync(Contributions model);
        Task<bool> DeleteContributionAsync(int contributionId);
    }
}
