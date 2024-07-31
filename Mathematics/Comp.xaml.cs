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
    public partial class Comp : ContentPage
    {
        public Comp()
        {
            InitializeComponent();
        }
        private void BtnDecToBin_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnBinToDec_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnHexToBin_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnBinToHex_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnDecToHex_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnConvert_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnHexToDec_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}