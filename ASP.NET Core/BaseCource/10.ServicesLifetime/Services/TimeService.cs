using System;

namespace _10.ServicesLifetime.Services
{
    public class TimeService
    {
        private readonly IWatch _watch;
        public TimeService(IWatch watch)
        {
            _watch = watch;
        }
        public DateTime GetActualTime() => _watch.GetActualTime();
    }
}
