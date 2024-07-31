using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathematics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Quadratics : ContentPage
    {
        double a;
        double b;
        double c;

        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        void BtnReset_Clicked(object sender, EventArgs e)
        {
            txtA.Text = txtB.Text = txtC.Text = lblResult.Text = "";
        }
        public Quadratics()
        {
            InitializeComponent();
        }

        async void BtnSolveQuad_Clicked(object sender, EventArgs e)
        {
            if (!Double.TryParse(txtA.Text, out a) || !Double.TryParse(txtB.Text, out b) || !Double.TryParse(txtC.Text, out c))
            {
                await DisplayAlert("Alert", "Ensure all input boxes contain numbers", "OK");
            }
            else
            {
                a = Convert.ToDouble(txtA.Text);
                b = Convert.ToDouble(txtB.Text);
                c = Convert.ToDouble(txtC.Text);
                if (a == 0)
                {
                    await DisplayAlert("Alert", "You haven't entered a quadratic equation.", "OK");
                }
                else
                {
                    double root;
                    string solution1;
                    string solution2;
                    if (!((b * b) - (4 * a * c) < 0))
                    {
                        root = Math.Sqrt((b * b) - (4 * a * c));
                        solution1 = ((-b + root) / (2 * a)).ToString();
                        solution2 = ((-b - root) / (2 * a)).ToString();
                    }
                    else
                    {
                        root = Math.Sqrt(Math.Abs((b * b) - (4 * a * c)));
                        solution1 = ((-b) / 2).ToString() + " + " + (root / 2).ToString() + "i";
                        solution2 = ((-b) / 2).ToString() + " - " + (root / 2).ToString() + "i";
                    }
                    string finalSolution = "x = " + solution1 + ", \nx = " + solution2;
                    lblResult.Text = finalSolution;
                    Calculation output = new Calculation()
                    {
                        Result = finalSolution,
                        Inputs = "A: " + Convert.ToString(a) + "\nB: " + Convert.ToString(b) + "\nC: " + Convert.ToString(c) + " --> Quadratic Equation"
                    };
                    using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Calculation>();
                        conn.Insert(output);
                    }
                    await DisplayAlert("Solved!", "Values for x are below", "OK");
                }
            }
        }
    }
}