using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Events
{
    public class GameRegisteredEvent
    {
        public string GameName { get; }
        public string Description { get; }
        public decimal Price { get; }

        public GameRegisteredEvent(string gameName, string description, decimal price)
        {
            GameName = gameName;
            Description = description;
            Price = price;
        }
    }
}
