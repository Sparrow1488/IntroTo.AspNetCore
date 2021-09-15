using System;

namespace _10.ServicesLifetime.Services
{
    public class Watch : IWatch
    {
        public DateTime GetActualTime() => DateTime.Now;
    }
}
