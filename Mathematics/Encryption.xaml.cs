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
    public partial class Encryption : ContentPage
    {
        public string DenToBin(int den)
        {
            int i;
            string bin = "";
            for (i = 0; den > 0; i++)
            {
                bin += Convert.ToString(den % 2);
                den /= 2;
            }
            string returnString = "";
            for (i = i - 1; i >= 0; i--)
            {
                returnString += bin[i];
            }
            return returnString;
        }
        public Encryption()
        {
            InitializeComponent();
        }
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnCaesar_Clicked(object sender, EventArgs e)
        {
            string text = txtMsg.Text;
            string keyString = txtKey.Text;
            int key;
            if (!(text == "" || keyString == ""))
            {
                key = Int32.Parse(keyString);
                string finalSolution = Caesar(text, key);
                Calculation output = new Calculation()
                {
                    Result = finalSolution,
                    Inputs = "Plaintext: " + text + "\nKey: " + keyString + " --> Caesar Cipher"
                };
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Calculation>();
                    conn.Insert(output);
                }
                lblCiphertext.Text = finalSolution;
            }
        }
        /*
        private async void BtnVernam_Clicked(object sender, EventArgs e)
        {
            string text = txtMsg.Text;
            string keyString = "";//txtVernamKey.Text;
            if (!(text == "" || keyString == ""))
            {
                for (int i = 0; i < keyString.Length; i++)
                {
                    if (keyString.Length < text.Length)
                    {
                        keyString += keyString[i];
                    }
                }
                //txtVernamKey.Text = keyString;
                lblCiphertext.Text = Vernam(text, keyString);
            }
            else
            {
                await DisplayAlert("Alert", "Cannot encrypt using the Vernam cipher. Make sure the Vernam cipher key is filled in and is equal in length to the message you want to encrypt.", "OK");
            }
        }
        string Vernam(string message, string key)
        {
            List<string> textlist = new List<string>();
            List<string> keylist = new List<string>();
            List<byte> msg = new List<byte>();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(message);
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            foreach (byte letter in asciiBytes)
            {
                string val = DenToBin(letter);
                string valToAdd = "";
                if (val.Length < 7)
                {
                    valToAdd = "0" + val;
                }
                else
                {
                    valToAdd = val;
                }
                textlist.Add(valToAdd);
            }
            foreach (byte letter in keyBytes)
            {
                string val = DenToBin(letter);
                string valToAdd = "";
                if (val.Length < 7)
                {
                    valToAdd = "0" + val;
                }
                else
                {
                    valToAdd = val;
                }
                keylist.Add(valToAdd);
            }
            for (int x = 0; x < 8; x++)
            {
                string encryptedByte = "";
                for (int i = 0; i < 8; i++)
                {

                }
            }
            //NON ASCII CHARACTERS NEED TO BE TAKEN INTO ACCOUNT
            //Perform XOR on each bit of each byte in asciiBytes and its corresponding bit of each byte in keyBytes
            //Convert the string of bits into their denary value (ascii code)
            //Convert this denary value back into text
            //Create the ciphertext from the formed characters
            //Return the ciphertext
            return "";
        }*/
        string Caesar(string message, int encryptionKey)
        {
            #region Debug Key
            if (encryptionKey >= 26)
            {
                encryptionKey %= 26;
            }
            if (encryptionKey <= -26)
            {
                encryptionKey %= -26;
            }
            #endregion
            string ciphertext = "";
            message = message.ToUpper();
            char[] letters = message.ToCharArray();
            for (int x = 0; x < letters.Length; x++)
            {
                int AsciiLET = (int)letters[x];
                if (!(AsciiLET < 65 || AsciiLET > 90))
                {
                    AsciiLET += encryptionKey;
                    if (AsciiLET < 65)
                    {
                        AsciiLET += 26;
                    }
                    else if (AsciiLET > 90)
                    {
                        AsciiLET -= 26;
                    }
                    char Asciiletter = (char)AsciiLET;
                    ciphertext += Asciiletter;
                }
            }
            return ciphertext;
        }
        void BtnReset_Clicked(object sender, EventArgs e)
        {
            txtKey.Text = txtMsg.Text = lblCiphertext.Text = "";
        }
    }
}