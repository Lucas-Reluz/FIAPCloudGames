using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Application.DTOs
{
    public record CreateGameRequest(string Name, string Description, string Genre, decimal Price);
}
