using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{
    class RangeOption:Option
    {
        OptionInfo opt;
        double c,max1,min1,max2,min2;
        double Range_price,Range_price_antithetic,Range_price_antithetic_delta,Range_price_delta;
        public RangeOption(OptionInfo op):base(op)
        {
            opt = op;
        }
        public double Calculate()
        {
            max1 = SS1[opt.NumberOfSteps];
            min1 = SS1[opt.NumberOfSteps];
            max2 = SS2[opt.NumberOfSteps];
            min2 = SS2[opt.NumberOfSteps];
            for (int i = 1; i <= opt.NumberOfSteps; i++)
            {
                if (max1 <= SS1[i])
                {
                    max1 = SS1[i];
                }
                if (max2 <= SS2[i])
                {
                    max2 = SS2[i];
                }
                if (min1 >= SS1[i])
                {
                    min1 = SS1[i];
                }
                if (min2 >= SS2[i])
                {
                    min2 = SS2[i];
                }
            }
            if(opt.Method==1)
            {
                c = max1 - min1;
            }
            else if(opt.Method==2)
            {
                c = 0.5 * (max1 - min1 + max2 - min2);
            }
            else if(opt.Method==3)
            {
                c = 0.5 * (max1 - min1 + max2 - min2 - CV1 - CV2);
            }
            else if (opt.Method==4)
            {
                c = max1 - min1 - CV1;
            }
            return Range_price = c * Math.Exp(-opt.InterestRate * opt.Tenor);
        }
        public double Calculate_Range()
        {
            max1 = SS1[opt.NumberOfSteps];
            min1=SS1[opt.NumberOfSteps];
          for(int i=1;i<=opt.NumberOfSteps;i++)
          {
              if(max1<=SS1[i])
              {
                  max1 = SS1[i];
              }
              if(min1>=SS1[i])
              {
                  min1 = SS1[i];
              }
          }
          c = max1 - min1;
          Range_price = c * Math.Exp(-opt.InterestRate * opt.Tenor);
          return Range_price;
        }  //Get the price of Range Option
        public double Calculate_antithetic()
        {
            max1 = SS1[opt.NumberOfSteps];
            min1 = SS1[opt.NumberOfSteps];
            max2 = SS2[opt.NumberOfSteps];
            min2 = SS2[opt.NumberOfSteps];
            for (int i = 1; i <= opt.NumberOfSteps; i++)
            {
                if (max1 <= SS1[i])
                {
                    max1 = SS1[i];
                }
                if(max2<=SS2[i])
                {
                    max2 = SS2[i];
                }
                if (min1 >= SS1[i])
                {
                    min1 = SS1[i];
                }
                if(min2>=SS2[i])
                {
                    min2 = SS2[i];
                }
            }
            c = 0.5 * (max1 - min1 + max2 - min2);
            Range_price_antithetic = c * Math.Exp(-opt.InterestRate * opt.Tenor);
            return Range_price_antithetic;
        }  //Get the price of Range Option with antithetic
        public double Calculate_antithetic_delta()
        {
            max1 = SS1[opt.NumberOfSteps];
            min1 = SS1[opt.NumberOfSteps];
            max2 = SS2[opt.NumberOfSteps];
            min2 = SS2[opt.NumberOfSteps];
            for (int i = 1; i <= opt.NumberOfSteps; i++)
            {
                if (max1 <= SS1[i])
                {
                    max1 = SS1[i];
                }
                if (max2 <= SS2[i])
                {
                    max2 = SS2[i];
                }
                if (min1 >= SS1[i])
                {
                    min1 = SS1[i];
                }
                if (min2 >= SS2[i])
                {
                    min2 = SS2[i];
                }
            }
            c = 0.5 * (max1 - min1 + max2 - min2-CV1-CV2);
            Range_price_antithetic_delta = c * Math.Exp(-opt.InterestRate * opt.Tenor);
            return Range_price_antithetic_delta;
        }  //Get the price of Range Option bases on antithetic with delta
        public double Calculate_delta()
        {
            max1 = SS1[opt.NumberOfSteps];
            min1 = SS1[opt.NumberOfSteps];
            for (int i = 1; i <= opt.NumberOfSteps; i++)
            {
                if (max1 <= SS1[i])
                {
                    max1 = SS1[i];
                }
                if (min1 >= SS1[i])
                {
                    min1 = SS1[i];
                }
            }
            c =  max1 - min1-CV1;
            Range_price_delta = c * Math.Exp(-opt.InterestRate * opt.Tenor);
            return Range_price_delta;
        }  //Get the price of Range Option with delta
    }
}
