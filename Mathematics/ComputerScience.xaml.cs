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
    public partial class ComputerScience : ContentPage
    {
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        public ComputerScience()
        {
            InitializeComponent();
        }
        void BtnLoadCipher_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Encryption());
        }
        void BtnLoadVectorAngle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VectorAngle());
        }
    }
}