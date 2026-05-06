using FIAPCloudGames.Application.Services;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Exceptions;
using FIAPCLoudGames.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCLoudGames.UnitTests.Services
{
    public class GameServiceTests
    {
        private readonly FakeGameRepository _repo;
        private readonly GamesService _service;

        public GameServiceTests()
        {
            _repo = new FakeGameRepository();
            _service = new GamesService(_repo);
        }

        [Fact]
        public void NotCreateGameNameAlreadyExists()
        {
            _service.Create("Path Of Exile 2", "Grind", "MMO", 199);

            Assert.Throws<BusinessException>(() =>
                _service.Create("Path Of Exile 2", "Grind", "MMO", 100));
        }

        [Fact]
        public void UpdateGameWhenDataIsValid()
        {
            var game = new Games("GTA", "Pow Pow Pow", "Action", 100);
            _repo.Games.Add(game);

            _service.Update(game.Id, "GTA V", "Never End", "Action", 200);

            Assert.Equal("GTA V", game.GameName);
        }
    }
}
