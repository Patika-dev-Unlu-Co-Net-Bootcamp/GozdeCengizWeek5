using BlogProject.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Interfaces.Jwt
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(LoginUserViewModel userViewModel);
    }
}
