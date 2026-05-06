using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Application.DTOs
{
    public record LoginAuthRequest(string Email, string Password);
}
