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
using System.Net;

namespace CalendarNotes
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorisation.xaml
    /// </summary>
    public partial class WindowAuthorisation : Window
    {

        public WindowAuthorisation()
        {
            InitializeComponent();

            MessageBox.Show("Здравствуйте! Это программа по созданию календарных заметок. Для начала работы введите логин и пароль, а затем нажмите Войти, для показа пароля дважды щелкните по глазу", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Проверка пароля и логина при входе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Authorise(object sender, RoutedEventArgs e)
        {
            const string loginClient = "Client";
            const string passwordClient = "qwerty";
            const string loginAdmin = "Admin";
            const string passwordAdmin = "qwerty";
            if (Password.Password== passwordClient && Login.Text==loginClient || Password.Password == passwordAdmin && Login.Text == loginAdmin)
            {
                WindowWork w = new WindowWork();
                w.Show();
                this.Close();
            }
            else if (Login.Text == loginClient && passwordClient != Password.Password || Login.Text == loginAdmin && passwordAdmin != Password.Password)
            {
                MessageBox.Show("Введен неверный пароль для логина","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Password.Password = "";
            }
            else
            {
                MessageBox.Show("Такого пользователя нет в системе", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
                Password.Password = "";
                Login.Text = "";
            }

        }
       
        /// <summary>
        /// Метод для открытия доступа к паролю при заполнении логина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            Parole.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Метод для открытия доступа к кнопке авторизации и показа пароля при заполнении пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Checker.Visibility = Visibility.Visible;
            ButtonAuthorise.Visibility = Visibility.Visible;
        }

        private void Checker_Checked(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Hidden;
            PasswordText.Text = new NetworkCredential(string.Empty, Password.SecurePassword).Password;
            PasswordText.Focus();
        }

        private void Checker_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;
            Password.Focus();
        }
    }
   
}
