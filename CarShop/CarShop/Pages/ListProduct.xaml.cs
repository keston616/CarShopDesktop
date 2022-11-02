using CarShop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ListProduct.xaml
    /// </summary>
    public partial class ListProduct : Page
    {
        public ListProduct()
        {
            InitializeComponent();
            try { 
            categoryList.ItemsSource = MainWindow.carShopEntities.Categories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ListProduct(string searchText) : this()
        {
            try
            {
                recommendProduct.ItemsSource = MainWindow.carShopEntities.Goods.Where(x => x.Name.Contains(searchText) && x.IsActive == true && x.Count > 0).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ListProduct(Subcategory sb) : this()
        {
            try
            {
                recommendProduct.ItemsSource = MainWindow.carShopEntities.Goods.Where(x => x.SubcategoriesId == sb.Id && x.IsActive == true && x.Count > 0).ToList();

                List<Category> c = new List<Category> { new Category { Name = "Все" } };
                c.AddRange(MainWindow.carShopEntities.Categories.ToList());
                categoryList.ItemsSource = c;

                categoryList.SelectedItem = sb.Category;
                subCategoryList.SelectedItem = sb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void categoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Category)categoryList.SelectedItem != null && (((Category)categoryList.SelectedItem).Name != "Все"))
            {
                List<Subcategory> c = new List<Subcategory> { new Subcategory { Name = "Все" } };
                c.AddRange(((Category)categoryList.SelectedItem).Subcategories);
                subCategoryList.ItemsSource = c;
            }
            else
            {
                subCategoryList.ItemsSource = null;
            }

        }

        private void GoProduct_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new InfoProduct(((Grid)sender).DataContext as Good));
        }

        private async void Sort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Good> good;
                good = MainWindow.carShopEntities.Goods.Where(x => x.IsActive == true && x.Count > 0).ToList();
                if (categoryList.SelectedItem != null)
                {
                    if (((Category)categoryList.SelectedItem).Name != "Все")
                    {
                        good = good.Where(x => x.Subcategory.CategoryId == ((Category)categoryList.SelectedItem).id).ToList();
                    }
                }
                if (subCategoryList.SelectedItem != null)
                {
                    if (((Subcategory)subCategoryList.SelectedItem).Name != "Все")
                    {
                        good = good.Where(x => x.SubcategoriesId == ((Subcategory)subCategoryList.SelectedItem).Id).ToList();
                    }
                }

                if (startPrice.Text != "" || endPrice.Text != "")
                {
                    await Task.Run(() =>
                    {
                        good = good.Where(x => Convert.ToInt32(x.Price) >= Convert.ToInt32(startPrice.Text) && x.Price <= Convert.ToInt32(endPrice.Text)).ToList();
                    });
                }
                recommendProduct.ItemsSource = good.Where(x => x.IsActive == true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void startPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex r = new Regex(@"^([1-9]{1})([0-9]{0,})$");
            if (!r.IsMatch(startPrice.Text + e.Text))
            {
                e.Handled = true;
            }
        }

        private void endPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex r = new Regex(@"^([1-9]{1})([0-9]{0,})$");
            if (!r.IsMatch(endPrice.Text + e.Text))
            {
                e.Handled = true;
            }
        }


    }
}
