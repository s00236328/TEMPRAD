using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace week3radlab2
{
    public class Ads
    {
        [Key]
        public int AdId {  get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(Seller))]
        public int SellerID { get; set; }
        public Seller Seller { get; set; } 

        [ForeignKey(nameof(Categories))]
        public int CategoryId { get; set; }
        public  Categories? Categories { get; set; }
    }
    public class Categories
    {
        [Key]
        public int CategoriesId { get; set; }
        public string? Name {  get; set; }
        //public List<Ads> Ads { get; set; } = new List<Ads>();
        
    }
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
    }
}
