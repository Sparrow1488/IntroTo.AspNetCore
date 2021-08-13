using System.Collections.Generic;

namespace _1.Practice.Services
{
    public class AuthenticationService
    {
        private IAuthentication _authService;

        public AuthenticationService(IAuthentication authService)
        {
            _authService = authService;
        }
    }
}
