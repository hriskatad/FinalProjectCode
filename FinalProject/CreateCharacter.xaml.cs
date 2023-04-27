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
    /// Interaction logic for CreateCharacter.xaml
    /// </summary>
    public partial class CreateCharacter : Window
    {
        public string[] Tier1 {get; set;}
        public string[] Class1 {get; set;}
        public CreateCharacter()
        {
            InitializeComponent();
            Tier1 = new string[] {"Bronze", "Silver", "Gold","Diamond"};
            DataContext = this;
            Class1 = new string[] {"Spec Ops", "Martial Artist", "Outworld","Netherrealm","Elder God"};
            DataContext = this;
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Hris\FinalProject\FinalProject\Database1.mdf;Integrated Security = True");
        private void AddCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string addquery = "Insert into [Character Kollection] (Name, Variation, Tier, Class) values ('"+this.Name.Text+"','"+this.Variation.Text+"','"+this.Tier.SelectedItem+"','"+this.Class.SelectedItem+"')";
                SqlCommand addcommand = new SqlCommand(addquery, sqlcon);
                addcommand.ExecuteNonQuery();
                MessageBox.Show("Character created successfully");
                EquipCharacter d = new EquipCharacter();
                d.Show();
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
        private void Load1_Click(object sender, RoutedEventArgs e)
        {
            CharacterKollection a = new CharacterKollection();
            a.Show();
            this.Close();
        }
    }
}
