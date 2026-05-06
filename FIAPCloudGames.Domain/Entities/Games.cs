using FIAPCloudGames.Domain.Common;
using FIAPCloudGames.Domain.Events;
using FIAPCloudGames.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Entities
{
    public class Games : Entity
    {
        public Games(string gameName, string description, string genre, decimal price)
        {
            GameName = gameName;
            Description = description;
            Genre = genre;
            Price = price;

            AddDomainEvent(new GameRegisteredEvent(gameName, description, price));
        }
        public void UpdateData(string name, string description, string genre, decimal price)
        {
            GameName = name;
            Description = description;
            Genre = genre;
            Price = price;
        }

        private Games() { }

        public int Id { get; private set; }
        public string GameName { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public List<UserGames> UserGames { get; private set; } = new List<UserGames>();
    }
}
