namespace hometask_17.ViewModels
{
    public class CartItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public bool isDeleted { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
        public double Price { get; set; }
    }
}
