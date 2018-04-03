using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming.Aric.Util
{
    class Randomizer
    {
        static Random RandomGen = new Random();

        public static void SetRandowSeed(int seed)
        {
            RandomGen = new Random(seed);
        }

        public static int GetInt(int min, int max)
        {
            return RandomGen.Next(min, max + 1);
        }
    }
}
