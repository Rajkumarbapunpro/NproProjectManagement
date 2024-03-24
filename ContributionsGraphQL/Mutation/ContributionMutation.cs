using ContributionsGraphQL.Models;
using ContributionsGraphQL.Repository.Interface;
using ContributionsGraphQL.Type;
using GraphQL;
using GraphQL.Types;

namespace ContributionsGraphQL.Mutation
{
    public class ContributionMutation : ObjectGraphType<object>
    {
        public ContributionMutation(IContributionRepository repository)
        {
            Name = "ContributionMutation";

            FieldAsync<ContributionsInfoType>(
                "createContribution",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ContributionsInputType>> { Name = "createContributionInput" }
                ),
                resolve: async context =>
                {
                    var ContributionInput = context.GetArgument<Contributions>("createContributionInput");
                    return await repository.InsertContributionAsync(ContributionInput);
                });

            FieldAsync<ContributionsInfoType>(
                "updateContribution",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ContributionsInputType>> { Name = "updateContributionInput" }
                    ),
                resolve: async context =>
                {
                    var contribution = context.GetArgument<Contributions>("updateContributionInput");
                    return await repository.UpdateContributionAsync(contribution);
                }
            );

            FieldAsync<StringGraphType>(
              "deleteContribution",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ContributionId" }),
              resolve: async context =>
              {
                  var ContributionId = context.GetArgument<int>("contributionId");

                  var contribution = await repository.GetContributionByIdAsync(ContributionId);
                  if (contribution == null)
                  {
                      context.Errors.Add(new ExecutionError("Couldn't find Contribution info."));
                      return null;
                  }

                  await repository.DeleteContributionAsync(ContributionId);
                  return $"Contribution ID {ContributionId} with Description {contribution.Description} has been deleted succesfully.";
              }
             );
        }
    }
}
