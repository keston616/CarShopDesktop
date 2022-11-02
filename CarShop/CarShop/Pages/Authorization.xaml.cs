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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        MainWindow mainWindow;
        public Authorization(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void emailName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailName.Text == "E-mail")
            {
                emailName.Text = "";
                emailName.Foreground = Brushes.Black;
                emailName.BorderBrush = Brushes.Black;
            }
        }

        private void emailName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailName.Text == "")
            {
                emailName.Text = "E-mail";
                emailName.Foreground = Brushes.Gray;
                emailName.BorderBrush = Brushes.Gray;
            }
        }

        private void passwordfield_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordfield.Visibility = Visibility.Visible;
            passHelper.Visibility = Visibility.Hidden;
            passwordfield.Focus();
        }

        private void passwordfield_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordfield.Password == "")
            {
                passwordfield.Visibility = Visibility.Hidden;
                passHelper.Visibility = Visibility.Visible;
            }
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PassWar.Visibility = Visibility.Hidden;
                emailWar.Visibility = Visibility.Hidden;

                if (emailName.Text != "" && emailName.Text != "E-mail")
                {
                    if (passwordfield.Password != "" && passwordfield.Password != "Пароль")
                    {
                        DateAuthorization clientInfoAuthorization = (DateAuthorization)MainWindow.carShopEntities.DateAuthorizations.
                            Where(x => x.Email == emailName.Text).ToList().FirstOrDefault();
                        if (clientInfoAuthorization != null)
                        {
                            if (clientInfoAuthorization.Password == passwordfield.Password)
                            {

                                MainWindow.client = clientInfoAuthorization.User;
                                if (clientInfoAuthorization.User.IsAdmin)
                                {
                                    this.NavigationService.Navigate(new ListProductAdminView());
                                    mainWindow.AdminPanelVisible();
                                }
                                else
                                {
                                    mainWindow.authAccount.Visibility = Visibility.Hidden;
                                    mainWindow.personalAccount.Visibility = Visibility.Visible;
                                    this.NavigationService.GoBack();
                                }

                            }
                            else
                            {
                                PassWar.Visibility = Visibility.Visible;
                                passBorder.BorderBrush = Brushes.Red;
                            }
                        }
                        else
                        {
                            emailWar.Visibility = Visibility.Visible;
                            emailName.BorderBrush = Brushes.Red;
                        }
                    }
                    else
                    {
                        fieladNullWar.Visibility = Visibility.Visible;
                        passBorder.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    fieladNullWar.Visibility = Visibility.Visible;
                    emailName.BorderBrush = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
