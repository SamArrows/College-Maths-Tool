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
    public partial class Memory : ContentPage
    {
        public Memory()
        {
            InitializeComponent();
        }
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        /*private async void BtnClear_Clicked(object sender, EventArgs e)
        {
            string clear = await DisplayPromptAsync("Erase data?", "Are you sure you want to clear the memory?", "OK", "Cancel");
            if(clear == "OK")
            {
                //code to delete contents of the table
            }
        }*/
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Calculation>();
                var calculations = conn.Table<Calculation>().ToList();
                lvMemory.ItemsSource = calculations;
            }
        }
    }
}