using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using _5092HWhm1;


namespace _5092HWhm1
{
    public partial class Form1 : Form
    {
        private static bool pointer = false;
       
        public Form1()
        {
            InitializeComponent();
        }
        
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {
                textBox18.Enabled = true;
                
            }
            else
            {
                textBox18.Enabled = false;
                
            }
            
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                textBox19.Enabled = true;
                comboBox1.Enabled = true;
                if (comboBox1.Text == "")
                { MessageBox.Show("Please choose a barrier type."); }
            }
            else
            { 
                textBox19.Enabled = false;
                comboBox1.Enabled = false;
            }
        }
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked == true)
            {
                textBox2.Enabled = false;

            }
            else
            {
                textBox2.Enabled = true;

            }
        }  
        private void textBox1_error(object sender, EventArgs e)
        {
            string str = textBox1.Text.Trim();
            double num;
            bool Isnum=double.TryParse(str, out num);
            if(Isnum)
            {  
                if (Convert.ToDouble(textBox1.Text) <= 0 || Convert.ToDouble(textBox1.Text) > 10000)
                {
                    errorProvider1.SetError(textBox1, "Please type in a number between 0 and 10000");
                    pointer = false;
                }
                else
                {
                   errorProvider1.SetError(textBox1,string.Empty);
                   pointer = true;
                }
            }
            else
            {
                errorProvider1.SetError(textBox1, "Please type in a number");
                pointer = false;
            }
        }
        private void textBox2_error(object sender, EventArgs e)
        {
            string str = textBox2.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if(Isnum)
            {  
                if (Convert.ToDouble(textBox2.Text) <= 0 || Convert.ToDouble(textBox2.Text) > 10000)
                {
                    errorProvider2.SetError(textBox2, "Please type in a number between 0 and 10000");
                    pointer = false;
                }
                else
                {
                   errorProvider2.SetError(textBox2,string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider2.SetError(textBox2, "Please type in a number");
                pointer = false;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string str = textBox3.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox3.Text) <= 0 || Convert.ToDouble(textBox3.Text) >=0.5 )
                {
                    errorProvider3.SetError(textBox3, "Please type in a number between 0 and 0.5");
                    pointer = false;
                }
                else
                {
                    errorProvider3.SetError(textBox3, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider3.SetError(textBox3, "Please type in a number");
                pointer = false;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string str = textBox4.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox4.Text) <= 0 || Convert.ToDouble(textBox4.Text) >= 1)
                {
                    errorProvider4.SetError(textBox4, "Please type in the volatility between 0 and 1");
                    pointer = false;
                }
                else
                {
                    errorProvider4.SetError(textBox4, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider4.SetError(textBox4, "Please type in a number");
                pointer = false;
            }

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string str = textBox5.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox5.Text) >= 100 || Convert.ToDouble(textBox5.Text) <=0)
                {
                    errorProvider5.SetError(textBox5, "Please type in the tenor between 0 and 100");
                    pointer = false;
                }
                else
                {
                    errorProvider5.SetError(textBox5, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider5.SetError(textBox5, "Please type in a number");
                pointer = false;
            }

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string str = textBox6.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox6.Text) > 1000 || Convert.ToDouble(textBox6.Text) <= 0)
                {
                    errorProvider6.SetError(textBox6, "Please type in the steps between 0 and 1000");
                    pointer = false;
                }
                else
                {
                    errorProvider6.SetError(textBox6, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider6.SetError(textBox6, "Please type in a number");
                pointer = false;
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string str = textBox7.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox7.Text) > 10000000 || Convert.ToDouble(textBox7.Text) <= 0)
                {
                    errorProvider7.SetError(textBox7, "Please type in the number of simulation between 0 and 10000000");
                    pointer = false;
                }
                else
                {
                    errorProvider7.SetError(textBox7, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider7.SetError(textBox7, "Please type in a number");
                pointer = false;
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string str = textBox8.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox8.Text) > 0.1|| Convert.ToDouble(textBox8.Text) <= 0)
                {
                    errorProvider8.SetError(textBox8, "please type in the number of epsilon in (0,0.1], more is useless!");
                    pointer = false;
                }
                else
                {
                    errorProvider8.SetError(textBox8, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider8.SetError(textBox8, "Please type in a number");
                pointer = false;
            }
        }
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            string str = textBox18.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox18.Text)<= 0)
                {
                    errorProvider9.SetError(textBox18, "please type in the number beyond 0");
                    pointer = false;
                }
                else
                {
                    errorProvider9.SetError(textBox18, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider9.SetError(textBox18, "Please type in a number");
                pointer = false;
            }
        }
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            string str = textBox19.Text.Trim();
            double num;
            bool Isnum = double.TryParse(str, out num);
            if (Isnum)
            {
                if (Convert.ToDouble(textBox19.Text) <= 0)
                {
                    errorProvider10.SetError(textBox19, "please type in the number beyond 0");
                    pointer = false;
                }
                else
                {
                    errorProvider10.SetError(textBox19, string.Empty);
                    pointer = true;
                }
            }
            else
            {
                errorProvider10.SetError(textBox19, "Please type in a number");
                pointer = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton7.Checked == false && 
                radioButton8.Checked == false && 
                radioButton9.Checked == false&&
                radioButton10.Checked==false&&
                radioButton11.Checked==false&&
                radioButton12.Checked==false)

            { MessageBox.Show("Please choose an option type."); }


            Stopwatch run_time = new Stopwatch();
            
            run_time.Start();

            int cores = System.Environment.ProcessorCount; // Get the number of the cores.
            
            bool Multi = false;  

            if (checkBox1.CheckState == CheckState.Checked)
            {
                Multi = true;
            }
            else
            {
                Multi = false;

            }


            if (pointer == true)  
            {
                
                //European Option
                if (radioButton7.Checked == true)  //Calculate European Option price.
                {
                    OptionInfo optionInfo;
                    Thread_values TV;
                    int M = Convert.ToInt32(textBox7.Text),
                        steps = Convert.ToInt32(textBox6.Text);
                    double vol = Convert.ToDouble(textBox4.Text),
                        r = Convert.ToDouble(textBox3.Text),
                        S = Convert.ToDouble(textBox1.Text),
                        K = Convert.ToDouble(textBox2.Text),
                        t = Convert.ToDouble(textBox5.Text),
                        eps = Convert.ToDouble(textBox8.Text);

                    double barrier = 0.0;
                    int type = 0;
                    double rebate = 0.0;
                    bool pointer1;

                    if (Multi == true)
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;  //call option
                                textBox17.Text = "This is European call option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;//put option
                                textBox17.Text = "This is European put option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            TV = new Thread_values(optionInfo);
                            //Calculate the values with multiple thread
                            TV.Calculate_european();
                            
                            textBox12.Text = Convert.ToString(TV.European_DeltaT);
                            textBox10.Text = Convert.ToString(TV.European_finalPrice);
                            textBox14.Text = Convert.ToString(TV.European_VegaT);
                            textBox13.Text = Convert.ToString(TV.European_GammaT);
                            textBox15.Text = Convert.ToString(TV.European_RhoT);
                            textBox16.Text = Convert.ToString(TV.European_ThetaT);
                            textBox11.Text = Convert.ToString(TV.European_TOET);
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is European call option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is European put option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);

                            TV = new Thread_values(optionInfo);
                            TV.Calculate_european();

                            textBox12.Text = Convert.ToString(TV.European_DeltaT);
                            textBox10.Text = Convert.ToString(TV.European_finalPrice);
                            textBox14.Text = Convert.ToString(TV.European_VegaT);
                            textBox13.Text = Convert.ToString(TV.European_GammaT);
                            textBox15.Text = Convert.ToString(TV.European_RhoT);
                            textBox16.Text = Convert.ToString(TV.European_ThetaT);
                            textBox11.Text = Convert.ToString(TV.European_TOET);
                        }

                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is European call option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is European put option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);

                            TV = new Thread_values(optionInfo);
                            TV.Calculate_european();
                            textBox12.Text = Convert.ToString(TV.European_DeltaT);
                            textBox10.Text = Convert.ToString(TV.European_finalPrice);
                            textBox14.Text = Convert.ToString(TV.European_VegaT);
                            textBox13.Text = Convert.ToString(TV.European_GammaT);
                            textBox15.Text = Convert.ToString(TV.European_RhoT);
                            textBox16.Text = Convert.ToString(TV.European_ThetaT);
                            textBox11.Text = Convert.ToString(TV.European_TOET);

                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is European call option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is European put option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_european();
                            textBox12.Text = Convert.ToString(TV.European_DeltaT);
                            textBox10.Text = Convert.ToString(TV.European_finalPrice);
                            textBox14.Text = Convert.ToString(TV.European_VegaT);
                            textBox13.Text = Convert.ToString(TV.European_GammaT);
                            textBox15.Text = Convert.ToString(TV.European_RhoT);
                            textBox16.Text = Convert.ToString(TV.European_ThetaT);
                            textBox11.Text = Convert.ToString(TV.European_TOET);

                        }

                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is European call option!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is European put option!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_European();
                            textBox12.Text = Convert.ToString(greeks.Delta());
                            textBox10.Text = Convert.ToString(greeks.Value());
                            textBox14.Text = Convert.ToString(greeks.Vega());
                            textBox13.Text = Convert.ToString(greeks.Gamma());
                            textBox15.Text = Convert.ToString(greeks.Rho());
                            textBox16.Text = Convert.ToString(greeks.Theta());
                            textBox11.Text = Convert.ToString(greeks.ToleranceOfError());


                        }

                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is European call option with the Antithetic method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is European put option with the Antithetic method!";
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_European();
                            textBox12.Text = Convert.ToString(greeks.Delta());
                            textBox10.Text = Convert.ToString(greeks.Value());
                            textBox14.Text = Convert.ToString(greeks.Vega());
                            textBox13.Text = Convert.ToString(greeks.Gamma());
                            textBox15.Text = Convert.ToString(greeks.Rho());
                            textBox16.Text = Convert.ToString(greeks.Theta());
                            textBox11.Text = Convert.ToString(greeks.ToleranceOfError());
                        }
                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is European call option with the Antithetic and Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is European put option with the Antithetic and Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_European();
                            textBox12.Text = Convert.ToString(greeks.Delta());
                            textBox10.Text = Convert.ToString(greeks.Value());
                            textBox14.Text = Convert.ToString(greeks.Vega());
                            textBox13.Text = Convert.ToString(greeks.Gamma());
                            textBox15.Text = Convert.ToString(greeks.Rho());
                            textBox16.Text = Convert.ToString(greeks.Theta());
                            textBox11.Text = Convert.ToString(greeks.ToleranceOfError());
                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is European call option with  Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is European put option with  Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_European();
                            textBox12.Text = Convert.ToString(greeks.Delta());
                            textBox10.Text = Convert.ToString(greeks.Value());
                            textBox14.Text = Convert.ToString(greeks.Vega());
                            textBox13.Text = Convert.ToString(greeks.Gamma());
                            textBox15.Text = Convert.ToString(greeks.Rho());
                            textBox16.Text = Convert.ToString(greeks.Theta());
                            textBox11.Text = Convert.ToString(greeks.ToleranceOfError());
                        }

                    }
                }

                //Asian Option
                if (radioButton8.Checked == true)  //Calculate European Option price.
                {
                    OptionInfo optionInfo;
                    Thread_values TV;
                    int M = Convert.ToInt32(textBox7.Text),
                        steps = Convert.ToInt32(textBox6.Text);
                    double vol = Convert.ToDouble(textBox4.Text),
                        r = Convert.ToDouble(textBox3.Text),
                        S = Convert.ToDouble(textBox1.Text),
                        K = Convert.ToDouble(textBox2.Text),
                        t = Convert.ToDouble(textBox5.Text),
                        eps = Convert.ToDouble(textBox8.Text);
                    double barrier = 0.0;
                    int type = 0;
                    double rebate = 0;
                    bool pointer1;
                    if (Multi == true)
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;  //call option
                                textBox17.Text = "This is Asian call option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;//put option
                                textBox17.Text = "This is Asian put option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            //Calculate the values with multiple thread

                            TV = new Thread_values(optionInfo);
                            TV.Calculate_asian();
                            textBox12.Text = Convert.ToString(TV.Asian_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Asian_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Asian_VegaT);
                            textBox13.Text = Convert.ToString(TV.Asian_GammaT);
                            textBox15.Text = Convert.ToString(TV.Asian_RhoT);
                            textBox16.Text = Convert.ToString(TV.Asian_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Asian_TOET);
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Asian call option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Asian put option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_asian();
                            textBox12.Text = Convert.ToString(TV.Asian_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Asian_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Asian_VegaT);
                            textBox13.Text = Convert.ToString(TV.Asian_GammaT);
                            textBox15.Text = Convert.ToString(TV.Asian_RhoT);
                            textBox16.Text = Convert.ToString(TV.Asian_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Asian_TOET);
                        }

                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Asian call option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Asian put option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_asian();
                            textBox12.Text = Convert.ToString(TV.Asian_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Asian_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Asian_VegaT);
                            textBox13.Text = Convert.ToString(TV.Asian_GammaT);
                            textBox15.Text = Convert.ToString(TV.Asian_RhoT);
                            textBox16.Text = Convert.ToString(TV.Asian_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Asian_TOET);
                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Asian call option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Asian put option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_asian();
                            textBox12.Text = Convert.ToString(TV.Asian_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Asian_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Asian_VegaT);
                            textBox13.Text = Convert.ToString(TV.Asian_GammaT);
                            textBox15.Text = Convert.ToString(TV.Asian_RhoT);
                            textBox16.Text = Convert.ToString(TV.Asian_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Asian_TOET);
                        }

                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Asian call option!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Asian put option!";
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Asian();
                            textBox12.Text = Convert.ToString(greeks.Asian_Delta());
                            textBox10.Text = Convert.ToString(greeks.Asian_Value());
                            textBox14.Text = Convert.ToString(greeks.Asian_Vega());
                            textBox13.Text = Convert.ToString(greeks.Asian_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Asian_Rho());
                            textBox16.Text = Convert.ToString(greeks.Asian_Theta());
                            textBox11.Text = Convert.ToString(greeks.Asian_ToleranceOfError());


                        }

                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Asian call option with the Antithetic method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Asian put option with the Antithetic method!";
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Asian();
                            textBox12.Text = Convert.ToString(greeks.Asian_Delta());
                            textBox10.Text = Convert.ToString(greeks.Asian_Value());
                            textBox14.Text = Convert.ToString(greeks.Asian_Vega());
                            textBox13.Text = Convert.ToString(greeks.Asian_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Asian_Rho());
                            textBox16.Text = Convert.ToString(greeks.Asian_Theta());
                            textBox11.Text = Convert.ToString(greeks.Asian_ToleranceOfError());
                        }
                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Asian call option with the Antithetic and Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Asian put option with the Antithetic and Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Asian();
                            textBox12.Text = Convert.ToString(greeks.Asian_Delta());
                            textBox10.Text = Convert.ToString(greeks.Asian_Value());
                            textBox14.Text = Convert.ToString(greeks.Asian_Vega());
                            textBox13.Text = Convert.ToString(greeks.Asian_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Asian_Rho());
                            textBox16.Text = Convert.ToString(greeks.Asian_Theta());
                            textBox11.Text = Convert.ToString(greeks.Asian_ToleranceOfError());

                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Asian call option with  Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Asian put option with  Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Asian();
                            textBox12.Text = Convert.ToString(greeks.Asian_Delta());
                            textBox10.Text = Convert.ToString(greeks.Asian_Value());
                            textBox14.Text = Convert.ToString(greeks.Asian_Vega());
                            textBox13.Text = Convert.ToString(greeks.Asian_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Asian_Rho());
                            textBox16.Text = Convert.ToString(greeks.Asian_Theta());
                            textBox11.Text = Convert.ToString(greeks.Asian_ToleranceOfError());
                        }

                    }
                }

                //Digital Option
                if (radioButton9.Checked == true)  //Calculate European Option price.
                {
                    OptionInfo optionInfo;
                    Thread_values TV;
                    int M = Convert.ToInt32(textBox7.Text),
                        steps = Convert.ToInt32(textBox6.Text);
                    double vol = Convert.ToDouble(textBox4.Text),
                        r = Convert.ToDouble(textBox3.Text),
                        S = Convert.ToDouble(textBox1.Text),
                        K = Convert.ToDouble(textBox2.Text),
                        t = Convert.ToDouble(textBox5.Text),
                        eps = Convert.ToDouble(textBox8.Text);
                    double barrier = 0.0;
                    int type = 0;
                 double rebate = Convert.ToDouble(textBox18.Text);
                   

                    bool pointer1;
                    if (Multi == true)
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;  //call option
                                textBox17.Text = "This is Digital call option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;//put option
                                textBox17.Text = "This is Digital put option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            //Calculate the values with multiple thread
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_digital();
                           

                            textBox12.Text = Convert.ToString(TV.Digital_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Digital_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Digital_VegaT);
                            textBox13.Text = Convert.ToString(TV.Digital_GammaT);
                            textBox15.Text = Convert.ToString(TV.Digital_RhoT);
                            textBox16.Text = Convert.ToString(TV.Digital_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Digital_TOET);
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Digital call option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Digital put option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_digital();


                            textBox12.Text = Convert.ToString(TV.Digital_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Digital_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Digital_VegaT);
                            textBox13.Text = Convert.ToString(TV.Digital_GammaT);
                            textBox15.Text = Convert.ToString(TV.Digital_RhoT);
                            textBox16.Text = Convert.ToString(TV.Digital_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Digital_TOET);
                        }

                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Digital call option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Digital put option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_digital();


                            textBox12.Text = Convert.ToString(TV.Digital_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Digital_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Digital_VegaT);
                            textBox13.Text = Convert.ToString(TV.Digital_GammaT);
                            textBox15.Text = Convert.ToString(TV.Digital_RhoT);
                            textBox16.Text = Convert.ToString(TV.Digital_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Digital_TOET);
                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Digital call option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Digital put option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_digital();


                            textBox12.Text = Convert.ToString(TV.Digital_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Digital_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Digital_VegaT);
                            textBox13.Text = Convert.ToString(TV.Digital_GammaT);
                            textBox15.Text = Convert.ToString(TV.Digital_RhoT);
                            textBox16.Text = Convert.ToString(TV.Digital_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Digital_TOET);
                        }

                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Digital call option!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Digital put option!";
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Digital();
                      
                            
                            textBox12.Text = Convert.ToString(greeks.Digital_Delta());
                            textBox10.Text = Convert.ToString(greeks.Digital_Value());
                            textBox14.Text = Convert.ToString(greeks.Digital_Vega());
                            textBox13.Text = Convert.ToString(greeks.Digital_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Digital_Rho());
                            textBox16.Text = Convert.ToString(greeks.Digital_Theta());
                            textBox11.Text = Convert.ToString(greeks.Digital_ToleranceOfError());


                        }

                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Digital call option with the Antithetic method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Digital put option with the Antithetic method!";
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Digital();


                            textBox12.Text = Convert.ToString(greeks.Digital_Delta());
                            textBox10.Text = Convert.ToString(greeks.Digital_Value());
                            textBox14.Text = Convert.ToString(greeks.Digital_Vega());
                            textBox13.Text = Convert.ToString(greeks.Digital_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Digital_Rho());
                            textBox16.Text = Convert.ToString(greeks.Digital_Theta());
                            textBox11.Text = Convert.ToString(greeks.Digital_ToleranceOfError());

                        }
                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Digital call option with the Antithetic and Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Digital put option with the Antithetic and Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Digital();


                            textBox12.Text = Convert.ToString(greeks.Digital_Delta());
                            textBox10.Text = Convert.ToString(greeks.Digital_Value());
                            textBox14.Text = Convert.ToString(greeks.Digital_Vega());
                            textBox13.Text = Convert.ToString(greeks.Digital_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Digital_Rho());
                            textBox16.Text = Convert.ToString(greeks.Digital_Theta());
                            textBox11.Text = Convert.ToString(greeks.Digital_ToleranceOfError());


                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Digital call option with  Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Digital put option with  Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Digital();


                            textBox12.Text = Convert.ToString(greeks.Digital_Delta());
                            textBox10.Text = Convert.ToString(greeks.Digital_Value());
                            textBox14.Text = Convert.ToString(greeks.Digital_Vega());
                            textBox13.Text = Convert.ToString(greeks.Digital_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Digital_Rho());
                            textBox16.Text = Convert.ToString(greeks.Digital_Theta());
                            textBox11.Text = Convert.ToString(greeks.Digital_ToleranceOfError());

                        }

                    }
                }

                // Lookback Option
                if (radioButton11.Checked == true)  //Calculate European Option price.
                {
                    OptionInfo optionInfo;
                    Thread_values TV;
                    int M = Convert.ToInt32(textBox7.Text),
                        steps = Convert.ToInt32(textBox6.Text);
                    double vol = Convert.ToDouble(textBox4.Text),
                        r = Convert.ToDouble(textBox3.Text),
                        S = Convert.ToDouble(textBox1.Text),
                        K = Convert.ToDouble(textBox2.Text),
                        t = Convert.ToDouble(textBox5.Text),
                        eps = Convert.ToDouble(textBox8.Text);
                    double barrier = 0.0;
                    int type = 0;
                    double rebate = 0;
                    //double rebate = Convert.ToDouble(textBox18.Text);
                    bool pointer1;
                    if (Multi == true)
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;  //call option
                                textBox17.Text = "This is Lookback call option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;//put option
                                textBox17.Text = "This is Lookback put option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier, 1);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_lookback();

                            textBox12.Text = Convert.ToString(TV.Lookback_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Lookback_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Lookback_VegaT);
                            textBox13.Text = Convert.ToString(TV.Lookback_GammaT);
                            textBox15.Text = Convert.ToString(TV.Lookback_RhoT);
                            textBox16.Text = Convert.ToString(TV.Lookback_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Lookback_TOET);
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Lookback call option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Lookback put option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_lookback();

                            textBox12.Text = Convert.ToString(TV.Lookback_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Lookback_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Lookback_VegaT);
                            textBox13.Text = Convert.ToString(TV.Lookback_GammaT);
                            textBox15.Text = Convert.ToString(TV.Lookback_RhoT);
                            textBox16.Text = Convert.ToString(TV.Lookback_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Lookback_TOET);
                        }

                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Lookback call option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Lookback put option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_lookback();

                            textBox12.Text = Convert.ToString(TV.Lookback_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Lookback_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Lookback_VegaT);
                            textBox13.Text = Convert.ToString(TV.Lookback_GammaT);
                            textBox15.Text = Convert.ToString(TV.Lookback_RhoT);
                            textBox16.Text = Convert.ToString(TV.Lookback_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Lookback_TOET);

                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Lookback call option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Lookback put option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_lookback();

                            textBox12.Text = Convert.ToString(TV.Lookback_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Lookback_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Lookback_VegaT);
                            textBox13.Text = Convert.ToString(TV.Lookback_GammaT);
                            textBox15.Text = Convert.ToString(TV.Lookback_RhoT);
                            textBox16.Text = Convert.ToString(TV.Lookback_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Lookback_TOET);
                        }

                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Lookback call option!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Lookback put option!";
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Lookback();
                            textBox12.Text = Convert.ToString(greeks.Lookback_Delta());
                            textBox10.Text = Convert.ToString(greeks.Lookback_Value());
                            textBox14.Text = Convert.ToString(greeks.Lookback_Vega());
                            textBox13.Text = Convert.ToString(greeks.Lookback_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Lookback_Rho());
                            textBox16.Text = Convert.ToString(greeks.Lookback_Theta());
                            textBox11.Text = Convert.ToString(greeks.Lookback_ToleranceOfError());


                        }

                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Lookback call option with the Antithetic method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Lookback put option with the Antithetic method!";
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Lookback();
                            textBox12.Text = Convert.ToString(greeks.Lookback_Delta());
                            textBox10.Text = Convert.ToString(greeks.Lookback_Value());
                            textBox14.Text = Convert.ToString(greeks.Lookback_Vega());
                            textBox13.Text = Convert.ToString(greeks.Lookback_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Lookback_Rho());
                            textBox16.Text = Convert.ToString(greeks.Lookback_Theta());
                            textBox11.Text = Convert.ToString(greeks.Lookback_ToleranceOfError());
                        }
                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Lookback call option with the Antithetic and Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Lookback put option with the Antithetic and Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Lookback();
                            textBox12.Text = Convert.ToString(greeks.Lookback_Delta());
                            textBox10.Text = Convert.ToString(greeks.Lookback_Value());
                            textBox14.Text = Convert.ToString(greeks.Lookback_Vega());
                            textBox13.Text = Convert.ToString(greeks.Lookback_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Lookback_Rho());
                            textBox16.Text = Convert.ToString(greeks.Lookback_Theta());
                            textBox11.Text = Convert.ToString(greeks.Lookback_ToleranceOfError());

                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Lookback call option with  Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Lookback put option with  Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Lookback();
                            textBox12.Text = Convert.ToString(greeks.Lookback_Delta());
                            textBox10.Text = Convert.ToString(greeks.Lookback_Value());
                            textBox14.Text = Convert.ToString(greeks.Lookback_Vega());
                            textBox13.Text = Convert.ToString(greeks.Lookback_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Lookback_Rho());
                            textBox16.Text = Convert.ToString(greeks.Lookback_Theta());
                            textBox11.Text = Convert.ToString(greeks.Lookback_ToleranceOfError());
                        }

                    }
                }


                //Range Option
                if (radioButton12.Checked == true)  //Calculate European Option price.
                {
                    OptionInfo optionInfo;
                    Thread_values TV;
                    int M = Convert.ToInt32(textBox7.Text),
                        steps = Convert.ToInt32(textBox6.Text);
                    double vol = Convert.ToDouble(textBox4.Text),
                        r = Convert.ToDouble(textBox3.Text),
                        S = Convert.ToDouble(textBox1.Text),
                        K=0,
                        t = Convert.ToDouble(textBox5.Text),
                        eps = Convert.ToDouble(textBox8.Text);
                    double barrier = 0.0;
                    int type = 0;
                    double rebate = 0;
                    bool pointer1;
                    if (Multi == true)
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;  //call option
                                textBox17.Text = "This is Range call option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;//put option
                                textBox17.Text = "This is Range put option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            //Calculate the values with multiple thread

                            TV = new Thread_values(optionInfo);
                            TV.Calculate_range();

                            textBox12.Text = Convert.ToString(TV.Range_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Range_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Range_VegaT);
                            textBox13.Text = Convert.ToString(TV.Range_GammaT);
                            textBox15.Text = Convert.ToString(TV.Range_RhoT);
                            textBox16.Text = Convert.ToString(TV.Range_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Range_TOET);
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Range call option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Range put option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }


                           optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);

                           TV = new Thread_values(optionInfo);
                           TV.Calculate_range();

                           textBox12.Text = Convert.ToString(TV.Range_DeltaT);
                           textBox10.Text = Convert.ToString(TV.Range_finalPrice);
                           textBox14.Text = Convert.ToString(TV.Range_VegaT);
                           textBox13.Text = Convert.ToString(TV.Range_GammaT);
                           textBox15.Text = Convert.ToString(TV.Range_RhoT);
                           textBox16.Text = Convert.ToString(TV.Range_ThetaT);
                           textBox11.Text = Convert.ToString(TV.Range_TOET);
                        }

                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Range call option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Range put option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);

                            TV = new Thread_values(optionInfo);
                            TV.Calculate_range();

                            textBox12.Text = Convert.ToString(TV.Range_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Range_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Range_VegaT);
                            textBox13.Text = Convert.ToString(TV.Range_GammaT);
                            textBox15.Text = Convert.ToString(TV.Range_RhoT);
                            textBox16.Text = Convert.ToString(TV.Range_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Range_TOET);

                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Range call option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Range put option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);

                            TV = new Thread_values(optionInfo);
                            TV.Calculate_range();

                            textBox12.Text = Convert.ToString(TV.Range_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Range_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Range_VegaT);
                            textBox13.Text = Convert.ToString(TV.Range_GammaT);
                            textBox15.Text = Convert.ToString(TV.Range_RhoT);
                            textBox16.Text = Convert.ToString(TV.Range_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Range_TOET);
                        }

                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Range call option!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Range put option!";
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Range();
                            textBox12.Text = Convert.ToString(greeks.Range_Delta());
                            textBox10.Text = Convert.ToString(greeks.Range_Value());
                            textBox14.Text = Convert.ToString(greeks.Range_Vega());
                            textBox13.Text = Convert.ToString(greeks.Range_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Range_Rho());
                            textBox16.Text = Convert.ToString(greeks.Range_Theta());
                            textBox11.Text = Convert.ToString(greeks.Range_ToleranceOfError());


                        }

                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Range call option with the Antithetic method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Range put option with the Antithetic method!";
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Range();
                            textBox12.Text = Convert.ToString(greeks.Range_Delta());
                            textBox10.Text = Convert.ToString(greeks.Range_Value());
                            textBox14.Text = Convert.ToString(greeks.Range_Vega());
                            textBox13.Text = Convert.ToString(greeks.Range_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Range_Rho());
                            textBox16.Text = Convert.ToString(greeks.Range_Theta());
                            textBox11.Text = Convert.ToString(greeks.Range_ToleranceOfError());
                        }
                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Range call option with the Antithetic and Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Range put option with the Antithetic and Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Range();
                            textBox12.Text = Convert.ToString(greeks.Range_Delta());
                            textBox10.Text = Convert.ToString(greeks.Range_Value());
                            textBox14.Text = Convert.ToString(greeks.Range_Vega());
                            textBox13.Text = Convert.ToString(greeks.Range_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Range_Rho());
                            textBox16.Text = Convert.ToString(greeks.Range_Theta());
                            textBox11.Text = Convert.ToString(greeks.Range_ToleranceOfError());
                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Range call option with  Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Range put option with  Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Range();
                            textBox12.Text = Convert.ToString(greeks.Range_Delta());
                            textBox10.Text = Convert.ToString(greeks.Range_Value());
                            textBox14.Text = Convert.ToString(greeks.Range_Vega());
                            textBox13.Text = Convert.ToString(greeks.Range_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Range_Rho());
                            textBox16.Text = Convert.ToString(greeks.Range_Theta());
                            textBox11.Text = Convert.ToString(greeks.Range_ToleranceOfError());
                        }

                    }
                }

                //Barrier Option
                if (radioButton10.Checked == true)  //Calculate Barrier Option price.
                {
                   
                    OptionInfo optionInfo;
                    Thread_values TV;
                    int M = Convert.ToInt32(textBox7.Text),
                        steps = Convert.ToInt32(textBox6.Text);
                    double vol = Convert.ToDouble(textBox4.Text),
                        r = Convert.ToDouble(textBox3.Text),
                        S = Convert.ToDouble(textBox1.Text),
                        K = Convert.ToDouble(textBox2.Text),
                        t = Convert.ToDouble(textBox5.Text),
                        eps = Convert.ToDouble(textBox8.Text);
                    double barrier = Convert.ToDouble(textBox19.Text);
                   
                    int type = 0;
                    if (comboBox1.Text=="Down and out")
                    {
                        type = 1;
                    }
                    else if (comboBox1.Text=="Up and out")
                    {
                        type=2;
                    }
                    else if (comboBox1.Text=="Down and in")
                    {
                        type = 3;
                    }
                    else if (comboBox1.Text == "Up and in")
                    {
                        type = 4;
                    }
                    else 
                    {
                        type = 0;
                    }
                    double rebate = 0.0;
                    bool pointer1;
                   
                    if (Multi == true)
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;  //call option
                                textBox17.Text = "This is Barrier call option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;//put option
                                textBox17.Text = "This is Barrier put option!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            //Calculate the values with multiple thread
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_barrier();

                            textBox12.Text = Convert.ToString(TV.Barrier_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Barrier_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Barrier_VegaT);
                            textBox13.Text = Convert.ToString(TV.Barrier_GammaT);
                            textBox15.Text = Convert.ToString(TV.Barrier_RhoT);
                            textBox16.Text = Convert.ToString(TV.Barrier_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Barrier_TOET);
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Barrier call option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Barrier put option with the Antithetic method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_barrier();

                            textBox12.Text = Convert.ToString(TV.Barrier_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Barrier_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Barrier_VegaT);
                            textBox13.Text = Convert.ToString(TV.Barrier_GammaT);
                            textBox15.Text = Convert.ToString(TV.Barrier_RhoT);
                            textBox16.Text = Convert.ToString(TV.Barrier_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Barrier_TOET);
                        }

                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Barrier call option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Barrier put option with the Antithetic and Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_barrier();

                            textBox12.Text = Convert.ToString(TV.Barrier_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Barrier_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Barrier_VegaT);
                            textBox13.Text = Convert.ToString(TV.Barrier_GammaT);
                            textBox15.Text = Convert.ToString(TV.Barrier_RhoT);
                            textBox16.Text = Convert.ToString(TV.Barrier_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Barrier_TOET);

                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Barrier call option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Barrier put option with  Delta-based method!" + System.Environment.NewLine + "The number of the cores is:" + cores; ;
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            TV = new Thread_values(optionInfo);
                            TV.Calculate_barrier();

                            textBox12.Text = Convert.ToString(TV.Barrier_DeltaT);
                            textBox10.Text = Convert.ToString(TV.Barrier_finalPrice);
                            textBox14.Text = Convert.ToString(TV.Barrier_VegaT);
                            textBox13.Text = Convert.ToString(TV.Barrier_GammaT);
                            textBox15.Text = Convert.ToString(TV.Barrier_RhoT);
                            textBox16.Text = Convert.ToString(TV.Barrier_ThetaT);
                            textBox11.Text = Convert.ToString(TV.Barrier_TOET);
                        }

                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {

                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Barrier call option!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Barrier put option!";
                            }

                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,1);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Barrier();
                            textBox12.Text = Convert.ToString(greeks.Barrier_Delta());
                            textBox10.Text = Convert.ToString(greeks.Barrier_Value());
                            textBox14.Text = Convert.ToString(greeks.Barrier_Vega());
                            textBox13.Text = Convert.ToString(greeks.Barrier_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Barrier_Rho());
                            textBox16.Text = Convert.ToString(greeks.Barrier_Theta());
                            textBox11.Text = Convert.ToString(greeks.Barrier_ToleranceOfError());


                        }

                        if (radioButton3.Checked == true)
                        {
                            if (radioButton1.Checked) // option type
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Barrier call option with the Antithetic method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Barrier_ put option with the Antithetic method!";
                            }


                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,2);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Barrier();
                            textBox12.Text = Convert.ToString(greeks.Barrier_Delta());
                            textBox10.Text = Convert.ToString(greeks.Barrier_Value());
                            textBox14.Text = Convert.ToString(greeks.Barrier_Vega());
                            textBox13.Text = Convert.ToString(greeks.Barrier_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Barrier_Rho());
                            textBox16.Text = Convert.ToString(greeks.Barrier_Theta());
                            textBox11.Text = Convert.ToString(greeks.Barrier_ToleranceOfError());
                        }
                        if (radioButton5.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Barrier call option with the Antithetic and Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Barrier put option with the Antithetic and Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,3);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Barrier();
                            textBox12.Text = Convert.ToString(greeks.Barrier_Delta());
                            textBox10.Text = Convert.ToString(greeks.Barrier_Value());
                            textBox14.Text = Convert.ToString(greeks.Barrier_Vega());
                            textBox13.Text = Convert.ToString(greeks.Barrier_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Barrier_Rho());
                            textBox16.Text = Convert.ToString(greeks.Barrier_Theta());
                            textBox11.Text = Convert.ToString(greeks.Barrier_ToleranceOfError());

                        }
                        if (radioButton6.Checked == true)
                        {
                            if (radioButton1.Checked)
                            {
                                pointer1 = true;
                                textBox17.Text = "This is Barrier call option with  Delta-based method!";
                            }
                            else
                            {
                                pointer1 = false;
                                textBox17.Text = "This is Barrier put option with  Delta-based method!";
                            }
                            optionInfo = new OptionInfo(M, steps, vol, r, S, K, t, eps, pointer1, rebate, type, barrier,4);
                            Greeks greeks = new Greeks(optionInfo);
                            greeks.Calculate_Barrier();
                            textBox12.Text = Convert.ToString(greeks.Barrier_Delta());
                            textBox10.Text = Convert.ToString(greeks.Barrier_Value());
                            textBox14.Text = Convert.ToString(greeks.Barrier_Vega());
                            textBox13.Text = Convert.ToString(greeks.Barrier_Gamma());
                            textBox15.Text = Convert.ToString(greeks.Barrier_Rho());
                            textBox16.Text = Convert.ToString(greeks.Barrier_Theta());
                            textBox11.Text = Convert.ToString(greeks.Barrier_ToleranceOfError());
                        }

                    }
                }

            }
            else
            {
                MessageBox.Show("Please adjust your input!");
            }
            
            run_time.Stop();

            TimeSpan time = run_time.Elapsed;
            textBox9.Text = Convert.ToString((decimal)time.TotalSeconds+"s");

            }

        
    }      
  }

        



     

     
     
     