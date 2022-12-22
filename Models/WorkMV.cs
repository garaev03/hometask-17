namespace hometask_17.Models
{
    public class WorkMV
    {
        public List<WorkCategory>? categories { get; set; }
        public List<WorkProduct>? products { get; set; }
        public List<WorkProductCategory>?    productCategories { get; set; }
    }
}
