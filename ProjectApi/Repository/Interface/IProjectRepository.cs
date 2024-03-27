using ProjectApi.Model;

namespace ProjectApi.Repository.Interface
{
    public interface IProjectRepository
    {
        Task<List<ProjectDetail>> GetProjectsAsync();
        Task<ProjectDetail> GetProjectByIdAsync(int id);
        Task<ProjectDetail> InsertProjectAsync(ProjectDetail project);
        Task<ProjectDetail> UpdateProjectAsync(ProjectDetail project);
        Task<bool> DeleteProjectAsync(int projectId);
    }
}

