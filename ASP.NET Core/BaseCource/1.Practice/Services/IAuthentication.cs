using Microsoft.AspNetCore.Http;

namespace _1.Practice.Services
{
    public interface IAuthentication
    {
        bool Authenticate(HttpContext context);
    }
}
