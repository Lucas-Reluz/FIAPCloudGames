using FIAPCloudGames.Application.Helpers;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Exceptions;
using FIAPCloudGames.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _repo;
        private readonly string _key;

        public AuthService(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _key = config["Jwt:Key"];
        }

        public string Login(string email, string password)
        {

            var user = _repo.GetByEmail(email);

            if (user == null)
                throw new BusinessException("Usuário Não Localizado", 404) ;

            if (!PasswordHasher.Verify(password, user.Password))
                throw new BusinessException("Senha inválida", 400);

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Email.EmailAddress),
            new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
        };

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(2),
                issuer: "FIAPCloudGames",
                audience: "FIAPCloudGamesUsers",
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
