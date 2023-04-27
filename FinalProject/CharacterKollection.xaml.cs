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
    /// Interaction logic for CharacterKollection.xaml
    /// </summary>
    public partial class CharacterKollection : Window
    {
        public CharacterKollection()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Hris\FinalProject\FinalProject\Database1.mdf;Integrated Security = True");
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string kollectionquery = "Select * from [Character Kollection]";
                SqlCommand loadkollection = new SqlCommand(kollectionquery, sqlcon);
                loadkollection.ExecuteNonQuery();
                SqlDataAdapter adapterLoad = new SqlDataAdapter(loadkollection);
                DataTable dtLoad = new DataTable();
                adapterLoad.Fill(dtLoad);
                Kollection.ItemsSource = dtLoad.DefaultView;
                adapterLoad.Update(dtLoad);
                MessageBox.Show("Succesfully loaded");
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
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string deletequery = "delete from [Character Kollection] where Name='"+this.Name1.Text+"'";
                SqlCommand deletecommand = new SqlCommand(deletequery, sqlcon);
                deletecommand.ExecuteNonQuery();
                MessageBox.Show("Character Deleted");
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
