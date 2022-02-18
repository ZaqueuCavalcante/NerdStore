namespace NerdStore.Cart.Domain
{
    public class ClientCart
    {
        public Guid Id { get; }

        public Guid ClientId { get; }

        public decimal TotalAmount { get; set; }

        public List<CartItem> Items { get; set; }

        public ClientCart(Guid clientId)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
        }
    }
}
