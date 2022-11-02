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

namespace CarShop
{
    /// <summary>
    /// Логика взаимодействия для ListProductAdminView.xaml
    /// </summary>
    public partial class ListProductAdminView : Page
    {
        public ListProductAdminView()
        {
            try
            {
                InitializeComponent();
                categoryComboBox.ItemsSource = MainWindow.carShopEntities.Categories.ToList();
                GoodsList.ItemsSource = MainWindow.carShopEntities.Goods.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ListProductAdminView(bool info) : this()
        {
            try
            {
                ListOrders.ItemsSource = MainWindow.carShopEntities.Sales.OrderByDescending(x => x.Date).ToList();
                ListSaleAdmin.Visibility = Visibility.Visible;
                ListProductAdmin.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GoodsList.ItemsSource = MainWindow.carShopEntities.Goods.Where(x => x.IsActive == true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void categoryComboBoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((Category)categoryComboBox.SelectedItem != null)
                {
                    subcategoryComboBox.ItemsSource = ((Category)categoryComboBox.SelectedItem).Subcategories.ToList();
                    GoodsList.ItemsSource = MainWindow.carShopEntities.Goods.Where(x => x.Subcategory.CategoryId
                    == ((Category)categoryComboBox.SelectedItem).id).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void subcategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Subcategory)subcategoryComboBox.SelectedItem != null)
            {
                GoodsList.ItemsSource = ((Subcategory)subcategoryComboBox.SelectedItem).Goods.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddProduct());
        }

        private void Deleted_Click(object sender, RoutedEventArgs e)
        {
            var materialForDelete = GoodsList.SelectedItems.Cast<Good>().ToList();
            if (GoodsList.SelectedItem as Good != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить этот товар?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    List<Good> g = ((List<Good>)GoodsList.ItemsSource).ToList();

                    foreach (var item in materialForDelete)
                    {
                        g.Remove(item);
                        item.IsActive = false;

                        if (item.Pictures != null)
                        {
                            MainWindow.carShopEntities.Pictures.RemoveRange(item.Pictures.ToList());
                        }
                    }
                    try
                    {
                        MainWindow.carShopEntities.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    GoodsList.ItemsSource = g;
                }
            }
            else MessageBox.Show("Выберите товар для удаления!");
        }

        private void GoodsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new AddProduct((Good)((ListView)sender).SelectedItem));

        }

        private void isDelivery_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.carShopEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void isDelivery_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.carShopEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Rest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                categoryComboBox.SelectedItem = null;
                subcategoryComboBox.SelectedItem = null;
                GoodsList.ItemsSource = MainWindow.carShopEntities.Goods.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
