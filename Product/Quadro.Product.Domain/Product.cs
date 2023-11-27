namespace Quadro.Product.Domain;

public class Product : Entity<Guid>
{
    public required string Name { get; set; }
    public required string Category { get; set; }
    public string? Description { get; set; }
    public required Money? UnitPrice { get; set; }
}
