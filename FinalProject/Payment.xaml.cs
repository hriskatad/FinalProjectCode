using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Hris\FinalProject\FinalProject\Database1.mdf;Integrated Security = True");

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string paymentquery = "Insert into [Purchase Information] ([Holder Name], Address, [Card Number], [Expiration Date]) values ('"+this.HolderName.Text+"','"+this.Address1.Text+"','"+this.CardNumber.Text+"','"+this.ExpirationDate.Text+"')";
                SqlCommand paymentcommand = new SqlCommand(paymentquery, sqlcon);
                paymentcommand.ExecuteNonQuery();
                MessageBox.Show("Purchase successful");
                CharacterKollection a = new CharacterKollection();
                a.Show();
                this.Close();
            }
            catch (Exception exA)
            {
                MessageBox.Show(exA.Message);

            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}
