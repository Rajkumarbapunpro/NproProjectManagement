using GraphQL.Types;

namespace ContributionsGraphQL.Type
{
    public class ContributionsInputType : InputObjectGraphType
    {
        public ContributionsInputType()
        {
            Name = "AddContributions";
            Field<IntGraphType>("ContributionId");
            Field<IntGraphType>("TaskID");
            Field<IntGraphType>("UserID");
            Field<StringGraphType>("TimeSpent");
            Field<StringGraphType>("Description");
        }
    }
}
