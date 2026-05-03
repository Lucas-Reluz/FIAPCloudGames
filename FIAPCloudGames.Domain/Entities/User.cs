using FIAPCloudGames.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Entities
{
    public class User
    {
        public User(string name, Email email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
