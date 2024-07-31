using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathematics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        SQLiteConnection conn = new SQLiteConnection(App.FilePath);
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Clicked(object sender, EventArgs e)
        {
            
        }
        private void BtnNewAcc_Clicked(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 4 || txtPass.Text.Length < 8)
            {
                lblStatus.Text = "Please make sure your username is longer than 3 characters and password is longer than 7";
            }
            else
            {
                conn.Open();
                #region Check that no users with the picked username exist
                string stm = "SELECT * FROM tblUsers WHERE Username = " + txtUser.Text;
                var cmd = new SQLiteCommand(stm, conn);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                int duplicates = 0;
                while (rdr.Read())
                {
                    if (rdr.GetString(1).Contains(txtUser.Text))
                    {
                        duplicates++;
                    }
                }
                lblStatus.Text = Convert.ToString(duplicates);
                #endregion

                //var cmd = new SQLiteCommand(conn);
                cmd.CommandText = "INSERT INTO tblUsers(UserID, Username, Password, DateOfBirth) VALUES(@UserID, @Username, @Password, @DateOfBirth)";
            }


        }
    }
}