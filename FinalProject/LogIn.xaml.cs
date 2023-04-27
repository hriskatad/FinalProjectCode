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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Hris\FinalProject\FinalProject\Database1.mdf;Integrated Security = True");

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                string loginquery = "SELECT COUNT(1) FROM [Account Information] where Username=@Username and Password=@Password";
                SqlCommand logincommand = new SqlCommand(loginquery, sqlcon);
                logincommand.CommandType = CommandType.Text;
                logincommand.Parameters.AddWithValue("@Username", Username2.Text);
                logincommand.Parameters.AddWithValue("@Password", LogInPassword.Password);

                int count = Convert.ToInt32(logincommand.ExecuteScalar());
                if (count == 1)
                {
                    MessageBox.Show("Login successful");
                    CreateCharacter b = new CreateCharacter();
                    b.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect login details");
                }
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
