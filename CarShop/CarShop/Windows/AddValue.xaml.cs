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
using System.Windows.Shapes;

namespace CarShop
{
    /// <summary>
    /// Логика взаимодействия для AddValue.xaml
    /// </summary>
    public partial class AddValue : Window
    {
        public AddValue()
        {
            InitializeComponent();
        }
        public AddValue(bool unit):this()
        {
            brandField.Visibility = Visibility.Hidden;
                unitField.Visibility = Visibility.Visible;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (brandField.Visibility == Visibility.Hidden)
                {
                    if (nameUnit.Text != "")
                    {
                        MainWindow.carShopEntities.Units.Add(new Unit { Name = nameUnit.Text });
                        this.DialogResult = true;
                        MainWindow.carShopEntities.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля");
                    }
                }
                else
                {
                    if (nameBrand.Text != "")
                    {
                        MainWindow.carShopEntities.Brands.Add(new Brand { Name = nameBrand.Text });
                        this.DialogResult = true;
                        MainWindow.carShopEntities.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля");
                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
