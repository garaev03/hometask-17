namespace hometask_17.Models
{
    public class WorkProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public WorkProduct? product { get; set; }
        public int CategoryId { get; set; }
        public WorkCategory? category { get; set; }
    }
}
