using Microsoft.Win32;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        Good goodValue;
        public AddProduct()
        {
            InitializeComponent();
            UnitField.ItemsSource = MainWindow.carShopEntities.Units.ToList();
            BrandName.ItemsSource = MainWindow.carShopEntities.Brands.ToList();
            categoryList.ItemsSource = MainWindow.carShopEntities.Categories.ToList();
        }
        public AddProduct(Good good) : this()
        {
            goodValue = good;
            Description.Text = good.Description;
            Description.Foreground = Brushes.Black;
            nameProduct.Text = good.Name;
            nameProduct.Foreground = Brushes.Black;
            UnitField.SelectedItem = good.Unit;
            categoryList.SelectedItem = good.Subcategory.Category;
            subcategoryList.SelectedItem = good.Subcategory;
            UnitField.Foreground = Brushes.Black;
            BrandName.SelectedItem = good.Brand;
            BrandName.Foreground = Brushes.Black;
            PriceField.Text = Convert.ToString(good.Price);
            PriceField.Foreground = Brushes.Black;
            CountProductField.Text = Convert.ToString(good.Count);
            CountProductField.Foreground = Brushes.Black;
            ImageList.ItemsSource = good.Pictures.ToList();
            GoBackButton.Content = "Сохранить";
        }
        List<string> filePaths;

        private void NewImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            openDialog.ShowDialog();
            filePaths = openDialog.FileNames.ToList();
            List<Picture> pictures = new List<Picture>();
            foreach (var item in filePaths)
            {
                pictures.Add(new Picture
                {
                    Image = System.IO.File.ReadAllBytes(item),
                    GoodId = 1,
                });
            }

            ImageList.ItemsSource = pictures;
        }

        private void ImageLoad(Good good)
        {
            try
            {
                foreach (var item in filePaths)
                {
                    MainWindow.carShopEntities.Pictures.Add(new Picture { Image = System.IO.File.ReadAllBytes(item), Good = good });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void nameProduct_GotFocus(object sender, RoutedEventArgs e)
        {
            if (nameProduct.Text == "Название товара")
            {
                nameProduct.Text = "";
                nameProduct.Foreground = Brushes.Black;
            }
        }

        private void nameProduct_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nameProduct.Text == "")
            {
                nameProduct.Text = "Название товара";
                nameProduct.Foreground = Brushes.Gray;
            }
        }

        private void CountProductField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CountProductField.Text == "Количество")
            {
                CountProductField.Text = "";
                CountProductField.Foreground = Brushes.Black;
            }
        }

        private void CountProductField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CountProductField.Text == "")
            {
                CountProductField.Text = "Количество";
                CountProductField.Foreground = Brushes.Gray;
            }
        }
        private void Discription_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Description.Text == "Подробное описание товара")
            {
                Description.Text = "";
                Description.Foreground = Brushes.Black;
            }
        }

        private void Discription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Description.Text == "")
            {
                Description.Text = "Подробное описание товара";
                Description.Foreground = Brushes.Gray;
            }
        }



        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BrandName.SelectedItem != null && nameProduct.Text != ""
                    && categoryList.SelectedItem != null && subcategoryList.SelectedItem != null
                    && nameProduct.Text != "Название товара" && CountProductField.Text != ""
                    && CountProductField.Text != "Количество" && UnitField.SelectedItem != null
                    && Description.Text != "" && Description.Text != "Подробное описание товара"
                    && PriceField.Text != "" && PriceField.Text != "Цена")
                {
                    if (ImageList.ItemsSource != null)
                    {
                        if (goodValue == null)
                        {
                            goodValue = new Good();
                        }

                        goodValue.Brand = (Brand)BrandName.SelectedItem;
                        goodValue.Name = nameProduct.Text;
                        goodValue.Unit = (Unit)UnitField.SelectedItem;
                        goodValue.Subcategory = (Subcategory)subcategoryList.SelectedItem;
                        goodValue.Price = Convert.ToDecimal(PriceField.Text);
                        goodValue.Count = Convert.ToInt32(CountProductField.Text);
                        goodValue.Description = Description.Text;
                        goodValue.IsActive = true;

                        if (filePaths != null)
                        {
                            ImageLoad(goodValue);
                        }

                        if (goodValue == null)
                        {
                            MainWindow.carShopEntities.Goods.Add(goodValue);
                        }

                        MainWindow.carShopEntities.SaveChanges();


                        this.NavigationService.GoBack();
                    }
                    else
                    {
                        WarImage.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountProductField_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex intControl = new Regex(@"^([1-9]{1})([0-9]{0,})$");
            if (!intControl.IsMatch(CountProductField.Text + e.Text))
            {
                e.Handled = true;
            }
        }

        private void AddNewBrand_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                AddValue newBrand = new AddValue();
                if (newBrand.ShowDialog() == true)
                {
                    BrandName.ItemsSource = MainWindow.carShopEntities.Brands.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddNewUntir_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                AddValue newBrand = new AddValue(false);
                if (newBrand.ShowDialog() == true)
                {
                    UnitField.ItemsSource = MainWindow.carShopEntities.Units.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PriceField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PriceField.Text == "Цена")
            {
                PriceField.Text = "";
                PriceField.Foreground = Brushes.Black;
            }
        }

        private void PriceField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PriceField.Text == "")
            {
                PriceField.Text = "Цена";
                PriceField.Foreground = Brushes.Gray;
            }
        }

        private void PriceField_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex r = new Regex(@"^((([0]{1})((,)([0-9]{0,}))?)||([1-9]{1}([0-9]{0,})((,)([0-9]{0,}))?))$");
            if (!r.IsMatch((PriceField.Text + e.Text)))
            {
                e.Handled = true;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void categoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            subcategoryList.ItemsSource = ((Category)categoryList.SelectedItem).Subcategories.ToList();

        }
    }
}
