using FIAPCloudGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Interfaces
{
    public interface IGamesRepository
    {
        void Add(Games game);
        void Update(Games game);
        void Delete(Games game);

        Games GetById(int id);
        Games GetByName(string name);
        List<Games> GetAll();

        bool GameExists(string name);
    }
}
