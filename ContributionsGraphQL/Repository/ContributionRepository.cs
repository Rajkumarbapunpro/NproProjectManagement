using ContributionsGraphQL.Dapper;
using ContributionsGraphQL.Models;
using ContributionsGraphQL.Repository.Interface;
using ContributionsGraphQL.Type;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ContributionsGraphQL.Repository
{
    public class ContributionRepository : IContributionRepository
    {
        private readonly DapperContext _context;

        public ContributionRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Contributions>> GetContributionsAsync()
        {
            var query = "SELECT * FROM Contributions";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var company = await connection.QueryAsync<Contributions>(query);

                    return company.ToList();
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return null;
        }
        public async Task<Models.Contributions> GetContributionByIdAsync(int contributionId)
        {
            var query = "SELECT * FROM Contributions WHERE ContributionId = @ContributionId";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var contribution = await connection.QuerySingleOrDefaultAsync<Contributions>(query, new { contributionId });

                    return contribution;
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return null;
        }

        public async Task<Contributions> InsertContributionAsync(Contributions contribution)
        {
            var query = "INSERT INTO dbo.Contributions (TaskID, UserID, TimeSpent, Description) VALUES (@taskid, @userid, @timespent, @description)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("taskid", contribution.TaskID, DbType.Int32);
            parameters.Add("userid", contribution.UserID, DbType.Int32);
            parameters.Add("timespent", contribution.TimeSpent, DbType.String);
            parameters.Add("description", contribution.Description, DbType.String);
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var contributionId = await connection.QuerySingleAsync<int>(query, parameters);
                    contribution.ContributionId = contributionId;
                    return contribution;
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return null;
        }
        public async Task<Contributions> UpdateContributionAsync(Contributions contribution)
        {
            var query = @"UPDATE dbo.Contributions
                SET TaskID = @taskid,
                UserID = @userid,
                TimeSpent = @timespent,
                Description = @description
                WHERE ContributionID = @contributionid";
            var parameters = new DynamicParameters();
            parameters.Add("contributionid", contribution.ContributionId, DbType.Int32);
            parameters.Add("taskid", contribution.TaskID, DbType.Int32);
            parameters.Add("userid", contribution.UserID, DbType.Int32);
            parameters.Add("timespent", contribution.TimeSpent, DbType.String);
            parameters.Add("description", contribution.Description, DbType.String);
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var noOfRowsAffected = await connection.ExecuteAsync(query, parameters);
                    return contribution;
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return null;
        }
        public async Task<bool> DeleteContributionAsync(int contributionId)
        {
            var query = "DELETE FROM Contributions WHERE ContributionId = @ContributionId";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var noOfRowsAffected = await connection.ExecuteAsync(query, new { contributionId });

                    return noOfRowsAffected == 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return false;
        }
    }
}
