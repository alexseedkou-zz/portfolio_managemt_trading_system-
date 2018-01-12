using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{
    class EuropeanOption:Option
    {
        private OptionInfo opt;
        double c;
        double European_price;
        public EuropeanOption(OptionInfo op):base(op)
        {
            opt = op;
        }

        public double Calculate()
        {
            if (opt.Method ==1)
            {
                if (opt.Pnt)  //call option
                {
                    c = Math.Max(SS1[opt.NumberOfSteps] - opt.StrikePrice, 0);
                }
                else
                {
                    c = Math.Max(opt.StrikePrice - SS1[opt.NumberOfSteps], 0);
                }
            }
            else if(opt.Method==2)
            {
                if (opt.Pnt)  //call option
                {
                    c = 0.5 * (Math.Max(SS1[opt.NumberOfSteps] - opt.StrikePrice, 0) + Math.Max(SS2[opt.NumberOfSteps] - opt.StrikePrice, 0));
                }
                else
                {
                    c = 0.5 * (Math.Max(opt.StrikePrice - SS1[opt.NumberOfSteps], 0) + Math.Max(opt.StrikePrice - SS2[opt.NumberOfSteps], 0));
                }
            }
            else if (opt.Method == 3) 
            {
                if (opt.Pnt)  //call option
                {
                    c = 0.5 * (Math.Max(SS1[opt.NumberOfSteps] - opt.StrikePrice, 0) + Math.Max(SS2[opt.NumberOfSteps] - opt.StrikePrice, 0) - CV1 - CV2);
                }
                else
                {
                    c = 0.5 * (Math.Max(opt.StrikePrice - SS1[opt.NumberOfSteps], 0) + Math.Max(opt.StrikePrice - SS2[opt.NumberOfSteps], 0) - CV1 - CV2);
                }
            }
            else if(opt.Method==4)
            {
                if (opt.Pnt)  //call option
                {
                    c = Math.Max(SS1[opt.NumberOfSteps] - opt.StrikePrice, 0) - CV1;
                }
                else
                {
                    c = Math.Max(opt.StrikePrice - SS1[opt.NumberOfSteps], 0) - CV1;
                }
            }
            return European_price = c * Math.Exp(-opt.InterestRate * opt.Tenor); 

        }  //Get the price of European Option.
       
    }
}
