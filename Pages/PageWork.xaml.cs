using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using CalendarNotes.Pages;

namespace CalendarNotes
{
    /// <summary>
    /// Логика взаимодействия для PageWork.xaml
    /// </summary>
    public partial class PageWork : Page
    {
        private string source = "../../Resources/MyNotes.txt"; //Файл для записи и чтения заметок
        public PageWork()
        {
            InitializeComponent();
            PickedDate.SelectedDate = DateTime.Today; //Установка сегодняшней даты по умолчанию
        }
        /// <summary>
        /// Метод записи в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMakeNote_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNote.Text != null && TextBoxNote.Text != "") //Проверка на заполнение поля
            {
                /* Блок записи в файл
                 * Сначала вызов записи в файл с сохранением,
                   затем запись выбранной даты и заметки */
                using (StreamWriter writerFirst = new StreamWriter(source, true))
                {

                    writerFirst.WriteLine(PickedDate.SelectedDate);
                    writerFirst.WriteLine(TextBoxNote.Text);
                    writerFirst.WriteLine(" ");
                    writerFirst.Close();
                }
                MessageBox.Show("Данные успешно внесены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Не все данные внесены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Метод открытия заметок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenNotes_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new PageMyNotes());
            
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        /// <summary>
        /// Метод вызова справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
           
            
        }
    }
}
