using Core.DomainObjects;

namespace Domain.Entitties
{
    public class Client : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }

        public Client()
        {
        }

        public Client(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
