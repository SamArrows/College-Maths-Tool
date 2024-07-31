using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathematics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BinTheorem : ContentPage
    {
        int a;
        int b;
        int c;
        ObservableCollection<string> sequence = new ObservableCollection<string>();
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        void BtnReset_Clicked(object sender, EventArgs e)
        {
            txtA.Text = txtB.Text = txtC.Text = "";
            sequence.Clear();
            lvSequence.ItemsSource = sequence;
        }
        public BinTheorem()
        {
            InitializeComponent();
        }
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
        int NCR(int N, int R) 
        { 
            return Factorial(N) / (Factorial(R) * Factorial(N - R)); 
        }
        int Factorial(int value) 
        { 
            if (value == 0) 
            { 
                return 1; 
            } 
            else 
            { 
                return value * Factorial(value - 1); 
            } 
        }
        async void BtnExpandBinomial_Clicked(object sender, EventArgs e)
        {
            sequence.Clear();
            lvSequence.ItemsSource = sequence;
            if (ValidateInteger(txtA.Text) == 100000000 || ValidateInteger(txtB.Text) == 100000000 || ValidateInteger(txtC.Text) == 100000000)
            {
                await DisplayAlert("Alert", "Ensure all input boxes contain integers", "OK");
            }
            else
            {
                a = Convert.ToInt32(txtA.Text);
                b = Convert.ToInt32(txtB.Text);
                c = Convert.ToInt32(txtC.Text);
                #region Expand Binomial
                for (int i = 0; i < c + 1; i++)
                {
                    string xTerm;

                    if (i == c - 1) 
                    { 
                        xTerm = "x"; 
                    } 
                    else 
                    { 
                        if (i == c) 
                        { 
                            xTerm = ""; 
                        } 
                        else 
                        { 
                            xTerm = "x^" + Convert.ToString(c - i); 
                        } 
                    }
                    sequence.Add(Convert.ToString(NCR(c, i) * Math.Pow(a, c - i) * Math.Pow(b, i)) + xTerm);
                }
                #endregion
                lvSequence.ItemsSource = sequence;
                await DisplayAlert("Solved!", "Each term in the expansion is shown below", "OK");
            }
        }
    }
}