using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Events
{
    public class UserRegisteredEvent(string email)
    {
        public string Email { get; } = email;
    }
}
