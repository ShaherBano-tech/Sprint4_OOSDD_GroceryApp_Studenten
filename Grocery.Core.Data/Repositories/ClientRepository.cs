
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> clientList;

        public ClientRepository()
        {
            clientList = new List<Client>
            {
                new Client { Id = 1, Name = "M.J. Curie", Email = "user1@mail.com", Password = "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=", Role = Role.None },
                new Client { Id = 2, Name = "H.H. Hermans", Email = "user2@mail.com", Password = "dOk+X+wt+MA9uIniRGKDFg==.QLvy72hdG8nWj1FyL75KoKeu4DUgu5B/HAHqTD2UFLU=", Role = Role.None },
                new Client { Id = 3, Name = "A.J. Kwak", Email = "user3@mail.com", Password = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=", Role = Role.Admin }
            };
        }

        public Client? Get(string email)
        {
            Client? client = clientList.FirstOrDefault(c => c.Email.Equals(email));
            return client;
        }

        public Client? Get(int id)
        {
            Client? client = clientList.FirstOrDefault(c => c.Id == id);
            return client;
        }

        public List<Client> GetAll()
        {
            return clientList;
        }
    }
}
