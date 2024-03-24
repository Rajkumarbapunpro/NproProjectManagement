using ContributionsGraphQL.Repository.Interface;
using ContributionsGraphQL.Type;
using GraphQL.Types;

namespace ContributionsGraphQL.Query
{
    public class ContributionQuery : ObjectGraphType<object>
    {
        public ContributionQuery(IContributionRepository repository)
        {
            Name = "ContributionQuery";

            Field<ContributionType>(
               "contribution",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "contributionId" }),
               resolve: context => repository.GetContributionByIdAsync(context.GetArgument<int>("contributionId"))
            );

            Field<ListGraphType<ContributionType>>(
             "contributions",
             resolve: context => repository.GetContributionsAsync()
          );
        }
    }
}