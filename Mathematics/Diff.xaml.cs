using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Mathematics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Diff : ContentPage
    {
        double a;
        double n;
        int o;
        double x;
        bool usesX = false;
        int ValidateInteger(string intToValidate)
        {
            try
            {
                return Convert.ToInt32(intToValidate);
            }
            catch
            {
                return 100000000;
            }
        }
        string Differentiate(double a, double n, int o, double x)
        {
            while (o > 0)
            {
                a *= n;
                n -= 1;
                o -= 1;
            }
            string output;
            if(n == 0)
            {
                output = "0";
            }
            else if (n == 1)
            {
                output = Convert.ToString(a);
            }
            else
            {
                if(a == 0)
                {
                    output = "0";
                }
                else
                {
                    output = Convert.ToString(a) + "x^" + Convert.ToString(n);
                }
            }
            if(x != 18092003)
            {
                usesX = true;
                output += ",\n Rate of change = " + Convert.ToString(a * Math.Pow(x, n));
            }
            else
            {
                usesX = false;
            }
            return output;
        }
        string Integrate(double a, double n, double x)
        {
            n += 1;
            a /= n;       
            string output;
            if (n == 1)
            {
                output = Convert.ToString(a) + "x + C";
            }
            else
            {
                if (a == 0)
                {
                    output = "0 + C";
                }
                else
                {
                    output = Convert.ToString(a) + "x^(" + Convert.ToString(n) + ") + C";
                }
            }
            if (x != 18092003)
            {
                usesX = true;
                output += ",\n x = " + Convert.ToString(a * Math.Pow(x, n));
            }
            else
            {
                usesX = false;
            }
            return output;
        }
        public Diff()
        {
            InitializeComponent();
        }
        async void BtnIntegrate_Clicked(object sender, EventArgs e)
        {
            if (!Double.TryParse(txtA.Text, out a) || !Double.TryParse(txtN.Text, out n))
            {
                await DisplayAlert("Alert", "Ensure all input boxes contain numbers", "OK");
            }
            else
            {
                a = Convert.ToDouble(txtA.Text);
                n = Convert.ToDouble(txtN.Text);
                if (txtX.Text != "" && Double.TryParse(txtX.Text, out x))
                {
                    x = Convert.ToDouble(txtX.Text);
                }
                else
                {
                    x = 18092003;
                }
                if(n == -1)
                {
                    await DisplayAlert("Alert", "Integration where n = -1 is not supported yet", "OK");
                }
                else
                {
                    string finalSolution = Integrate(a, n, x);
                    string inputs;
                    if (usesX == true)
                    {
                        inputs = "A: " + txtA.Text + "\nN: " + txtN.Text + "\nX: " + txtX.Text + " --> Integrate and Solve X";
                    }
                    else
                    {
                        inputs = "A: " + txtA.Text + "\nN: " + txtN.Text + " --> Find Integral";
                    }
                    Calculation output = new Calculation()
                    {
                        Result = finalSolution,
                        Inputs = inputs
                    };
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Calculation>();
                        conn.Insert(output);
                    }
                    lblResult.Text = finalSolution;
                }
            }
        }
        async void BtnDiff_Clicked(object sender, EventArgs e)
        {
            if (!Double.TryParse(txtA.Text, out a) || !Double.TryParse(txtN.Text, out n) || ValidateInteger(txtO.Text) == 100000000)
            {
                await DisplayAlert("Alert", "Ensure all input boxes contain numbers", "OK");
            }
            else
            {
                a = Convert.ToDouble(txtA.Text);
                n = Convert.ToDouble(txtN.Text);
                o = Convert.ToInt32(txtO.Text);
                if(txtX.Text != "" && Double.TryParse(txtX.Text, out x))
                {
                    x = Convert.ToDouble(txtX.Text);
                }
                else
                {
                    x = 18092003;
                }
                string inputs;
                string finalSolution = Differentiate(a, n, o, x);
                if (usesX == true)
                {
                    inputs = "A: " + txtA.Text + "\nN: " + txtN.Text + "\nO: " + txtO.Text + "\nX: " + txtX.Text + " --> Differentiate and Solve X";
                }
                else
                {
                    inputs = "A: " + txtA.Text + "\nN: " + txtN.Text + "\nO: " + txtO.Text + " --> Find Differential";
                }
                Calculation output = new Calculation()
                {
                    Result = finalSolution,
                    Inputs = inputs
                };
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Calculation>();
                    conn.Insert(output);
                }
                lblResult.Text = finalSolution;
            }
        }
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        void BtnReset_Clicked(object sender, EventArgs e)
        {
            txtA.Text = txtN.Text = txtO.Text = txtX.Text = lblResult.Text = "";
        }
    }
}