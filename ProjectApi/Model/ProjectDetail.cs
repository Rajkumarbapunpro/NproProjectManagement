namespace ProjectApi.Model
{
    public class ProjectDetail
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public int CreatorID { get; set; }
    }
}
