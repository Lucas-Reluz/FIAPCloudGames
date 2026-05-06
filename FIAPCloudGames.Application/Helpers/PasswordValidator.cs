using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using FIAPCloudGames.Domain.Exceptions;

namespace FIAPCloudGames.Application.Helpers
{

    public static class PasswordValidator
    {
        public static void Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new DomainException("Senha obrigatória");

            if (password.Length < 8)
                throw new DomainException("Senha deve ter no mínimo 8 caracteres");

            if (!Regex.IsMatch(password, @"[A-Za-z]"))
                throw new DomainException("Senha deve conter letras");

            if (!Regex.IsMatch(password, @"\d"))
                throw new DomainException("Senha deve conter números");

            if (!Regex.IsMatch(password, @"[\W_]"))
                throw new DomainException("Senha deve conter caractere especial");
        }
    }
}
