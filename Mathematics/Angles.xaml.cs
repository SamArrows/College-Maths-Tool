using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathematics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Angles : ContentPage
    {
        bool? angType;
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        void Reset()
        {
            txtSides.Text = lblResult.Text = "";
            angType = null;
            txtState.Text = "Type of Angle:";
            txtState.TextColor = Color.Black;
        }

        void BtnINT_Clicked(object sender, EventArgs e)
        {
            angType = true;
            txtState.Text = "Interior";
            txtState.TextColor = Color.FromHex("#66aabb");
        }

        void BtnEXT_Clicked(object sender, EventArgs e)
        {
            angType = false;
            txtState.Text = "Exterior";
            txtState.TextColor = Color.FromHex("#ee44ff");
        }

        void BtnReset_Clicked(object sender, EventArgs e)
        {
            Reset();
        }

        async void BtnFindAng_Clicked(object sender, EventArgs e)
        {
            if(angType == null || txtSides.Text == "")
            {
                await DisplayAlert("Lack of input", "Ensure all inputs are filled in", "OK");
            }
            else
            {
                double number = Convert.ToDouble(txtSides.Text);
                if (number % 1 == 0 && !(number < 3))
                {
                    if (angType == true)
                    {
                        lblResult.Text = "Each interior angle is\n" + (180 - (360 / number)).ToString() + "\ndegrees.";
                    }
                    else
                    {
                        lblResult.Text = "Each exterior angle is\n" + (360 / number).ToString() + "\ndegrees.";
                    }
                    await DisplayAlert("Solved!", "Solutions found!", "OK");
                }
                else
                {
                    await DisplayAlert("Invalid input", "The number of sides to a regular 2D polygon must be greater than 2.", "OK");
                }
            }
        } 
        public Angles()
        {
            InitializeComponent();
            Reset();
        }
    }
}