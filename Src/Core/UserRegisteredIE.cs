namespace NerdStore.Core;

public class UserRegisteredIE : IntegrationEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }

    public UserRegisteredIE(
        Guid id,
        string name,
        string email,
        string cpf
    ) {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
    }
}
