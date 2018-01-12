using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _5092HWhm1
{
    public class Thread_values
    {
        OptionInfo opt;

        public double European_DeltaT, Asian_DeltaT,Digital_DeltaT,Barrier_DeltaT,Lookback_DeltaT,Range_DeltaT;
        public double European_VegaT, Asian_VegaT, Digital_VegaT,Barrier_VegaT,Lookback_VegaT,Range_VegaT;
        public double European_GammaT, Asian_GammaT, Digital_GammaT,Barrier_GammaT,Lookback_GammaT,Range_GammaT;
        public double European_ThetaT,Asian_ThetaT,Digital_ThetaT,Barrier_ThetaT,Lookback_ThetaT,Range_ThetaT;
        public double European_RhoT,Asian_RhoT,Digital_RhoT,Barrier_RhoT,Lookback_RhoT,Range_RhoT;
        public double European_finalPrice,Asian_finalPrice,Digital_finalPrice,Barrier_finalPrice,Lookback_finalPrice,Range_finalPrice;
        public double European_TOET,Asian_TOET,Digital_TOET,Barrier_TOET,Lookback_TOET,Range_TOET;
        
        int cores = System.Environment.ProcessorCount;

        public Thread_values(OptionInfo op)
        {
            opt = op;
        }
        
        public void Calculate_european()
        {
            
            long M = opt.NumberOfSimulation;
            Greeks[] greeks = new Greeks[cores];
            Thread[] caller = new Thread[cores];
            long[] m = new long[cores];
            for (int i = 0; i < cores; i++)
            {
 
                m[i] = M / cores;
                if (i == (cores - 1))
                    m[i] = M - i * m[0];
                opt.NumberOfSimulation = m[i];
                greeks[i] = new Greeks(opt);
                caller[i] = new Thread(new ThreadStart(greeks[i].Calculate_European));
                caller[i].Start();
            }

            for (int j = 0; j < cores; j++)
            {
                caller[j].Join();
            }

            double[] Price = new double[M];

            for (int i = 0; i < cores; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    Price[i * m[0] + j] = greeks[i].Prices[j];
                }
            }



            for (int i = 0; i < M; i++)
            {
                European_finalPrice += Price[i] / M;
            }

          

            for (int j = 0; j < cores; j++)
            {
                European_DeltaT += ((double)m[j] / M) * greeks[j].Delta();
                European_VegaT += ((double)m[j] / M) * greeks[j].Vega();
                European_GammaT += ((double)m[j] / M) * greeks[j].Gamma();
                European_ThetaT += ((double)m[j] / M) * greeks[j].Theta();
                European_RhoT += ((double)m[j] / M) * greeks[j].Rho();
            }

            double std = 0.0;
            

            for (int i = 0; i < M; i++)
            {
                std += (Price[i] - European_finalPrice) * (Price[i] - European_finalPrice);
            }

            European_TOET = Math.Sqrt(std / (M - 1) / M); //Get the stderror.
        }    //Calculate european values with mutil thread

        public void Calculate_asian()
        {
           
            long M = opt.NumberOfSimulation;
            Greeks[] greeks = new Greeks[cores];
            Thread[] caller = new Thread[cores];
            long[] m = new long[cores];
            for (int i = 0; i < cores; i++)
            {

                m[i] = M / cores;
                if (i == (cores - 1))
                    m[i] = M - i * m[0];
                opt.NumberOfSimulation = m[i];
                greeks[i] = new Greeks(opt);
                caller[i] = new Thread(new ThreadStart(greeks[i].Calculate_Asian));
                caller[i].Start();
            }

            for (int j = 0; j < cores; j++)
            {
                caller[j].Join();
            }

            double[] Price = new double[M];

            for (int i = 0; i < cores; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    Price[i * m[0] + j] = greeks[i].Asian_Prices[j];
                }
            }



            for (int i = 0; i < M; i++)
            {
                Asian_finalPrice += Price[i] / M;
            }



            for (int j = 0; j < cores; j++)
            {
                Asian_DeltaT += ((double)m[j] / M) * greeks[j].Asian_Delta();
                Asian_VegaT += ((double)m[j] / M) * greeks[j].Asian_Vega();
                Asian_GammaT += ((double)m[j] / M) * greeks[j].Asian_Gamma();
                Asian_ThetaT += ((double)m[j] / M) * greeks[j].Asian_Theta();
                Asian_RhoT += ((double)m[j] / M) * greeks[j].Asian_Rho();
            }

            double std = 0.0;


            for (int i = 0; i < M; i++)
            {
                std += (Price[i] - Asian_finalPrice) * (Price[i] - Asian_finalPrice);
            }

            Asian_TOET = Math.Sqrt(std / (M - 1) / M); //Get the stderror.
        }    //Calculate asian values with mutil thread

        public void Calculate_digital()
        {
           
            long M = opt.NumberOfSimulation;
            Greeks[] greeks = new Greeks[cores];
            Thread[] caller = new Thread[cores];
            long[] m = new long[cores];
            for (int i = 0; i < cores; i++)
            {

                m[i] = M / cores;
                if (i == (cores - 1))
                    m[i] = M - i * m[0];
                opt.NumberOfSimulation = m[i];
                greeks[i] = new Greeks(opt);
                caller[i] = new Thread(new ThreadStart(greeks[i].Calculate_Digital));
                caller[i].Start();
            }

            for (int j = 0; j < cores; j++)
            {
                caller[j].Join();
            }

            double[] Price = new double[M];

            for (int i = 0; i < cores; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    Price[i * m[0] + j] = greeks[i].Digital_Prices[j];
                }
            }



            for (int i = 0; i < M; i++)
            {
                Digital_finalPrice += Price[i] / M;
            }



            for (int j = 0; j < cores; j++)
            {
                Digital_DeltaT += ((double)m[j] / M) * greeks[j].Digital_Delta();
                Digital_VegaT += ((double)m[j] / M) * greeks[j].Digital_Vega();
                Digital_GammaT += ((double)m[j] / M) * greeks[j].Digital_Gamma();
                Digital_ThetaT += ((double)m[j] / M) * greeks[j].Digital_Theta();
                Digital_RhoT += ((double)m[j] / M) * greeks[j].Digital_Rho();
            }

            double std = 0.0;


            for (int i = 0; i < M; i++)
            {
                std += (Price[i] - Digital_finalPrice) * (Price[i] - Digital_finalPrice);
            }

            Digital_TOET = Math.Sqrt(std / (M - 1) / M);
        }   //Calculate digital values with mutil thread

        public void Calculate_barrier()
        {
          
            long M = opt.NumberOfSimulation;
            Greeks[] greeks = new Greeks[cores];
            Thread[] caller = new Thread[cores];
            long[] m = new long[cores];
            for (int i = 0; i < cores; i++)
            {

                m[i] = M / cores;
                if (i == (cores - 1))
                    m[i] = M - i * m[0];
                opt.NumberOfSimulation = m[i];
                greeks[i] = new Greeks(opt);
                caller[i] = new Thread(new ThreadStart(greeks[i].Calculate_Barrier));
                caller[i].Start();
            }

            for (int j = 0; j < cores; j++)
            {
                caller[j].Join();
            }

            double[] Price = new double[M];

            for (int i = 0; i < cores; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    Price[i * m[0] + j] = greeks[i].Barrier_Prices[j];
                }
            }



            for (int i = 0; i < M; i++)
            {
                Barrier_finalPrice += Price[i] / M;
            }



            for (int j = 0; j < cores; j++)
            {
                Barrier_DeltaT += ((double)m[j] / M) * greeks[j].Barrier_Delta();
                Barrier_VegaT += ((double)m[j] / M) * greeks[j].Barrier_Vega();
                Barrier_GammaT += ((double)m[j] / M) * greeks[j].Barrier_Gamma();
                Barrier_ThetaT += ((double)m[j] / M) * greeks[j].Barrier_Theta();
                Barrier_RhoT += ((double)m[j] / M) * greeks[j].Barrier_Rho();
            }

            double std = 0.0;


            for (int i = 0; i < M; i++)
            {
                std += (Price[i] - Barrier_finalPrice) * (Price[i] - Barrier_finalPrice);
            }

            Barrier_TOET = Math.Sqrt(std / (M - 1) / M);
        }       //Calculate barrier values with mutil thread

        public void Calculate_lookback()
        {
            long M = opt.NumberOfSimulation;
            Greeks[] greeks = new Greeks[cores];
            Thread[] caller = new Thread[cores];
            long[] m = new long[cores];
            for (int i = 0; i < cores; i++)
            {

                m[i] = M / cores;
                if (i == (cores - 1))
                    m[i] = M - i * m[0];
                opt.NumberOfSimulation = m[i];
                greeks[i] = new Greeks(opt);
                caller[i] = new Thread(new ThreadStart(greeks[i].Calculate_Lookback));
                caller[i].Start();
            }

            for (int j = 0; j < cores; j++)
            {
                caller[j].Join();
            }

            double[] Price = new double[M];

            for (int i = 0; i < cores; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    Price[i * m[0] + j] = greeks[i].Lookback_Prices[j];
                }
            }



            for (int i = 0; i < M; i++)
            {
                Lookback_finalPrice += Price[i] / M;
            }



            for (int j = 0; j < cores; j++)
            {
                Lookback_DeltaT += ((double)m[j] / M) * greeks[j].Lookback_Delta();
                Lookback_VegaT += ((double)m[j] / M) * greeks[j].Lookback_Vega();
                Lookback_GammaT += ((double)m[j] / M) * greeks[j].Lookback_Gamma();
                Lookback_ThetaT += ((double)m[j] / M) * greeks[j].Lookback_Theta();
                Lookback_RhoT += ((double)m[j] / M) * greeks[j].Lookback_Rho();
            }

            double std = 0.0;


            for (int i = 0; i < M; i++)
            {
                std += (Price[i] - Lookback_finalPrice) * (Price[i] - Lookback_finalPrice);
            }

            Lookback_TOET = Math.Sqrt(std / (M - 1) / M);
        }    //Calculate lookback values with mutil thread

        public void Calculate_range()
        {
            long M = opt.NumberOfSimulation;
            Greeks[] greeks = new Greeks[cores];
            Thread[] caller = new Thread[cores];
            long[] m = new long[cores];
            for (int i = 0; i < cores; i++)
            {

                m[i] = M / cores;
                if (i == (cores - 1))
                    m[i] = M - i * m[0];
                opt.NumberOfSimulation = m[i];
                greeks[i] = new Greeks(opt);
                caller[i] = new Thread(new ThreadStart(greeks[i].Calculate_Range));
                caller[i].Start();
            }

            for (int j = 0; j < cores; j++)
            {
                caller[j].Join();
            }

            double[] Price = new double[M];

            for (int i = 0; i < cores; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    Price[i * m[0] + j] = greeks[i].Range_Prices[j];
                }
            }



            for (int i = 0; i < M; i++)
            {
                Range_finalPrice += Price[i] / M;
            }



            for (int j = 0; j < cores; j++)
            {
                Range_DeltaT += ((double)m[j] / M) * greeks[j].Range_Delta();
                Range_VegaT += ((double)m[j] / M) * greeks[j].Range_Vega();
                Range_GammaT += ((double)m[j] / M) * greeks[j].Range_Gamma();
                Range_ThetaT += ((double)m[j] / M) * greeks[j].Range_Theta();
                Range_RhoT += ((double)m[j] / M) * greeks[j].Range_Rho();
            }

            double std = 0.0;


            for (int i = 0; i < M; i++)
            {
                std += (Price[i] - Range_finalPrice) * (Price[i] - Range_finalPrice);
            }

            Range_TOET = Math.Sqrt(std / (M - 1) / M);
        }

    }
}