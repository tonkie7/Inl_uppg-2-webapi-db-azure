namespace WebApi.Models
{
    public class Products
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ArticleNumber { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }  
    }
}
