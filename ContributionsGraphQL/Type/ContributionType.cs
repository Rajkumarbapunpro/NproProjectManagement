using ContributionsGraphQL.Models;
using GraphQL.Types;

namespace ContributionsGraphQL.Type
{
    public class ContributionType : ObjectGraphType<Contributions>
    {
        public ContributionType()
        {
            Field(x => x.ContributionId).Description("Contribution ID.");
            Field(x => x.Description).Description("Description.");
            Field(x => x.TimeSpent).Description("Time Spent.");
            Field(x => x.TaskID).Description("Task ID.");
            Field(x => x.UserID).Description("User ID.");
        }
    }
}
