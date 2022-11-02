using System;
using System.Collections.Generic;
using System.IO;
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

namespace CarShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoProduct.xaml
    /// </summary>
    public partial class InfoProduct : Page
    {
        public InfoProduct(Good good)
        {
            InitializeComponent();
            DataContext = good;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void GoCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CountProduct.Text != "")
                {
                    foreach (var item in MainWindow.Instance.GoodCart)
                    {
                        if (item.Good == (Good)DataContext)
                        {
                            item.Count = item.Count + Convert.ToInt32(CountProduct.Text);
                            MainWindow.Instance.GoodCart = MainWindow.Instance.GoodCart;
                            return;
                        }
                    }
                    MainWindow.Instance.GoodCart.Add(new GoodSale
                    {
                        Good = (Good)DataContext,
                        Count = Convert.ToInt32(CountProduct.Text)
                    });

                    MainWindow.Instance.GoodCart = MainWindow.Instance.GoodCart;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MemoryStream ms = new MemoryStream((((Grid)sender).DataContext as Picture).Image);
            ImageMain.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }


        public static DependencyObject GetScrollViewer(DependencyObject o)
        {
            // Return the DependencyObject if it is a ScrollViewer
            if (o is ScrollViewer)
            { return o; }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var child = VisualTreeHelper.GetChild(o, i);

                var result = GetScrollViewer(child);
                if (result == null)
                {
                    continue;
                }
                else
                {
                    return result;
                }
            }
            return null;
        }

        private void OnScrollRight(object sender, MouseButtonEventArgs e)
        {
            var scrollViwer = GetScrollViewer(ImageList) as ScrollViewer;

            if (scrollViwer != null)
            {
                // Logical Scrolling by Item
                // scrollViwer.LineUp();
                // Physical Scrolling by Offset
                scrollViwer.LineRight();
            }
        }

        private void OnScrollLeft(object sender, MouseButtonEventArgs e)
        {
            var scrollViwer = GetScrollViewer(ImageList) as ScrollViewer;

            if (scrollViwer != null)
            {
                // Logical Scrolling by Item
                // scrollViwer.LineUp();
                // Physical Scrolling by Offset
                scrollViwer.LineLeft();
            }
        }

        private void CountProduct_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex intControl = new Regex(@"^([1-9]{1})([0-9]{0,})$");
            if (!intControl.IsMatch(CountProduct.Text + e.Text))
            {
                e.Handled = true;
            }
        }
    }
}
