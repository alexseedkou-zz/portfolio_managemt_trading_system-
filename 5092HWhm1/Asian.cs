using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{
    class AsianOption:Option
    {
       
        private OptionInfo opt;
        double c;
        double Asian_price;


        public AsianOption(OptionInfo op):base(op)
        {
            opt = op;
        } //Constructor function

        public double Calculate()
        {

            if (opt.Method == 1)
            {
                if (opt.Pnt)  //Pnt stands for call option
                {

                    c = Math.Max((totalSS1 / opt.NumberOfSteps) - opt.StrikePrice, 0);
                }
                else
                {
                    c = Math.Max(opt.StrikePrice - (totalSS1 / opt.NumberOfSteps), 0);
                }
            }
            else if (opt.Method == 2)
            {
                if (opt.Pnt)  //Pnt stands for call option
                {
                    c = 0.5 * (Math.Max((totalSS1 / opt.NumberOfSteps) - opt.StrikePrice, 0) + Math.Max((totalSS2 / opt.NumberOfSteps) - opt.StrikePrice, 0));
                }
                else
                {
                    c = 0.5 * (Math.Max(opt.StrikePrice - (totalSS1 / opt.NumberOfSteps), 0) + Math.Max(opt.StrikePrice - (totalSS2 / opt.NumberOfSteps), 0));
                }
            }
            else if(opt.Method==3)
            {
                if (opt.Pnt)  //Pnt stands for call option
                {

                    c = 0.5 * (Math.Max((totalSS1 / opt.NumberOfSteps) - opt.StrikePrice, 0) + Math.Max((totalSS2 / opt.NumberOfSteps) - opt.StrikePrice, 0) - CV1 - CV2);
                }
                else
                {
                    c = 0.5 * (Math.Max(opt.StrikePrice - (totalSS1 / opt.NumberOfSteps), 0) + Math.Max(opt.StrikePrice - (totalSS2 / opt.NumberOfSteps), 0) - CV1 - CV2);
                }
            }
            else if (opt.Method==4)
            {
                if (opt.Pnt)  //Pnt stands for call option
                {

                    c = Math.Max((totalSS1 / opt.NumberOfSteps) - opt.StrikePrice, 0) - CV1;
                }
                else
                {
                    c = Math.Max(opt.StrikePrice - (totalSS1 / opt.NumberOfSteps), 0) - CV1;
                }
            }
             return Asian_price=c * Math.Exp(-opt.InterestRate * opt.Tenor);
        }  //Get the price of Asian option.

       
    }
}
