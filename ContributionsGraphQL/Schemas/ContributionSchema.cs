using ContributionsGraphQL.Mutation;
using ContributionsGraphQL.Query;
using GraphQL;
using GraphQL.Types;

namespace ContributionsGraphQL.Schemas
{
    public class ContributionSchema : Schema
    {
        public ContributionSchema(IDependencyResolver resolver)
        {
            Query = resolver.Resolve<ContributionQuery>();
            Mutation = resolver.Resolve<ContributionMutation>();
            DependencyResolver = resolver;
        }
    }
}
