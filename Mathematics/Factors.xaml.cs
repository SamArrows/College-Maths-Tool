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
    public partial class Factors : ContentPage
    {
        ObservableCollection<string> factors = new ObservableCollection<string>();
        void BtnReset_Clicked(object sender, EventArgs e)
        {
            txtNum.Text = "";
            factors.Clear();
            lvFactors.ItemsSource = factors;
        }
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        async void BtnFindFact_Clicked(object sender, EventArgs e)
        {
            factors.Clear();
            lvFactors.ItemsSource = factors;
            if (txtNum.Text != "")
            {
                double number = Convert.ToDouble(txtNum.Text);
                if(number % 1 != 0)
                {
                    await DisplayAlert("Error", "Please enter an integer", "OK");
                }
                else
                {
                    long num = Convert.ToInt64(number);
                    if (!(number <= 0))
                    {
                        if (number == 1)
                        {
                            factors.Add("1");
                        }
                        else if (number == 2)
                        {
                            factors.Add("1");
                            factors.Add("2");
                        }
                        else
                        {
                            for (int i = 1; i < (number + 1) / 2; i++)
                            {
                                if (num % i == 0)
                                {
                                    factors.Add(i.ToString());
                                }
                            }
                            factors.Add(num.ToString());
                        }
                        lvFactors.ItemsSource = factors;
                        await DisplayAlert("Solved!", "The factors of the number have been successfully calculated!", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", "The number must be an integer greater than 0", "OK");
                    }
                } 
            }
            else
            {
                await DisplayAlert("Error", "Please enter an integer", "OK");
            }
        }
        public Factors()
        {
            InitializeComponent();
        }
    }
}