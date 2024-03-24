using ContributionsApi.BusinessService.Interface;
using ContributionsApi.Models;
using ContributionsApi.Repository.Interface;
using System.Reflection;

namespace ContributionsApi.BusinessService
{
    public class ContributionsService : IContributionsService
    {
        private readonly IContributionRepository _repository;
        public ContributionsService(IContributionRepository repository)
        {
            _repository = repository;
        }


        public async Task<Contributions> GetContributionByIdAsync(int contributionId) {
            var contribution = await _repository.GetContributionByIdAsync(contributionId);
            return contribution;
        }

        public async Task<List<Contributions>> GetContributionsAsync() {
            var contribution = await _repository.GetContributionsAsync();
            return contribution;
        }
        public async Task<Contributions> PostContributionAsync(Contributions model)
        {
            var contribution = await _repository.InsertContributionAsync(model);
            return contribution;
        }
        public async Task<Contributions> PutContributionAsync(Contributions model)
        {
            var contribution = await _repository.UpdateContributionAsync(model);
            return contribution;
        }

        public async Task<bool> DeleteContributionAsync(int contributionId)
        {
            return await _repository.DeleteContributionAsync(contributionId);
        }
    }
}
