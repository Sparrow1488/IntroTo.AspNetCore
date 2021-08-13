using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace _1.Practice.Services
{
    public class NameAuthentication : IAuthentication
    {
        private List<string> _namesStorage = new List<string>();
        public bool Authenticate(HttpContext input)
        {
            string inputName = input.Request.Query["name"];
            bool authResult = false;
            if(_namesStorage.Contains(inputName))
                authResult = true;
            else if(inputName != null)
                _namesStorage.Add(inputName);
            return authResult;
        }
    }
}
