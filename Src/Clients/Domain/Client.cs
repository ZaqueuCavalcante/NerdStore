namespace NerdStore.Clients.Domain
{
    public class Client
    {
        public int Id { get; set; }

        public string Cpf { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool Excluded { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
