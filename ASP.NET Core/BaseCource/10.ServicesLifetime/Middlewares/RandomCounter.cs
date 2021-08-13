using System;

namespace _10.ServicesLifetime.Middlewares
{
    public class RandomCounter : ICounter
    {
        private int _num = 0;

        public RandomCounter()
        {
            _num = new Random().Next(-100, 10000);
        }

        public int Value()
        {
            return _num;
        }
    }
}
