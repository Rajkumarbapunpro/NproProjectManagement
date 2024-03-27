using Dapper;
using ProjectApi.Dapper;
using ProjectApi.Model;
using ProjectApi.Repository.Interface;
using System.Data;

namespace ProjectApi.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DapperContext _context;
        public ProjectRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<ProjectDetail>> GetProjectsAsync()
        {
            var query = "SELECT * FROM Project";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var Project = await connection.QueryAsync<ProjectDetail>(query);

                    return Project.ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProjectDetail> GetProjectByIdAsync(int projectId)
        {
            var query = "SELECT * FROM Project WHERE ProjectID = @projectId";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var project = await connection.QuerySingleOrDefaultAsync<ProjectDetail>(query, new { projectId });

                    return project;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProjectDetail> InsertProjectAsync(ProjectDetail project)
        {
            var query = "INSERT INTO dbo.Project (Title,Description, Deadline, Status,CreatorID) VALUES (@title, @description, @deadline, @status, @creatorid)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("title", project.Title, DbType.String);
            parameters.Add("description", project.Description, DbType.String);
            parameters.Add("deadline", project.Deadline, DbType.DateTime);
            parameters.Add("status", project.Status, DbType.String);
            parameters.Add("creatorid", project.CreatorID, DbType.Int32);
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var ProjectId = await connection.QuerySingleAsync<int>(query, parameters);
                    project.ProjectID = ProjectId;
                    return project;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<ProjectDetail> UpdateProjectAsync(ProjectDetail project)
        {
            var query = @"UPDATE Project
                SET Title = @title,
                Description = @description,
                Deadline = @deadline,
                Status = @status,
                CreatorID = @creatorid
                WHERE projectID = @projectid";
            var parameters = new DynamicParameters();
            parameters.Add("projectid", project.ProjectID, DbType.Int32);
            parameters.Add("title", project.Title, DbType.String);
            parameters.Add("description", project.Description, DbType.String);
            parameters.Add("deadline", project.Deadline, DbType.DateTime);
            parameters.Add("status", project.Status, DbType.String);
            parameters.Add("creatorid", project.CreatorID, DbType.Int32);

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var noOfRowsAffected = await connection.ExecuteAsync(query, parameters);
                    return project;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var query = "DELETE FROM Project WHERE ProjectID = @projectId";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var noOfRowsAffected = await connection.ExecuteAsync(query, new { projectId });

                    return noOfRowsAffected == 0 ? false : true;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
