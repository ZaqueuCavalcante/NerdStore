namespace NerdStore.Cart.Domain
{
    public class CartItem
    {
        public Guid Id { get; }

        public Guid CartId { get; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public CartItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
