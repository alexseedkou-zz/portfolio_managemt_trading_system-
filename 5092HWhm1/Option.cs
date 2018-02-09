using _5092HWhm1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092HWhm1
{
    public class Option
    {
        private OptionInfo optionInfo;
        private RndGenerator rnds;
        Black_Scholes BS = new Black_Scholes();
        public double [] SS1;
        public double totalSS1;
        public double[] SS2;
        public double totalSS2;
        public double CV1, CV2;
        public double brpx1, brpx2;
        public Option(OptionInfo optInfo)
        {
            optionInfo = optInfo;
            rnds = new RndGenerator(optionInfo.NumberOfSteps);
            SS1 = new double[optionInfo.NumberOfSteps + 1];
            SS2 = new double[optionInfo.NumberOfSteps + 1];
        }

        public void CalculateOption(double []rnds)
        {
            double vol = optionInfo.Volatility;
            double r = optionInfo.InterestRate;
            double S = optionInfo.UnderlyingPrice;
            double K = optionInfo.StrikePrice;
            double t = optionInfo.Tenor;
            int steps = optionInfo.NumberOfSteps;
            bool P = optionInfo.Pnt;
            double barrier=optionInfo.Brpx;
            //SS1[0] = S;
            //SS2[0] = S;
            double dt = t / steps;
            totalSS1 = 0.0;
            totalSS2 = 0.0;
            CV1 = 0.0;
            CV2 = 0.0;
            double erddt;
            double t0;
            double[] delta1 = new double[steps + 1];
            double[] delta2 = new double[steps + 1];
            erddt = Math.Exp((r) * (dt));

                for (int i = 1; i <= steps; i++)
                {
                    SS1[i] = SS1[i - 1] * Math.Exp((r - vol * vol / 2.0) * dt + vol * Math.Sqrt(dt) * rnds[i - 1]);
                    totalSS1 += SS1[i];
                    SS2[i] = SS2[i - 1] * Math.Exp((r - vol * vol / 2.0) * dt + vol * Math.Sqrt(dt) * (-1) * rnds[i - 1]);
                    totalSS2 += SS2[i];
                }
           
          

            if (P)  //P stands for call option
            {

                for (int i = 0; i <= steps - 1; i++)
                {
                    t0 = (steps - i) * dt;
                    delta1[i] = BS.Call_delta(SS1[i], K, r, vol, t0);
                    CV1 += delta1[i] * (SS1[i + 1] - SS1[i] * erddt);
                    delta2[i] = BS.Call_delta(SS2[i], K, r, vol, t0);
                    CV2 += delta2[i] * (SS2[i + 1] - SS2[i] * erddt);
                }
            }
            else
            {

                for (int i = 0; i <= steps - 1; i++)
                {
                    t0 = (steps - i) * dt;
                    delta1[i] = BS.Put_delta(SS1[i], K, r, vol, t0);
                    CV1 += delta1[i] * (SS1[i + 1] - SS1[i] * erddt);
                    delta2[i] = BS.Put_delta(SS2[i], K, r, vol, t0);
                    CV2 += delta2[i] * (SS2[i + 1] - SS2[i] * erddt);
                }
            }
            
        }  //Get the array for the price of option based on every simulation.


    }  //Implement the Mont Carlo method to predict the the stock price.

    public class Greeks
    {
        private OptionInfo optionInfo;
        private EuropeanOption europ;
        private AsianOption asian;
        private Digitaloption digital;
        private LookbackOption lookback;
        private RangeOption range;
        private BarrierOption barrier;
        private RndGenerator rnd;
        private double original, Asian_original, value1, value2, Digital_original,Lookback_original,Range_original,Barrier_original;
        private double delta, Asian_delta,Digital_delta,Lookback_delta,Range_delta,Barrier_delta;
        private double gamma, Asian_gamma,Digital_gamma,Lookback_gamma,Range_gamma,Barrier_gamma;
        private double vega, Asian_vega,Digital_vega,Lookback_vega,Range_vega,Barrier_vega;
        private double rho, Asian_rho,Digital_rho,Lookback_rho,Range_rho,Barrier_rho;
        private double theta, Asian_theta,Digital_theta,Lookback_theta,Range_theta,Barrier_theta;
        private double TOE, Asian_TOE,Digital_TOE,Lookback_TOE,Range_TOE,Barrier_TOE;
        public double[] Prices;
        public double[] Asian_Prices;
        public double[] Digital_Prices;
        public double[] Lookback_Prices;
        public double[] Range_Prices;
        public double[] Barrier_Prices;
        private double[] rnds;
        public Greeks(OptionInfo optInfo)
        {
            optionInfo = optInfo;
            Prices = new double[optionInfo.NumberOfSimulation];
            Asian_Prices = new double[optionInfo.NumberOfSimulation];
            Digital_Prices = new double[optionInfo.NumberOfSimulation];
            Lookback_Prices = new double[optionInfo.NumberOfSimulation];
            Range_Prices = new double[optionInfo.NumberOfSimulation];
            Barrier_Prices = new double[optionInfo.NumberOfSimulation];
            rnd = new RndGenerator(optionInfo.NumberOfSteps);
            rnds = new double[optionInfo.NumberOfSteps];
        }
        
        public void Calculate_European()
        {
            OptionInfo optionInfo1 = optionInfo.copy();
            // Copy the information from the OptionInfo.

            europ=new EuropeanOption(optionInfo1);
            long M = optionInfo1.NumberOfSimulation;
            double eps = optionInfo1.Epslion;
            //double[] rnds = new double[optionInfo1.NumberOfSteps];
            double[] Delta = new double[M];
            double[] Gamma = new double[M];
            double[] Vega = new double[M];
            double[] Theta = new double[M];
            double[] Rho = new double[M];
            double[] Standarderror = new double[M];
        

            for (int i = 0; i <= M - 1; i++)
            {
                
                rnds = rnd.Normal();
                // Original
                europ.CalculateOption(rnds);
                
                original = europ.Calculate();


                // Delta
                optionInfo1.UnderlyingPrice *= (1.0 + eps);
                europ.CalculateOption(rnds);
                value1 = europ.Calculate();
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;
                optionInfo1.UnderlyingPrice *= (1.0 - eps);
                europ.CalculateOption(rnds);
                value2 = europ.Calculate();
                delta = (value1 - value2) / (2 * eps * optionInfo.UnderlyingPrice);

                // Gamma
                gamma = (value1 + value2 - 2 * original) / (eps * eps * optionInfo.UnderlyingPrice * optionInfo.UnderlyingPrice);
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;

                // Vega
                optionInfo1.Volatility *= (1.0 + eps);
                europ.CalculateOption(rnds);
                value1 = europ.Calculate();
                optionInfo1.Volatility = optionInfo.Volatility;
                optionInfo1.Volatility *= (1.0 - eps);
                europ.CalculateOption(rnds);
                value2 = europ.Calculate();
                vega = (value1 - value2) / (2 * eps * optionInfo.Volatility);
                optionInfo1.Volatility = optionInfo.Volatility;

                // Rho
                optionInfo1.InterestRate *= (1.0 + eps);
                europ.CalculateOption(rnds);
                value1 = europ.Calculate();
                optionInfo1.InterestRate = optionInfo.InterestRate;
                optionInfo1.InterestRate *= (1.0 - eps);
                europ.CalculateOption(rnds);
                value2 = europ.Calculate();
                rho = (value1 - value2) / (2 * eps * optionInfo.InterestRate);
                optionInfo1.InterestRate = optionInfo.InterestRate;

                // Theta
                optionInfo1.Tenor *= (1.0 + eps);
                europ.CalculateOption(rnds);
                value1 = europ.Calculate();
                optionInfo1.Tenor = optionInfo.Tenor;
                optionInfo1.Tenor *= (1.0 - eps);
                europ.CalculateOption(rnds);
                value2 = europ.Calculate();
                theta = (value1 - value2) / (2 * eps * optionInfo.Tenor);
                optionInfo1.Tenor = optionInfo.Tenor;

                Prices[i] = original;
                Delta[i] = delta;
                Theta[i] = theta;
                Gamma[i] = gamma;
                Rho[i] = rho;
                Vega[i] = vega;
            }

            double totalPrices = 0;
            double totalDelta = 0;
            double totalTheta = 0;
            double totalGamma = 0;
            double totalRho = 0;
            double totalVega = 0;

            for (int j = 0; j <= M - 1; j++)
            {
                totalPrices += Prices[j];
                totalDelta += Delta[j];
                totalTheta += Theta[j];
                totalGamma += Gamma[j];
                totalRho += Rho[j];
                totalVega += Vega[j];
            }

            original = totalPrices / M;
            delta = totalDelta / M;
            gamma = totalGamma / M;
            theta = -totalTheta / M;
            rho = totalRho / M;
            vega = totalVega / M;

            double std = 0.0;

            for (int i = 0; i < M; i++)
            {
                std += (Prices[i] - original) * (Prices[i] - original);
            }

            TOE = Math.Sqrt(std / (M - 1) / M);


        }   //Calculate the greek values of European Option

        public void Calculate_Asian()
        {
            OptionInfo optionInfo1 = optionInfo.copy();
            // Copy the information from the OptionInfo.

            asian = new AsianOption(optionInfo1);
            
            long M = optionInfo1.NumberOfSimulation;
            double eps = optionInfo1.Epslion;
            //double[] rnds = new double[optionInfo1.NumberOfSteps];
            double[] Delta = new double[M];
            double[] Gamma = new double[M];
            double[] Vega = new double[M];
            double[] Theta = new double[M];
            double[] Rho = new double[M];
            double[] Standarderror = new double[M];

            for (int i = 0; i <= M - 1; i++)
            {
                
                
                rnds = rnd.Normal();
                // Original
                asian.CalculateOption(rnds);
                Asian_Prices[i] = asian.Calculate();


                // Delta
                optionInfo1.UnderlyingPrice *= (1.0 + eps);
                asian.CalculateOption(rnds);
                value1 = asian.Calculate();
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;
                optionInfo1.UnderlyingPrice *= (1.0 - eps);
                asian.CalculateOption(rnds);
                value2 = asian.Calculate();
                Delta[i] = (value1 - value2) / (2 * eps * optionInfo.UnderlyingPrice);

                // Gamma
                Gamma[i] = (value1 + value2 - 2 * Asian_Prices[i]) / (eps * eps * optionInfo.UnderlyingPrice * optionInfo.UnderlyingPrice);
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;

                // Vega
                optionInfo1.Volatility *= (1.0 + eps);
                asian.CalculateOption(rnds);
                value1 = asian.Calculate();
                optionInfo1.Volatility = optionInfo.Volatility;
                optionInfo1.Volatility *= (1.0 - eps);
                asian.CalculateOption(rnds);
                value2 = asian.Calculate();
                Vega[i] = (value1 - value2) / (2 * eps * optionInfo.Volatility);
                optionInfo1.Volatility = optionInfo.Volatility;

                // Rho
                optionInfo1.InterestRate *= (1.0 + eps);
                asian.CalculateOption(rnds);
                value1 = asian.Calculate();
                optionInfo1.InterestRate = optionInfo.InterestRate;
                optionInfo1.InterestRate *= (1.0 - eps);
                asian.CalculateOption(rnds);
                value2 = asian.Calculate();
                Rho[i] = (value1 - value2) / (2 * eps * optionInfo.InterestRate);
                optionInfo1.InterestRate = optionInfo.InterestRate;

                // Theta
                optionInfo1.Tenor *= (1.0 + eps);
                asian.CalculateOption(rnds);
                value1 = asian.Calculate();
                optionInfo1.Tenor = optionInfo.Tenor;
                optionInfo1.Tenor *= (1.0 - eps);
                asian.CalculateOption(rnds);
                value2 = asian.Calculate();
                Theta[i] = (value1 - value2) / (2 * eps * optionInfo.Tenor);
                optionInfo1.Tenor = optionInfo.Tenor;
            }

            double totalPrices = 0;
            double totalDelta = 0;
            double totalTheta = 0;
            double totalGamma = 0;
            double totalRho = 0;
            double totalVega = 0;

            for (int j = 0; j <= M - 1; j++)
            {
                totalPrices += Asian_Prices[j];
                totalDelta += Delta[j];
                totalTheta += Theta[j];
                totalGamma += Gamma[j];
                totalRho += Rho[j];
                totalVega += Vega[j];
            }

            Asian_original = totalPrices / M;
            Asian_delta = totalDelta / M;
            Asian_gamma = totalGamma / M;
            Asian_theta = -totalTheta / M;
            Asian_rho = totalRho / M;
            Asian_vega = totalVega / M;

            double std = 0.0;

            for (int i = 0; i < M; i++)
            {
                std += (Asian_Prices[i] - Asian_original) * (Asian_Prices[i] - Asian_original);
            }

            Asian_TOE = Math.Sqrt(std / (M - 1) / M);
        }  //Calculate the greek values of Asian Option


        public void Calculate_Digital()
        {
            OptionInfo optionInfo1 = optionInfo.copy();
            // Copy the information from the OptionInfo.


            digital = new Digitaloption(optionInfo1);
            long M = optionInfo1.NumberOfSimulation;
            double eps = optionInfo1.Epslion;
            //double[] rnds = new double[optionInfo1.NumberOfSteps];
            double[] Delta = new double[M];
            double[] Gamma = new double[M];
            double[] Vega = new double[M];
            double[] Theta = new double[M];
            double[] Rho = new double[M];
            double[] Standarderror = new double[M];
           
            for (int i = 0; i <= M - 1; i++)
            {
                
                rnds = rnd.Normal();
                // Original
                digital.CalculateOption(rnds);
                Digital_Prices[i] = digital.Calculate();


                // Delta
                optionInfo1.UnderlyingPrice *= (1.0 + eps);
                digital.CalculateOption(rnds);
                value1 = digital.Calculate();
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;
                optionInfo1.UnderlyingPrice *= (1.0 - eps);
                digital.CalculateOption(rnds);
                value2 = digital.Calculate();
                Delta[i] = (value1 - value2) / (2 * eps * optionInfo.UnderlyingPrice);

                // Gamma
                Gamma[i] = (value1 + value2 - 2 * Digital_Prices[i]) / (eps * eps * optionInfo.UnderlyingPrice * optionInfo.UnderlyingPrice);
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;

                // Vega
                optionInfo1.Volatility *= (1.0 + eps);
                digital.CalculateOption(rnds);
                value1 = digital.Calculate();
                optionInfo1.Volatility = optionInfo.Volatility;
                optionInfo1.Volatility *= (1.0 - eps);
                digital.CalculateOption(rnds);
                value2 = digital.Calculate();
                Vega[i] = (value1 - value2) / (2 * eps * optionInfo.Volatility);
                optionInfo1.Volatility = optionInfo.Volatility;

                // Rho
                optionInfo1.InterestRate *= (1.0 + eps);
                digital.CalculateOption(rnds);
                value1 = digital.Calculate();
                optionInfo1.InterestRate = optionInfo.InterestRate;
                optionInfo1.InterestRate *= (1.0 - eps);
                digital.CalculateOption(rnds);
                value2 = digital.Calculate();
                Rho[i] = (value1 - value2) / (2 * eps * optionInfo.InterestRate);
                optionInfo1.InterestRate = optionInfo.InterestRate;

                // Theta
                optionInfo1.Tenor *= (1.0 + eps);
                digital.CalculateOption(rnds);
                value1 = digital.Calculate();
                optionInfo1.Tenor = optionInfo.Tenor;
                optionInfo1.Tenor *= (1.0 - eps);
                digital.CalculateOption(rnds);
                value2 = digital.Calculate();
                Theta[i] = (value1 - value2) / (2 * eps * optionInfo.Tenor);
                optionInfo1.Tenor = optionInfo.Tenor;

                ;
            }

            double totalPrices = 0;
            double totalDelta = 0;
            double totalTheta = 0;
            double totalGamma = 0;
            double totalRho = 0;
            double totalVega = 0;

            for (int j = 0; j <= M - 1; j++)
            {
                totalPrices += Digital_Prices[j];
                totalDelta += Delta[j];
                totalTheta += Theta[j];
                totalGamma += Gamma[j];
                totalRho += Rho[j];
                totalVega += Vega[j];
            }

            Digital_original = totalPrices / M;
            Digital_delta = totalDelta / M;
            Digital_vega = totalDelta / M;
            Digital_gamma = totalGamma / M;
            Digital_theta = -totalTheta / M;
            Digital_rho = totalRho / M;
            Digital_vega = totalVega / M;

            double std = 0.0;

            for (int i = 0; i < M; i++)
            {
                std += (Digital_Prices[i] - Digital_original) * (Digital_Prices[i] - Digital_original);
            }

            Digital_TOE = Math.Sqrt(std / (M - 1) / M);


        }   //Calculate the greek values of European Option

       

        public void Calculate_Lookback()
        {
            OptionInfo optionInfo1 = optionInfo.copy();
            // Copy the information from the OptionInfo.

            lookback = new LookbackOption(optionInfo1);

            long M = optionInfo1.NumberOfSimulation;
            double eps = optionInfo1.Epslion;
            //double[] rnds = new double[optionInfo1.NumberOfSteps];
            double[] Delta = new double[M];
            double[] Gamma = new double[M];
            double[] Vega = new double[M];
            double[] Theta = new double[M];
            double[] Rho = new double[M];
            double[] Standarderror = new double[M];
          

            for (int i = 0; i <= M - 1; i++)
            {

                
                rnds = rnd.Normal();
                // Original
                lookback.CalculateOption(rnds);
                Lookback_Prices[i] = lookback.Calculate();


                // Delta
                optionInfo1.UnderlyingPrice *= (1.0 + eps);
                lookback.CalculateOption(rnds);
                value1 = lookback.Calculate();
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;
                optionInfo1.UnderlyingPrice *= (1.0 - eps);
                lookback.CalculateOption(rnds);
                value2 = lookback.Calculate();
                Delta[i] = (value1 - value2) / (2 * eps * optionInfo.UnderlyingPrice);

                // Gamma
                Gamma[i] = (value1 + value2 - 2 * Lookback_Prices[i]) / (eps * eps * optionInfo.UnderlyingPrice * optionInfo.UnderlyingPrice);
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;

                // Vega
                optionInfo1.Volatility *= (1.0 + eps);
                lookback.CalculateOption(rnds);
                value1 = lookback.Calculate();
                optionInfo1.Volatility = optionInfo.Volatility;
                optionInfo1.Volatility *= (1.0 - eps);
                lookback.CalculateOption(rnds);
                value2 = lookback.Calculate();
                Vega[i] = (value1 - value2) / (2 * eps * optionInfo.Volatility);
                optionInfo1.Volatility = optionInfo.Volatility;

                // Rho
                optionInfo1.InterestRate *= (1.0 + eps);
                lookback.CalculateOption(rnds);
                value1 = lookback.Calculate();
                optionInfo1.InterestRate = optionInfo.InterestRate;
                optionInfo1.InterestRate *= (1.0 - eps);
                lookback.CalculateOption(rnds);
                value2 = lookback.Calculate();
                Rho[i] = (value1 - value2) / (2 * eps * optionInfo.InterestRate);
                optionInfo1.InterestRate = optionInfo.InterestRate;

                // Theta
                optionInfo1.Tenor *= (1.0 + eps);
                lookback.CalculateOption(rnds);
                value1 = lookback.Calculate();
                optionInfo1.Tenor = optionInfo.Tenor;
                optionInfo1.Tenor *= (1.0 - eps);
                lookback.CalculateOption(rnds);
                value2 = lookback.Calculate();
                Theta[i] = (value1 - value2) / (2 * eps * optionInfo.Tenor);
                optionInfo1.Tenor = optionInfo.Tenor;
            }

            double totalPrices = 0;
            double totalDelta = 0;
            double totalTheta = 0;
            double totalGamma = 0;
            double totalRho = 0;
            double totalVega = 0;

            for (int j = 0; j <= M - 1; j++)
            {
                totalPrices += Lookback_Prices[j];
                totalDelta += Delta[j];
                totalTheta += Theta[j];
                totalGamma += Gamma[j];
                totalRho += Rho[j];
                totalVega += Vega[j];
            }

            Lookback_original = totalPrices / M;
            Lookback_delta = totalDelta / M;
            Lookback_gamma = totalGamma / M;
            Lookback_theta = -totalTheta / M;
            Lookback_rho = totalRho / M;
            Lookback_vega = totalVega / M;

            double std = 0.0;

            for (int i = 0; i < M; i++)
            {
                std += (Lookback_Prices[i] - Lookback_original) * (Lookback_Prices[i] - Lookback_original);
            }

            Lookback_TOE = Math.Sqrt(std / (M - 1) / M);
        }  //Calculate the greek values of Lookback Option

        public void Calculate_Range()
        {
            OptionInfo optionInfo1 = optionInfo.copy();
            // Copy the information from the OptionInfo.

            range = new RangeOption(optionInfo1);

            long M = optionInfo1.NumberOfSimulation;
            double eps = optionInfo1.Epslion;
            //double[] rnds = new double[optionInfo1.NumberOfSteps];
            double[] Delta = new double[M];
            double[] Gamma = new double[M];
            double[] Vega = new double[M];
            double[] Theta = new double[M];
            double[] Rho = new double[M];
            double[] Standarderror = new double[M];

            for (int i = 0; i <= M - 1; i++)
            {

               
                rnds = rnd.Normal();
                // Original
                range.CalculateOption(rnds);
                Range_Prices[i] = range.Calculate();


                // Delta
                optionInfo1.UnderlyingPrice *= (1.0 + eps);
                range.CalculateOption(rnds);
                value1 = range.Calculate();
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;
                optionInfo1.UnderlyingPrice *= (1.0 - eps);
                range.CalculateOption(rnds);
                value2 = range.Calculate();
                Delta[i] = (value1 - value2) / (2 * eps * optionInfo.UnderlyingPrice);

                // Gamma
                Gamma[i] = (value1 + value2 - 2 * Range_Prices[i]) / (eps * eps * optionInfo.UnderlyingPrice * optionInfo.UnderlyingPrice);
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;

                // Vega
                optionInfo1.Volatility *= (1.0 + eps);
                range.CalculateOption(rnds);
                value1 = range.Calculate();
                optionInfo1.Volatility = optionInfo.Volatility;
                optionInfo1.Volatility *= (1.0 - eps);
                range.CalculateOption(rnds);
                value2 = range.Calculate();
                Vega[i] = (value1 - value2) / (2 * eps * optionInfo.Volatility);
                optionInfo1.Volatility = optionInfo.Volatility;

                // Rho
                optionInfo1.InterestRate *= (1.0 + eps);
                range.CalculateOption(rnds);
                value1 = range.Calculate();
                optionInfo1.InterestRate = optionInfo.InterestRate;
                optionInfo1.InterestRate *= (1.0 - eps);
                range.CalculateOption(rnds);
                value2 = range.Calculate();
                Rho[i] = (value1 - value2) / (2 * eps * optionInfo.InterestRate);
                optionInfo1.InterestRate = optionInfo.InterestRate;

                // Theta
                optionInfo1.Tenor *= (1.0 + eps);
                range.CalculateOption(rnds);
                value1 = range.Calculate();
                optionInfo1.Tenor = optionInfo.Tenor;
                optionInfo1.Tenor *= (1.0 - eps);
                range.CalculateOption(rnds);
                value2 = range.Calculate();
                Theta[i] = (value1 - value2) / (2 * eps * optionInfo.Tenor);
                optionInfo1.Tenor = optionInfo.Tenor;
            }

            double totalPrices = 0;
            double totalDelta = 0;
            double totalTheta = 0;
            double totalGamma = 0;
            double totalRho = 0;
            double totalVega = 0;

            for (int j = 0; j <= M - 1; j++)
            {
                totalPrices += Range_Prices[j];
                totalDelta += Delta[j];
                totalTheta += Theta[j];
                totalGamma += Gamma[j];
                totalRho += Rho[j];
                totalVega += Vega[j];
            }

            Range_original = totalPrices / M;
            Range_delta = totalDelta / M;
            Range_gamma = totalGamma / M;
            Range_theta = -totalTheta / M;
            Range_rho = totalRho / M;
            Range_vega = totalVega / M;

            double std = 0.0;

            for (int i = 0; i < M; i++)
            {
                std += (Range_Prices[i] - Range_original) * (Range_Prices[i] - Range_original);
            }

            Range_TOE = Math.Sqrt(std / (M - 1) / M);
        }  //Calculate the greek values of Range Option.

        public void Calculate_Barrier()
        {
            OptionInfo optionInfo1 = optionInfo.copy();
            // Copy the information from the OptionInfo.

            barrier = new BarrierOption(optionInfo1);

            long M = optionInfo1.NumberOfSimulation;
            double eps = optionInfo1.Epslion;
           // double[] rnds = new double[optionInfo1.NumberOfSteps];
            double[] Delta = new double[M];
            double[] Gamma = new double[M];
            double[] Vega = new double[M];
            double[] Theta = new double[M];
            double[] Rho = new double[M];
            double[] Standarderror = new double[M];

            for (int i = 0; i <= M - 1; i++)
            {

                
                rnds = rnd.Normal();
                // Original
                barrier.CalculateOption(rnds);
                Barrier_Prices[i] = barrier.Calculate();


                // Delta
                optionInfo1.UnderlyingPrice *= (1.0 + eps);
                barrier.CalculateOption(rnds);
                value1 = barrier.Calculate();
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;
                optionInfo1.UnderlyingPrice *= (1.0 - eps);
                barrier.CalculateOption(rnds);
                value2 = barrier.Calculate();
                Delta[i] = (value1 - value2) / (2 * eps * optionInfo.UnderlyingPrice);

                // Gamma
                Gamma[i] = (value1 + value2 - 2 * Barrier_Prices[i]) / (eps * eps * optionInfo.UnderlyingPrice * optionInfo.UnderlyingPrice);
                optionInfo1.UnderlyingPrice = optionInfo.UnderlyingPrice;

                // Vega
                optionInfo1.Volatility *= (1.0 + eps);
                barrier.CalculateOption(rnds);
                value1 = barrier.Calculate();
                optionInfo1.Volatility = optionInfo.Volatility;
                optionInfo1.Volatility *= (1.0 - eps);
                barrier.CalculateOption(rnds);
                value2 = barrier.Calculate();
                Vega[i] = (value1 - value2) / (2 * eps * optionInfo.Volatility);
                optionInfo1.Volatility = optionInfo.Volatility;

                // Rho
                optionInfo1.InterestRate *= (1.0 + eps);
                barrier.CalculateOption(rnds);
                value1 = barrier.Calculate();
                optionInfo1.InterestRate = optionInfo.InterestRate;
                optionInfo1.InterestRate *= (1.0 - eps);
                barrier.CalculateOption(rnds);
                value2 = barrier.Calculate();
                Rho[i] = (value1 - value2) / (2 * eps * optionInfo.InterestRate);
                optionInfo1.InterestRate = optionInfo.InterestRate;

                // Theta
                optionInfo1.Tenor *= (1.0 + eps);
                barrier.CalculateOption(rnds);
                value1 = barrier.Calculate();
                optionInfo1.Tenor = optionInfo.Tenor;
                optionInfo1.Tenor *= (1.0 - eps);
                barrier.CalculateOption(rnds);
                value2 = barrier.Calculate();
                Theta[i] = (value1 - value2) / (2 * eps * optionInfo.Tenor);
                optionInfo1.Tenor = optionInfo.Tenor;
            }

            double totalPrices = 0;
            double totalDelta = 0;
            double totalTheta = 0;
            double totalGamma = 0;
            double totalRho = 0;
            double totalVega = 0;

            for (int j = 0; j <= M - 1; j++)
            {
                totalPrices += Barrier_Prices[j];
                totalDelta += Delta[j];
                totalTheta += Theta[j];
                totalGamma += Gamma[j];
                totalRho += Rho[j];
                totalVega += Vega[j];
            }

            Barrier_original = totalPrices / M;
            Barrier_delta = totalDelta / M;
            Barrier_gamma = totalGamma / M;
            Barrier_theta = -totalTheta / M;
            Barrier_rho = totalRho / M;
            Barrier_vega = totalVega / M;

            double std = 0.0;

            for (int i = 0; i < M; i++)
            {
                std += (Barrier_Prices[i] - Barrier_original) * (Barrier_Prices[i] - Barrier_original);
            }

            Barrier_TOE = Math.Sqrt(std / (M - 1) / M);
        }  //Calculate the greek values of Barrier Option


        // Get the values of European Option.
        public double Value() { return original; }
        public double ToleranceOfError() { return TOE; }
        public double Delta() { return delta; }
        public double Gamma() { return gamma; }
        public double Theta() { return theta; }
        public double Rho() { return rho; }
        public double Vega() { return vega; }

        // Get the values of Asian Option
        public double Asian_Value() { return Asian_original; }
        public double Asian_ToleranceOfError() { return Asian_TOE; }
        public double Asian_Delta() { return Asian_delta; }
        public double Asian_Gamma() { return Asian_gamma; }
        public double Asian_Theta() { return Asian_theta; }
        public double Asian_Rho() { return Asian_rho; }
        public double Asian_Vega() {return Asian_vega;}   //Get the greek value of option

        // Get the values of Digital Option.
        public double Digital_Value() { return Digital_original; }
        public double Digital_ToleranceOfError() { return Digital_TOE; }
        public double Digital_Delta() { return Digital_delta; }
        public double Digital_Gamma() { return Digital_gamma; }
        public double Digital_Theta() { return Digital_theta; }
        public double Digital_Rho() { return Digital_rho; }
        public double Digital_Vega() { return Digital_vega; }

        // Get the values of Lookback Option.
        public double Lookback_Value() { return Lookback_original; }
        public double Lookback_ToleranceOfError() { return Lookback_TOE; }
        public double Lookback_Delta() { return Lookback_delta; }
        public double Lookback_Gamma() { return Lookback_gamma; }
        public double Lookback_Theta() { return Lookback_theta; }
        public double Lookback_Rho() { return Lookback_rho; }
        public double Lookback_Vega() { return Lookback_vega; }

        // Get the values of Range Option.
        public double Range_Value() { return Range_original; }
        public double Range_ToleranceOfError() { return Range_TOE; }
        public double Range_Delta() { return Range_delta; }
        public double Range_Gamma() { return Range_gamma; }
        public double Range_Theta() { return Range_theta; }
        public double Range_Rho() { return Range_rho; }
        public double Range_Vega() { return Range_vega; }

        // Get the values of Barrier Option.
        public double Barrier_Value() { return Barrier_original; }
        public double Barrier_ToleranceOfError() { return Barrier_TOE; }
        public double Barrier_Delta() { return Barrier_delta; }
        public double Barrier_Gamma() { return Barrier_gamma; }
        public double Barrier_Theta() { return Barrier_theta; }
        public double Barrier_Rho() { return Barrier_rho; }
        public double Barrier_Vega() { return Barrier_vega; }
    }  //Get the values for the options.

    public class Black_Scholes
    {


        double d1;
        double call_delta;
        double put_delta;
        //NormalDist nomdist = new NormalDist(0, 1);

        public double Call_delta(double S, double K, double R, double Vol, double T)
        {
            d1 = (Math.Log(S / K) + (R + (Vol * Vol) * (0.5)) * T) / (Vol * (Math.Sqrt(T)));
            call_delta = Phi(d1);
            put_delta = Phi(d1) - 1;
            return call_delta;
        }  //Get the call delta
        public double Put_delta(double S, double K, double R, double Vol, double T)
        {
            d1 = (Math.Log(S / K) + (R + (Vol * Vol) * (0.5)) * T) / (Vol * (Math.Sqrt(T)));
            call_delta = Phi(d1);
            put_delta = Phi(d1) - 1;
            return put_delta;
        }  //Get the put delta

        public double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }  //Calculate CDF for normal distribution.

    }    //Calculate the Delta with the Black-Scholes method
}
