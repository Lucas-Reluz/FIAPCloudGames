using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Interfaces;
using FIAPCloudGames.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Infrastructure.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly AppDbContext _context;

        public GamesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Games game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public void Update(Games game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }

        public void Delete(Games game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public Games GetById(int id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }

        public Games GetByName(string name)
        {
            return _context.Games.FirstOrDefault(g => g.GameName == name);
        }

        public List<Games> GetAll()
        {
            return _context.Games.ToList();
        }

        public bool GameExists(string name)
        {
            return _context.Games.Any(g => g.GameName == name);
        }
    }
}
