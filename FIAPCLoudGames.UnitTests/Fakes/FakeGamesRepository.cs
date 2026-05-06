using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCLoudGames.UnitTests.Fakes
{
    public class FakeGameRepository : IGamesRepository
    {
        public List<Games> Games = new();

        public void Add(Games game)
        {
            Games.Add(game);
        }

        public void Update(Games game)
        {
        }

        public void Delete(Games game)
        {
            Games.Remove(game);
        }

        public Games GetById(int id)
        {
            return Games.FirstOrDefault(g => g.Id == id);
        }

        public Games GetByName(string name)
        {
            return Games.FirstOrDefault(g => g.GameName == name);
        }

        public List<Games> GetAll()
        {
            return Games;
        }

        public bool GameExists(string name)
        {
            return Games.Any(g => g.GameName == name);
        }
    }
}
