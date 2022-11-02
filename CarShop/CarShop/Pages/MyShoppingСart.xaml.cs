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
    /// Логика взаимодействия для MyShoppingСart.xaml
    /// </summary>
    public partial class MyShoppingСart : Page
    {
        private DateAuthorization client;
        public MyShoppingСart()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.client != null)
                {
                    client = (DateAuthorization)MainWindow.client.DateAuthorizations.FirstOrDefault().Clone();
                    DataContext = client;
                    ListOrders.ItemsSource = MainWindow.client.Sales.OrderByDescending(x => x.Date).ToList();
                    InfoClientButton.IsEnabled = true;
                    OrderButton.IsEnabled = true;
                    passUpdateButton.IsEnabled = true;
                }
                else
                {
                    InfoClientButton.IsEnabled = false;
                    OrderButton.IsEnabled = false;
                    passUpdateButton.IsEnabled = false;
                }
                Cart.DataContext = new Sale { GoodSales = MainWindow.Instance.GoodCart.ToList() };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MyShoppingСart(bool CartVisible) : this()
        {

            if (MainWindow.Instance.GoodCart.Count != 0)
            {
                Cart.Visibility = Visibility.Visible;
            }
            else
            {
                OrderText.Text = "Корзина пуста";
                OrderNull.Visibility = Visibility.Visible;
            }
        }

        private void Cart_Visible(object sender, MouseButtonEventArgs e)
        {

            InfoClient.Visibility = Visibility.Hidden;
            Order.Visibility = Visibility.Hidden;
            UpdatePassword.Visibility = Visibility.Hidden;
            OrderNull.Visibility = Visibility.Hidden;
            Cart.Visibility = Visibility.Hidden;
            if (MainWindow.Instance.GoodCart.Count != 0)
            {
                Cart.Visibility = Visibility.Visible;
            }
            else
            {
                OrderText.Text = "Корзина пуста";
                OrderNull.Visibility = Visibility.Visible;
            }
        }

        private void InfoClient_Visible(object sender, MouseButtonEventArgs e)
        {
            Cart.Visibility = Visibility.Hidden;
            Order.Visibility = Visibility.Hidden;
            InfoClient.Visibility = Visibility.Visible;
            UpdatePassword.Visibility = Visibility.Hidden;
            OrderNull.Visibility = Visibility.Hidden;
        }

        private void Order_Visible(object sender, MouseButtonEventArgs e)
        {
            Cart.Visibility = Visibility.Hidden;
            InfoClient.Visibility = Visibility.Hidden;
            UpdatePassword.Visibility = Visibility.Hidden;
            OrderNull.Visibility = Visibility.Hidden;
            Order.Visibility = Visibility.Hidden;
            if (MainWindow.client.Sales.Count != 0)
            {
                Order.Visibility = Visibility.Visible;
            }
            else
            {
                OrderNull.Visibility = Visibility.Visible;
                OrderText.Text = "Истории заказов пуста";
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cart.Visibility = Visibility.Hidden;
            Order.Visibility = Visibility.Hidden;
            InfoClient.Visibility = Visibility.Hidden;
            UpdatePassword.Visibility = Visibility.Visible;
            OrderNull.Visibility = Visibility.Hidden;
        }

        private void passwordfield_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordfield1.Text == "Старый пароль")
            {
                passwordPast.Visibility = Visibility.Visible;
                passwordfield1.Visibility = Visibility.Hidden;
                passwordPast.Focus();
            }
        }

        private void passwordPasr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordPast.Password == "")
            {
                passwordPast.Visibility = Visibility.Hidden;
                passwordfield1.Visibility = Visibility.Visible;
            }
        }

        private void passwordfield2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordfield2.Text == "Новый пароль")
            {
                passwordNew.Visibility = Visibility.Visible;
                passwordfield2.Visibility = Visibility.Hidden;
                passwordNew.Focus();
            }
        }

        private void passwordNew_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordNew.Password == "")
            {
                passwordNew.Visibility = Visibility.Hidden;
                passwordfield2.Visibility = Visibility.Visible;
            }
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                passPastWar.Visibility = Visibility.Hidden;
                passNewWar.Visibility = Visibility.Hidden;

                if (passwordPast.Password == MainWindow.client.DateAuthorizations.First().Password)
                {
                    if (passwordNew.Password.Length >= 6)
                    {
                        MainWindow.client.DateAuthorizations.First().Password = passwordNew.Password;
                        MainWindow.carShopEntities.SaveChanges();
                        MessageBox.Show("Пароль успешно изменён");
                        passwordNew.Password = "";
                        passwordPast.Password = "";
                        passwordNew.Visibility = Visibility.Hidden;
                        passwordPast.Visibility = Visibility.Hidden;
                        passwordfield1.Visibility = Visibility.Visible;
                        passwordfield2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        passNewWar.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    passPastWar.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            email.IsEnabled = true;
            phone.IsEnabled = true;
            surname.IsEnabled = true;
            name.IsEnabled = true;
            middleName.IsEnabled = true;
            cancleButton.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Visible;
        }

        private void VisibleFields()
        {
            email.IsEnabled = false;
            phone.IsEnabled = false;
            surname.IsEnabled = false;
            name.IsEnabled = false;
            middleName.IsEnabled = false;
            cancleButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Hidden;
            updateButton.Visibility = Visibility.Visible;
        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {

            client = (DateAuthorization)MainWindow.client.DateAuthorizations.FirstOrDefault().Clone();
            DataContext = client;
            VisibleFields();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (email.Text != "" && phone.Text != "" &&
                surname.Text != "" && name.Text != "" && middleName.Text != "")
                {
                    Regex r = new Regex(@"^(8)[0-9]{10}$");
                    if (!r.IsMatch(phone.Text))
                    {
                        MessageBox.Show("Номер телефона не корректен");
                        return;
                    }

                    Regex emailControl = new Regex("[a-z]{1,20}[0-9]{0,}(@)(gmail.com || @mail.ru || bk.ru || yandex.ru ||outlook.com)");
                    if (emailControl.IsMatch(email.Text))
                    {
                        MessageBox.Show("Почта введена не корректно");
                        return;
                    }
                    VisibleFields();
                    MainWindow.client.Surname = client.User.Surname;
                    MainWindow.client.Name = client.User.Name;
                    MainWindow.client.MiddleName = client.User.MiddleName;
                    MainWindow.client.Phone = client.User.Phone;
                    MainWindow.client.DateAuthorizations.First().Email = client.Email;
                    MainWindow.carShopEntities.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустыми");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex r = new Regex(@"^[1-9]{1}[0-9]{0,}$");
            if (!r.IsMatch(((TextBox)sender).Text + e.Text))
            {
                e.Handled = true;
            }
        }

        private void Cart_FullDeleted(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.GoodCart = new List<GoodSale>();
            Cart.DataContext = new Sale { GoodSales = MainWindow.Instance.GoodCart.ToList() };
        }

        private void Cart_Deleted(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CartList.SelectedItems.Count > 0)
                {
                    var gsValue = CartList.SelectedItems;
                    foreach (var item in gsValue)
                    {
                        MainWindow.Instance.GoodCart.Remove((GoodSale)item);
                    }
                    Cart.DataContext = new Sale { GoodSales = MainWindow.Instance.GoodCart };
                    MainWindow.Instance.GoodCart = MainWindow.Instance.GoodCart;
                    if (MainWindow.Instance.GoodCart.Count <= 0)
                    {
                        Cart.Visibility = Visibility.Hidden;
                        OrderText.Text = "Корзина пуста";
                        OrderNull.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Arrange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.client != null)
                {
                    Sale SaleNew = new Sale();
                    SaleNew.Date = DateTime.Now;
                    SaleNew.UserId = MainWindow.client.Id;
                    SaleNew.IsDelivered = false;
                    foreach (var item in MainWindow.Instance.GoodCart)
                    {

                        if (item.Good.Count >= item.Count)
                        {
                            item.Sale = SaleNew;
                            item.SaleId = SaleNew.Id;
                        }
                        else
                        {

                            MessageBox.Show($"{item.Good.Name} имеется в наличии только {item.Good.Count} шт");
                            return;
                        }
                    }
                    SaleNew.GoodSales = MainWindow.Instance.GoodCart;
                    MainWindow.carShopEntities.Sales.Add(SaleNew);

                    foreach (var item in MainWindow.Instance.GoodCart)
                    {
                        Good g = MainWindow.carShopEntities.Goods.Where(x => x.Id == item.GoodId).ToList().FirstOrDefault();
                        g.Count = g.Count - item.Count;
                    }
                    MainWindow.carShopEntities.SaveChanges();
                    MainWindow.Instance.GoodCart = new List<GoodSale>();
                    Cart.DataContext = new Sale { GoodSales = MainWindow.Instance.GoodCart.ToList() };
                    MainWindow.Instance.GoodCart = new List<GoodSale>();
                    Cart.Visibility = Visibility.Hidden;
                    OrderNull.Visibility = Visibility.Visible;
                    MessageBox.Show("Заказ успешно оформлен");
                    OrderText.Text = "Корзина пуста";
                    ListOrders.ItemsSource = MainWindow.client.Sales.OrderByDescending(x => x.Date).ToList();
                }
                else
                {
                    this.NavigationService.Navigate(new Authorization(MainWindow.Instance));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Count_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text == "")
                {
                    ((TextBox)sender).Text = "0";
                }
                MainWindow.Instance.GoodCart = MainWindow.Instance.GoodCart;
                Cart.DataContext = new Sale { GoodSales = MainWindow.Instance.GoodCart };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex r = new Regex(@"^(8)[0-9]{0,}$");
            if (!r.IsMatch(phone.Text + e.Text))
            {
                e.Handled = true;
            }

        }


    }
}
