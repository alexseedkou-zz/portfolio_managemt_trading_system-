using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{
    class BarrierOption:Option
    {
        private OptionInfo opt;
        double c,c1,c2;
        double Barrier_price;
        double px1, px2;
        public BarrierOption(OptionInfo op):base(op)
        {
            opt = op;
        }
        public double Calculate()
        {
            px1 = SS1[opt.NumberOfSteps];
            px2 = SS2[opt.NumberOfSteps];
            Array.Sort(SS1);
            Array.Sort(SS2);
            switch (opt.Type)
            {
                case 1:       //Down and out
                    if (SS1[0] >= opt.Brpx)
                    {
                        c1 = px1;
                    }
                    else
                    {
                        c1 = 0;
                    }
                    if (SS2[0] >= opt.Brpx)
                    {
                        c2 = px2;
                    }
                    else
                    {
                        c2 = 0;
                    }
                    break;

                case 2:  //Up and out
                    if (SS1[opt.NumberOfSteps] <= opt.Brpx)
                    {
                        c1 = px1;
                    }
                    else
                    {
                        c1 = 0;
                    }
                    if (SS2[opt.NumberOfSteps] <= opt.Brpx)
                    {
                        c2 = px2;
                    }
                    else
                    {
                        c2 = 0;
                    }
                    break;

                case 3:  //Down and in
                    if (SS1[0] <= opt.Brpx)
                    {
                        c1 = px1;
                    }
                    else
                    {
                        c1 = 0;
                    }
                    if (SS2[0] <= opt.Brpx)
                    {
                        c2 = px2;
                    }
                    else
                    {
                        c2 = 0;
                    }
                    break;

                case 4:  //Up and in
                    if (SS1[opt.NumberOfSteps] >= opt.Brpx)
                    {
                        c1 = px1;
                    }
                    else
                    {
                        c1 = 0;
                    }
                    if (SS2[opt.NumberOfSteps] >= opt.Brpx)
                    {
                        c2 = px2;
                    }
                    else
                    {
                        c2 = 0;
                    }
                    break;

                default: break;
            }
            if (opt.Method==1)
            {
                if (c1 == 0)
                {
                    c = 0;
                }
                else
                {
                    if (opt.Pnt)// call option    
                    {
                        c = Math.Max((c1 - opt.StrikePrice), 0);
                    }
                    else
                    {
                        c = Math.Max((opt.StrikePrice - c1), 0);
                    }
                }
            }
            if(opt.Method==2)
            {
                if (c1 != 0 && c2 != 0)
                {
                    if (opt.Pnt)// call option    
                    {
                        c = 0.5 * (Math.Max((px1 - opt.StrikePrice), 0) + Math.Max((px2 - opt.StrikePrice), 0));
                    }
                    else
                    {
                        c = 0.5 * (Math.Max((opt.StrikePrice - px1), 0) + Math.Max((opt.StrikePrice) - px2, 0));
                    }
                }
                else if (c1 == 0 && c2 != 0)
                {
                    if (opt.Pnt)// call option    
                    {
                        c = 0.5 * (0 + Math.Max((px2 - opt.StrikePrice), 0));
                    }
                    else
                    {
                        c = 0.5 * (0 + Math.Max((opt.StrikePrice) - px2, 0));
                    }
                }
                else if (c1 != 0 && c2 == 0)
                {
                    if (opt.Pnt)// call option    
                    {
                        c = 0.5 * (Math.Max((px1 - opt.StrikePrice), 0) + 0);
                    }
                    else
                    {
                        c = 0.5 * (Math.Max((opt.StrikePrice - px1), 0) + 0);
                    }
                }
                else
                {
                    c = 0;
                }
            }
            if(opt.Method==3)
            {
                if (c1 != 0 && c2 != 0)
                {
                    if (opt.Pnt)// call option    
                    {
                        c = 0.5 * (Math.Max((c1 - opt.StrikePrice), 0) + Math.Max((c2 - opt.StrikePrice), 0));
                    }
                    else
                    {
                        c = 0.5 * (Math.Max((opt.StrikePrice - c1), 0) + Math.Max((opt.StrikePrice) - c2, 0));
                    }
                }
                else if (c1 == 0 && c2 != 0)
                {
                    if (opt.Pnt)// call option    
                    {
                        c = 0.5 * (0 + Math.Max((c2 - opt.StrikePrice), 0));
                    }
                    else
                    {
                        c = 0.5 * (0 + Math.Max((opt.StrikePrice) - c2, 0));
                    }
                }
                else if (c1 != 0 && c2 == 0)
                {
                    if (opt.Pnt)// call option    
                    {
                        c = 0.5 * (Math.Max((c1 - opt.StrikePrice), 0) + 0);
                    }
                    else
                    {
                        c = 0.5 * (Math.Max((opt.StrikePrice - c1), 0) + 0);
                    }
                }
                else
                {
                    c = 0;
                }
                c = c - 0.5 * (CV1 + CV2);
            }
            if(opt.Method==4)
            {
                if (c1 == 0)
                {
                    c = 0;
                }
                else
                {
                    if (opt.Pnt)// call option    
                    {
                        c = Math.Max((c1 - opt.StrikePrice), 0) - CV1;
                    }
                    else
                    {
                        c = Math.Max((opt.StrikePrice - c1), 0) - CV1;
                    }
                }
            }
            return Barrier_price = c * Math.Exp(-opt.InterestRate * opt.Tenor); 
        }    }
}
