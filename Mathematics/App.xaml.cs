using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathematics
{
    public partial class App : Application
    {
        public static string FilePath;
        public App(string filePath)
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new Login());

            FilePath = filePath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
