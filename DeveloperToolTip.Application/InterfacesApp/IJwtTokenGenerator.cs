using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.InterfacesApp
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username, IEnumerable<Claim> claims);
    }
}
