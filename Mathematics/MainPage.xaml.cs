using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mathematics
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void BtnLoadFib_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Fibonacci());
        }
        void BtnLoadQuad_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Quadratics());
        }
        void BtnLoadQuizSettings_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new QuizSettings());
        }
        void BtnLoadDiff_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Diff());
        }
        void BtnLoadMem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Memory());
        }
        void BtnLoadAng_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Angles());
        }
        void BtnLoadPascal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BinTheorem());
        }
        void BtnLoadComp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Comp());
        }
        void BtnLoadCompMenu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ComputerScience());
        }
        void BtnLoadFact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Factors());
        }
    }
}
