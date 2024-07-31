using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathematics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Fibonacci : ContentPage
    {
        ObservableCollection<string> sequence = new ObservableCollection<string>();
        double a;
        double b;
        long errorCatch;
        public Fibonacci()
        {
            InitializeComponent();
        }

        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        async void BtnCalcFib_Clicked(object sender, EventArgs e)
        {
            a = b = errorCatch = 0;
            sequence.Clear();
            lvSequence.ItemsSource = sequence;
            bool? numbers = null;
            if(!Double.TryParse(txtFirstNum.Text, out a) || !Double.TryParse(txtSecondNum.Text, out b))
            {
                numbers = false;
            }
            else
            {
                a = Convert.ToDouble(txtFirstNum.Text);
                b = Convert.ToDouble(txtSecondNum.Text);
                if(a == 0 && b == 0)
                {
                    numbers = false;
                }
                else
                {
                    numbers = true;
                }
            }
            if(numbers == true)
            {
                errorCatch = Convert.ToInt64(Math.Abs(a)) + Convert.ToInt64(Math.Abs(b));
                string item = "";
                for (int i = 1; errorCatch < 2147483647 ; i++)
                {
                    item = i.ToString() + " : ";
                    if (i % 2 == 0)
                    {
                        item += b.ToString();
                        a += b;
                    }
                    else
                    {
                        item += a.ToString();
                        b += a;
                    }
                    sequence.Add(item);
                    errorCatch = Convert.ToInt64(Math.Abs(a)) + Convert.ToInt64(Math.Abs(b));
                }
                lvSequence.ItemsSource = sequence;
                await DisplayAlert("Sequence Generation Successful", "Scroll through the list below to view the sequence", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Ensure both input boxes contain numbers (with at least one of them inequal to 0)", "OK");
            }
        }

        void BtnReset_Clicked(object sender, EventArgs e)
        {
            txtFirstNum.Text = txtSecondNum.Text = "";
            a = b = errorCatch = 0;
            sequence.Clear();
            lvSequence.ItemsSource = sequence;
        }
    }
}