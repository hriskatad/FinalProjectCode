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
    /// Interaction logic for EquipCharacter.xaml
    /// </summary>
    public partial class EquipCharacter : Window
    {
        public string[] Equipment1 {get; set;}
        public EquipCharacter()
        {
            InitializeComponent();
            Equipment1 = new string[] {"Wrath Hammer", "Shirai Ryu Kunai", "Ice Daggers", "Caro Guidance","Shao Kahn Helmet"};
            DataContext = this;
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Hris\FinalProject\FinalProject\Database1.mdf;Integrated Security = True");
        private void UpdateCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string updatequery = "update [Character Kollection] set Equipment=' "+this.Equipment.SelectedItem+" 'where Name='"+this.Name2.Text+"'";
                SqlCommand updatecommand = new SqlCommand(updatequery, sqlcon);
                updatecommand.ExecuteNonQuery();
                MessageBox.Show("Character successfully equipped");
                Payment f = new Payment();
                f.Show();
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
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string equipmentquery = "Select * from [Equipment Information]";
                SqlCommand loadequipment = new SqlCommand(equipmentquery, sqlcon);
                loadequipment.ExecuteNonQuery();
                SqlDataAdapter adapterLoad = new SqlDataAdapter(loadequipment);
                DataTable dtLoad = new DataTable();
                adapterLoad.Fill(dtLoad);
                EquipmentInformation.ItemsSource = dtLoad.DefaultView;
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
    }
}
