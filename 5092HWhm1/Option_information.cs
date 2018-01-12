using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{
    public class OptionInfo
    {
        public OptionInfo(long M, int steps, double vol, double r, double S, double K, double t, double eps, bool pointer,double rebate,int barriertype,double barrierpx,int method)
        {
            numberofsimulation = M;
            numberofsteps = steps;
            volatility = vol;
            interestrate = r;
            underlyingprice = S;
            strikeprice = K;
            tenor = t;
            pnt = pointer;
            epslion = eps;
            rbt = rebate;
            ty = barriertype;
            brpx = barrierpx;
            mtd = method;

        }
        public OptionInfo copy()  //Copy the information from OptionInfo.
        {
            return new OptionInfo(
                    this.NumberOfSimulation,
                    this.NumberOfSteps,
                    this.Volatility,
                    this.InterestRate,
                    this.UnderlyingPrice,
                    this.StrikePrice,
                    this.Tenor,
                    this.Epslion,
                    this.Pnt,
                    this.Rbt,
                    this.Type,
                    this.Brpx,
                    this.Method
                    );
        }

        private int mtd;
        public int Method
        {
            get { return mtd; }
            set { mtd = value; }
        }
        private double brpx;
        public double Brpx
        {
            get { return brpx; }
            set { brpx = value; }
        }
            

        private int ty;
        public int Type
        {
            get { return ty; }
            set { ty = value; }
        }

       private double rbt;
       public double Rbt
       {
           get { return rbt; }
           set  {rbt=value;}
       }
        private double epslion;
        public double Epslion
        {
            get { return epslion; }
            set { epslion = value; }

        }

        private long numberofsimulation;
        public long NumberOfSimulation
        {
            get { return numberofsimulation; }
            set { numberofsimulation = value; }
        }

        private int numberofsteps;
        public int NumberOfSteps
        {
            get { return numberofsteps; }
            set { numberofsteps = value; }
        }

        private double volatility;
        public double Volatility
        {
            get { return volatility; }
            set { volatility = value; }
        }

        private double interestrate;
        public double InterestRate
        {
            get { return interestrate; }
            set { interestrate = value; }
        }

        private double underlyingprice;
        public double UnderlyingPrice
        {
            get { return underlyingprice; }
            set { underlyingprice = value; }
        }

        private double strikeprice;
        public double StrikePrice
        {
            get { return strikeprice; }
            set { strikeprice = value; }
        }

        private double tenor;
        public double Tenor
        {
            get { return tenor; }
            set { tenor = value; }
        }


        private bool pnt;
        public bool Pnt
        {
            get { return pnt; }
            set { pnt = value; }
        }
    }  // Store the input value. 
}
