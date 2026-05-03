using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.ValueObjects
{
    public class Email
    {
        public string EmailAddress { get; set; }
        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
