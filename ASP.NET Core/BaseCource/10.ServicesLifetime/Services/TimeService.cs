using System;

namespace _10.ServicesLifetime.Services
{
    public class TimeService
    {
        private DateTime _actualTime = DateTime.Now;
        public DateTime GetActualTime()
        {
            return _actualTime;
        }
    }
}
