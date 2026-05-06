using FIAPCloudGames.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.ValueObjects
{
    public class Email
    {
        public string EmailAddress { get; set; }

        private Email() { }

        public Email(string address)
        {
            if (address.Length > 150)
                throw new DomainException("Email muito longo");

            if (!IsValid(address))
                throw new DomainException("Email inválido");

            EmailAddress = address;
        }

        private bool IsValid(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString() => EmailAddress;
    }
}
