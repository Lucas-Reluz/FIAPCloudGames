using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Application.DTOs
{
    public record RegisterRequest(string Name, string Email, string Password, bool IsAdmin);
}
