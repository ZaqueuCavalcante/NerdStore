namespace Web.Models;

public class ProductOut
{
    public Guid Id { get; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public bool IsActive { get; set; }

    public string Image { get; set; }

    public int QuantityInStock { get; set; }

    public DateTime RegisteredAt { get; set; }
}
