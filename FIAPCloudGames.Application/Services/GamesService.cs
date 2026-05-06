using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Exceptions;
using FIAPCloudGames.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Application.Services
{
    public class GamesService
    {
        private readonly IGamesRepository _repo;

        public GamesService(IGamesRepository repo)
        {
            _repo = repo;
        }

        public void Create(string name, string description, string genre, decimal price)
        {
            if (_repo.GameExists(name))
                throw new BusinessException("Já existe um jogo com esse nome", 400);

            var game = new Games(name, description, genre, price);

            _repo.Add(game);
        }

        public void Update(int id, string name, string description, string genre, decimal price)
        {
            var game = _repo.GetById(id) ?? throw new BusinessException("Jogo não encontrado", 404);
            
            if (_repo.GameExists(name) && game.GameName != name)
                throw new BusinessException("Já existe um jogo com esse nome", 400);

            game.UpdateData(name, description, genre, price);

            _repo.Update(game);
        }

        public void Delete(int id)
        {
            var game = _repo.GetById(id);

            if (game == null)
                throw new BusinessException("Jogo não encontrado", 404);

            _repo.Delete(game);
        }

        public Games GetByName(string name)
        {
            var game = _repo.GetByName(name);

            if (game == null)
                throw new BusinessException("Jogo não encontrado", 404);

            return game;
        }

        public List<Games> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
