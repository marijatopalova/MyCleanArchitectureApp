namespace MyCleanArchitectureApp.Application.Products.DTOs
{
    public class ProductDto(int id, string name, decimal price)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
    }
}
