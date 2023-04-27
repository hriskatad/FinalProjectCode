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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignUp:Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Hris\FinalProject\FinalProject\Database1.mdf;Integrated Security = True");

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string signupquery = "Insert into [Account Information] (Username, Email, Password) values ('"+this.Username1.Text+"','"+this.Email.Text+"','"+this.Password.Password+"')";
                SqlCommand signupcommand = new SqlCommand(signupquery, sqlcon);
                signupcommand.ExecuteNonQuery();
                MessageBox.Show("Sign up successful");
                LogIn a = new LogIn();
                a.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}
