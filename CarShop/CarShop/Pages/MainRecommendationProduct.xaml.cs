using CarShop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CarShop
{
    /// <summary>
    /// Логика взаимодействия для MainRecommendationProduct.xaml
    /// </summary>
    public partial class MainRecommendationProduct : Page
    {

        DispatcherTimer timer = new DispatcherTimer();
        List<BitmapImage> images = new List<BitmapImage>();
        public MainRecommendationProduct()
        {
            try
            {
                InitializeComponent();
                timer.Interval = TimeSpan.FromMilliseconds(10000);
                timer.Tick += new EventHandler(timer_Tick);
                images.Add(new BitmapImage(new Uri(@"pack://application:,,,/Images/1.jpg")));
                images.Add(new BitmapImage(new Uri(@"pack://application:,,,/Images/2.jpg")));
                timer.Start();
                DateTime dt = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 1);
                recommendProduct.ItemsSource = (List<Good>)(MainWindow.carShopEntities.Sales.Where(x => x.Date >= dt).
                    Join(MainWindow.carShopEntities.GoodSales, g => g.Id, gs => gs.SaleId, (g, gs) =>
                    new
                    {
                        gs.Good
                    }
                        )).Select(x => x.Good).Where(x => x.IsActive == true && x.Count > 0).ToList().Distinct().Skip(0).Take(10).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in images)
                {
                    advertisementImage.Source = item;
                    images.Remove(item);
                    images.Add(item);
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new InfoProduct(recommendProduct.SelectedItem as Good));
        }
    }
}

