using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Entities
{
    public class UserGames
    {
        public int UserId { get; private set; }
        public User User { get; private set; }

        public int GameId { get; private set; }
        public Games Game { get; private set; }

        private UserGames() { }
    }
}
