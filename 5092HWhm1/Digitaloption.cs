using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{
    class Digitaloption : Option
    {
        private OptionInfo opt;
        double c, c1,c2;
        double Digital_price;
        public Digitaloption(OptionInfo op): base(op)
        {
            opt = op;
        }
        public double Calculate()
        {
            if (opt.Pnt)  //call option
            {
                if (SS1[opt.NumberOfSteps] >= opt.StrikePrice)
                {
                    c1 = opt.Rbt;
                }
                else
                {
                    c1 = 0;
                }
                if (SS2[opt.NumberOfSteps] >= opt.StrikePrice)
                {
                    c2 = opt.Rbt;
                }
                else
                {
                    c2 = 0;
                }
            }
            else
            {
                if (opt.StrikePrice >= SS1[opt.NumberOfSteps])
                {
                    c1 = opt.Rbt;
                }
                else
                {
                    c1 = 0;
                }
                if (opt.StrikePrice >= SS2[opt.NumberOfSteps])
                {
                    c2 = opt.Rbt;
                }
                else
                {
                    c2 = 0;
                }
            }

            if(opt.Method==1)
            {
                c = c1;
            }
            if(opt.Method==2)
            {
                c = 0.5 * (c1 + c2);
            }
            if(opt.Method==3)
            {
                c = 0.5 * (c1 + c2 - CV1 - CV2);
            }
            if(opt.Method==4)
            {
                c = c1 - CV1;
            }
            return Digital_price = c * Math.Exp(-opt.InterestRate * opt.Tenor);
        }
       
    }
}
