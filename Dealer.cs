using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenge
{
    static class Dealer
    {
        static readonly Random rnd = new Random();

        public static IList<T> Shuffle<T>(this IList<T> input)
        {
            for (var top = input.Count - 1; top > 1; --top)
            {
                var swap = rnd.Next(0, top);
                T tmp = input[top];
                input[top] = input[swap];
                input[swap] = tmp;
            }

            return input;
        }
               
    }
}