using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCLoudGames.UnitTests.Fakes
{
    public class FakeUserRepository : IUserRepository
    {
        public List<User> Users = new();

        public void Add(User user)
        {
            Users.Add(user);
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public bool EmailExists(string email)
        {
            return Users.Any(u => u.Email.EmailAddress == email);
        }

        public User GetByEmail(string email)
        {
            return Users.FirstOrDefault(u => u.Email.EmailAddress == email);
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
