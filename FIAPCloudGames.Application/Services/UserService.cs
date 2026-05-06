using FIAPCloudGames.Application.Helpers;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Exceptions;
using FIAPCloudGames.Domain.Interfaces;
using FIAPCloudGames.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public void Register(string name, string email, string password, bool isAdmin)
        {
            if (_repo.EmailExists(email))
                throw new BusinessException("Já existe um usuário cadastrado com esse email", 400);

            PasswordValidator.Validate(password);

            var hashedPassword = PasswordHasher.Hash(password);

            var user = new User(
                name,
                new Email(email),
                hashedPassword,
                isAdmin
            );

            _repo.Add(user);
        }

        public void Update(int id, string name)
        {
            var user = _repo.GetById(id) ?? throw new BusinessException("Usuário não encontrado", 404);
            
            user.UpdateData(name);

            _repo.Update(user);
        }

        public void Delete(int id)
        {
            var user = _repo.GetById(id);

            if (user == null)
                throw new BusinessException("Usuário não encontrado", 404);

            _repo.Delete(user);
        }
    }
}
