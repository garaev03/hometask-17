namespace hometask_17.Models
{
    public class WorkProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<WorkProductCategory>? WorkProductCategory { get; set; }

    }
}
