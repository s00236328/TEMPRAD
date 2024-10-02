namespace week3radlab2
{
    public class Ads
    {
        public int AdId {  get; set; }
        public string Description { get; set; }
        public int SellerID { get; set; }
        public int CategoryId { get; set; }
        public  Categories? Categories { get; set; }
    }
    public class Categories
    {
        public int CategoriesId { get; set; }
        public string? Name {  get; set; }
        public List<Ads> Ads { get; set; } = new();
        
    }
    public class Seller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
    }
}
