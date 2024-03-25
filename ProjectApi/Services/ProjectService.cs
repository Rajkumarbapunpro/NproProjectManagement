using ProjectApi.Interfaces;
using ProjectApi.Model;
using ProjectApi.Repository.Interface;

namespace ProjectApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectDetail>> GetProjectsAsync()
        {
            var Projects = await _repository.GetProjectsAsync();
            return Projects;
        }

        public async Task<ProjectDetail> GetProjectByIdAsync(int projectId)
        {
            var project = await _repository.GetProjectByIdAsync(projectId);
            return project;
        }

        public async Task<ProjectDetail> PostProjectAsync(ProjectDetail model)
        {
            var project = await _repository.InsertProjectAsync(model);
            return project;
        }
        public async Task<ProjectDetail> PutProjectAsync(ProjectDetail model)
        {
            var project = await _repository.UpdateProjectAsync(model);
            return project;
        }
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            return await _repository.DeleteProjectAsync(projectId);
        }
    }
}