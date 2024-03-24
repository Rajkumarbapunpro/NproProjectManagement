using ContributionsGraphQL.Models;
using GraphQL.Types;
namespace ContributionsGraphQL.Type
{
    public class ContributionsInfoType : ObjectGraphType<Contributions>
    {
        public ContributionsInfoType()
        {
            Field(x => x.ContributionId).Description("Contribution id.");
            Field(x => x.UserID).Description("User ID.");
            Field(x => x.TaskID).Description("Task ID.");
            Field(x => x.Description).Description("Description.");
            Field(x => x.TimeSpent).Description("TimeSpent.");
        }
    }
}
