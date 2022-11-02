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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        MainWindow mainWindow;
        public Registration(MainWindow mainWindow)
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

        private void phonefield_GotFocus(object sender, RoutedEventArgs e)
        {
            if (phonefield.Text == "Номер телефона")
            {
                phonefield.Text = "";
                phonefield.Foreground = Brushes.Black;
                phonefield.BorderBrush = Brushes.Black;
            }
        }

        private void phonefield_LostFocus(object sender, RoutedEventArgs e)
        {
            if (phonefield.Text == "")
            {
                phonefield.Text = "Номер телефона";
                phonefield.Foreground = Brushes.Gray;
                phonefield.BorderBrush = Brushes.Gray;
            }
        }

        private void surnamefield_GotFocus(object sender, RoutedEventArgs e)
        {
            if (surnamefield.Text == "Фамилия")
            {
                surnamefield.Text = "";
                surnamefield.Foreground = Brushes.Black;
                surnamefield.BorderBrush = Brushes.Black;
            }
        }

        private void surnamefield_LostFocus(object sender, RoutedEventArgs e)
        {
            if (surnamefield.Text == "")
            {
                surnamefield.Text = "Фамилия";
                surnamefield.Foreground = Brushes.Gray;
                surnamefield.BorderBrush = Brushes.Gray;
            }
        }

        private void namefield_GotFocus(object sender, RoutedEventArgs e)
        {
            if (namefield.Text == "Имя")
            {
                namefield.Text = "";
                namefield.Foreground = Brushes.Black;
                namefield.BorderBrush = Brushes.Black;
            }
        }

        private void namefield_LostFocus(object sender, RoutedEventArgs e)
        {
            if (namefield.Text == "")
            {
                namefield.Text = "Имя";
                namefield.Foreground = Brushes.Gray;
                namefield.BorderBrush = Brushes.Gray;
            }
        }

        private void middlenamefield_GotFocus(object sender, RoutedEventArgs e)
        {
            if (middlenamefield.Text == "Отчество")
            {
                middlenamefield.Text = "";
                middlenamefield.Foreground = Brushes.Black;
                middlenamefield.BorderBrush = Brushes.Black;
            }
        }

        private void middlenamefield_LostFocus(object sender, RoutedEventArgs e)
        {
            if (middlenamefield.Text == "")
            {
                middlenamefield.Text = "Отчество";
                middlenamefield.Foreground = Brushes.Gray;
                middlenamefield.BorderBrush = Brushes.Gray;
            }
        }

        private void passwordfield_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordfield.Text == "Пароль")
            {
                password2.Visibility = Visibility.Visible;
                passwordfield.Visibility = Visibility.Hidden;
                password2.Focus();
            }
        }

        private void password2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (password2.Password == "")
            {
                password2.Visibility = Visibility.Hidden;
                passwordfield.Visibility = Visibility.Visible;
            }
        }

        private void passwordfield2_GotFocus(object sender, RoutedEventArgs e)
        {
            password1.Visibility = Visibility.Visible;
            passwordfield2.Visibility = Visibility.Hidden;
            password1.Focus();
        }

        private void password1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (password1.Password == "")
            {
                password1.Visibility = Visibility.Hidden;
                passwordfield2.Visibility = Visibility.Visible;

            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fieladNullWar.Visibility = Visibility.Hidden;
                emailWar.Visibility = Visibility.Hidden;
                emailName.BorderBrush = Brushes.Black;
                password1.BorderBrush = Brushes.Gray;
                password2.BorderBrush = Brushes.Gray;

                if (emailName.Text != "" && emailName.Text != "E-mail" &&
                    phonefield.Text != "" && phonefield.Text != "Номер телефона" &&
                    password1.Password != "" && password2.Password != "" &&
                    surnamefield.Text != "" && surnamefield.Text != "Фамилия" &&
                    namefield.Text != "" && namefield.Text != "Имя" &&
                    middlenamefield.Text != "" && middlenamefield.Text != "Отчество")
                {
                    DateAuthorization clientInfoAuth = MainWindow.carShopEntities.DateAuthorizations.
                        Where(x => x.Email == emailName.Text).ToList().FirstOrDefault();
                    Regex phoneRegex = new Regex(@"^(8)[0-9]{10}$");
                    if (!phoneRegex.IsMatch(phonefield.Text))
                    {
                        MessageBox.Show("Номер телефона введён не корректно");
                        return;
                    }
                    Regex emailControl = new Regex("[a-z]{1,20}[0-9]{0,10}(@)(gmail.com || @mail.ru || bk.ru || yandex.ru ||outlook.com)");
                    if (clientInfoAuth == null)
                    {
                        if (emailControl.IsMatch(emailName.Text))
                        {
                            if (password1.Password == password2.Password && password2.Password != "")
                            {
                                User newClient = new User
                                {
                                    Surname = surnamefield.Text,
                                    Name = namefield.Text,
                                    MiddleName = namefield.Text,
                                    Phone = phonefield.Text,
                                    IsAdmin = false,
                                    DateAuthorizations = new List<DateAuthorization>
                                {
                                        new DateAuthorization
                                        {
                                            Email = emailName.Text,
                                            Password = password1.Password
                                        }
                                }
                                };
                                MainWindow.carShopEntities.Users.Add(newClient);
                                MainWindow.carShopEntities.SaveChanges();
                                MainWindow.client = newClient;
                                this.NavigationService.Navigate(new MainRecommendationProduct());
                                mainWindow.authAccount.Visibility = Visibility.Hidden;
                                mainWindow.personalAccount.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                WarPass.Visibility = Visibility.Visible;
                                password2.BorderBrush = Brushes.Red;
                                password1.BorderBrush = Brushes.Red;
                            }
                        }
                        else
                        {
                            emailWar.Visibility = Visibility.Visible;
                            emailName.BorderBrush = Brushes.Red;
                            emailWar.Text = "Некорректный ввод эл. почты";
                        }
                    }
                    else
                    {
                        emailWar.Visibility = Visibility.Visible;
                        emailWar.Text = "Эл. почта занята";
                        emailName.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    fieladNullWar.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

