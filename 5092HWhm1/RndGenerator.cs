using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{

    public class RndGenerator  //Generate a normal distribution random number
    {
        private Random rnd = new Random();
        long _N;

        public RndGenerator(long N)
        {
            _N = N;
        }

        public double[] Normal()
        {
            int i;
            double r1, r2, w;
            double[] rnds = new double[_N];

            for (i = 1; i <= _N; )
            {

                do
                {
                    r1 = rnd.NextDouble() * 2 - 1;
                    r2 = rnd.NextDouble() * 2 - 1;
                    w = r1 * r1 + r2 * r2;
                }
                while (w > 1 || w <= 0);

                rnds[i - 1] = Math.Sqrt(-2.0 * Math.Log(w) / w) * r2;
                i += 1;

                if (i <= _N)
                {
                    rnds[i - 1] = Math.Sqrt(-2.0 * Math.Log(w) / w) * r1;
                    i += 1;
                }
            }
            return rnds;
        }
    }
}