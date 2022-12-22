namespace hometask_17.Models
{
    public class WorkCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<WorkProductCategory>? WorkProductCategory { get; set; } 

    }
}
