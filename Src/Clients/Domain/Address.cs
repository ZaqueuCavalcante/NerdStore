namespace NerdStore.Clients.Domain
{
    public class Address
    {
        public int Id { get; set; }

        public Guid ClientId { get; set; }

        public string CEP { get; set; }

        public string Street { get; set; }
    }
}
