using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.RandomGeneration
{
    public class RandomGenerator
    {
        private static Random _random = new Random();

        public static int GetRandom(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
