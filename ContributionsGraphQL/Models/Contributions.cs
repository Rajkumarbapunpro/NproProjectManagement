using System;

namespace ContributionsGraphQL.Models
{
    public class Contributions
    {
        public int ContributionId { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public string TimeSpent { get; set; }
        public string Description { get; set; }
    }
}
