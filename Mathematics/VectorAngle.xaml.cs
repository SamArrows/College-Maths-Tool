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
    public partial class VectorAngle : ContentPage
    {
        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            txtVector1.Text = txtVector2.Text = lblResult.Text = "";
        }
        public VectorAngle()
        {
            InitializeComponent();
        }
        public List<double> GetVectorFromString(string text)
        {
            string[] vectorString = text.Split(',');
            List<double> vector = new List<double>();
            foreach (string val in vectorString)
            {
                double x;
                if (Double.TryParse(val, out x))
                {
                    vector.Add(x);
                }
            }
            return vector;
        }
        public double CalcVecAng(List<double> vectorU, List<double> vectorV)
        {
            //Multiply the vectors
            double UxV = DotProduct(vectorU, vectorV);
            double magU = Math.Sqrt(DotProduct(vectorU, vectorU));
            double magV = Math.Sqrt(DotProduct(vectorV, vectorV));
            double angle = Math.Acos(UxV / (magU * magV) * (Math.PI/180));
            return angle;
        }
        public double DotProduct(List<double> vectorU, List<double> vectorV)
        {
            double dotProduct = 0;
            for (int i = 0; i < vectorU.Count; i++)
            {
                dotProduct += vectorU[i] * vectorV[i];
            }
            return dotProduct;
        }
        private void BtnDotProduct_Clicked(object sender, EventArgs e)
        {
            if (txtVector1.Text == "" || txtVector2.Text == "")
            {
                lblResult.Text = "Please enter two vectors with the same number of values.";
            }
            else
            {
                List<double> vector1 = GetVectorFromString(txtVector1.Text);
                List<double> vector2 = GetVectorFromString(txtVector1.Text);
                if (vector1.Count != vector2.Count)
                {
                    lblResult.Text = "The vectors interpreted from your entries are not of equal size. Make sure you enter numbers separated by commas.";
                }
                else
                {
                    string finalSolution = "Dot product of the two vectors = " + Convert.ToString(DotProduct(vector1, vector2));
                    Calculation output = new Calculation()
                    {
                        Result = finalSolution,
                        Inputs = "First Vector: " + txtVector1.Text + "\nSecond Vector: " + txtVector2.Text + " --> Vector Dot Product"
                    };
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Calculation>();
                        conn.Insert(output);
                    }
                    lblResult.Text = finalSolution;
                }
            }
        }
        private void BtnFindVectorAngle_Clicked(object sender, EventArgs e)
        {
            if(txtVector1.Text == "" || txtVector2.Text == "")
            {
                lblResult.Text = "Please enter two vectors with the same number of values.";
            }
            else
            {
                List<double> vector1 = GetVectorFromString(txtVector1.Text);
                List<double> vector2 = GetVectorFromString(txtVector1.Text);
                if(vector1.Count != vector2.Count)
                {
                    lblResult.Text = "The vectors interpreted from your entries are not of equal size. Make sure you enter numbers separated by commas.";
                }
                else
                {
                    string finalSolution = "Angle Size = " + Convert.ToString(CalcVecAng(vector1, vector2)) + "degrees";
                    Calculation output = new Calculation()
                    {
                        Result = finalSolution,
                        Inputs = "First Vector: " + txtVector1.Text + "\nSecond Vector: " + txtVector2.Text + " --> Vector Angle"
                    };
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Calculation>();
                        conn.Insert(output);
                    }
                    lblResult.Text = finalSolution;
                }
            }
        }
    }
}