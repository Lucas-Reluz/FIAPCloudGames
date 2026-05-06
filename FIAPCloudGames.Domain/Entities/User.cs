using FIAPCloudGames.Domain.Common;
using FIAPCloudGames.Domain.Events;
using FIAPCloudGames.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, Email email, string password, bool isAdmin)
        {
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;

            AddDomainEvent(new UserRegisteredEvent(email.EmailAddress));
        }

        public void UpdateData(string name)
        {
            Name = name;
        }

        private User() { }

        public int Id { get;  private set; }
        public string Name { get; set; }
        public Email Email { get; private set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserGames> PurchasedGames { get; private set; } = new List<UserGames>();
    }
}
