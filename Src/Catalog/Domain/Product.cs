namespace NerdStore.Catalog.Domain
{
    public class Product
    {
        public int Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public string Image { get; set; }

        public int QuantityInStock { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
