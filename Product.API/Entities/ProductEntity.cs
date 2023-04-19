namespace Product.API.Entities;

internal class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Available { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
}