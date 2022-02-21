namespace NerdStore.Clients.Domain
{
    public class Client
    {
        public Guid Id { get; set; }

        public string Cpf { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsExcluded { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Client(
            Guid id,
            string cpf,
            string name,
            string email
        ) {
            Id = id;
            Cpf = cpf;
            Name = name;
            Email = email;
        }
    }
}
