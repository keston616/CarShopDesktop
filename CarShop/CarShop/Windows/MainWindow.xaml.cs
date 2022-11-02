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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public static CarShopEntities carShopEntities = new CarShopEntities();
        public static User client;
        public static MainWindow Instance { get; private set; }
        Expander exp = new Expander();
        public MainWindow()
        {
            InitializeComponent();
            listProduct.ItemsSource = carShopEntities.Categories.ToList();
            Instance = this;
        }

        private List<GoodSale> goodCart = new List<GoodSale>();
        public List<GoodSale> GoodCart
        {
            get
            {
                return goodCart;
            }
            set
            {
                goodCart = value;
                if (goodCart.Count == 0)
                {
                    this.shoppingСart.Text = "Ваша корзина пуста";
                }
                else
                {
                    double sum = 0;
                    foreach (var item in goodCart)
                    {
                        sum = sum + Convert.ToDouble(item.Count * item.Good.Price);
                    }
                    this.shoppingСart.Text = $"{goodCart.Count} товар на {sum} руб.";
                }
            }
        }


        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            if(exp != ((Expander)sender))
            exp.IsExpanded = false;
            exp = ((Expander)sender);
        }

        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(searchBox.Text == "Введите название товара")
            {
                searchBox.Clear();
                searchBox.Foreground = Brushes.Black;
            }
           
        }

        private void searchBox_LostFocus(object sender, RoutedEventArgs e)
        {
          
            if (searchBox.Text.Length == 0)
            {
                searchBox.Text = "Введите название товара";
            }
            searchBox.Foreground = Brushes.Gray;
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PageFrame.NavigationService.Navigate(new ListProduct(searchBox.Text));
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization(this);
            CategoryHidden();
            PageFrame.NavigationService.Navigate(authorization);
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(this);
            CategoryHidden();
            PageFrame.NavigationService.Navigate(registration);
        }

        private void PersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            MyShoppingСart myShoppingСart = new MyShoppingСart();
            CategoryHidden();
            PageFrame.NavigationService.Navigate(myShoppingСart);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainRecommendationProduct mainRecommendationProduct = new MainRecommendationProduct();
                PageFrame.NavigationService.Navigate(mainRecommendationProduct);
                personalAccount.Visibility = Visibility.Hidden;
               
                authAccount.Visibility = Visibility.Visible;
                
                if (client.IsAdmin == true)
                {
                    AdminPanelHidden();
                }
                MainWindow.client = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MyCartNavigate_Click(object sender, MouseButtonEventArgs e)
        {
            PageFrame.NavigationService.Navigate(new MyShoppingСart(true));
            CategoryHidden();
        }

        private void GoRecommendProduct_Click(object sender, MouseButtonEventArgs e)
        {
            PageFrame.NavigationService.Navigate(new MainRecommendationProduct());
        }

        private void CatalogVisible(object sender, MouseButtonEventArgs e)
        {
            if (listProduct.Visibility == Visibility.Hidden)
            {
                CategoryVisibible();
            }
            else
            {
                CategoryHidden();
            }     
        }

        private void CategoryVisibible()
        {
            listProduct.Visibility = Visibility.Visible;
        }

        private void CategoryHidden()
        {
            listProduct.Visibility = Visibility.Hidden;
        }

        private void Expander_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            listProduct.Visibility = Visibility.Hidden;
            PageFrame.NavigationService.Navigate(new ListProduct((Subcategory)((Border)sender).DataContext));
        }

        internal void AdminPanelVisible()
        {
            CategoryStack.Visibility = Visibility.Hidden;
            searchGrid.Visibility = Visibility.Hidden;
            CartField.Visibility = Visibility.Hidden;
            authAccount.Visibility = Visibility.Hidden;
            personalAccount.Visibility = Visibility.Visible;
            AdminButton.Visibility = Visibility.Visible;
        }
        internal void AdminPanelHidden()
        {
            CategoryStack.Visibility = Visibility.Visible;
            searchGrid.Visibility = Visibility.Visible;
            CartField.Visibility = Visibility.Visible;
            authAccount.Visibility = Visibility.Visible;
            personalAccount.Visibility = Visibility.Hidden;
            AdminButton.Visibility = Visibility.Hidden;
        }

        private void AdminGoProduct_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.NavigationService.Navigate(new ListProductAdminView());
        }

        private void AdminGoSale_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.NavigationService.Navigate(new ListProductAdminView(false));
        }

        private void Border_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
