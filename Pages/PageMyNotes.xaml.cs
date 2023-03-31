using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarNotes.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMyNotes.xaml
    /// </summary>
    public partial class PageMyNotes : Page
    {
        private string source = "../../Resources/MyNotes.txt"; //Файл для записи и чтения заметок
        public PageMyNotes()
        {
            InitializeComponent();
            using (StreamReader readerFirst = new StreamReader(source, System.Text.Encoding.UTF8)) //Вызов чтения из файла
            {
                string notes;
                var resultNote = new StringBuilder();
                while (readerFirst.EndOfStream != true)
                {
                    notes = readerFirst.ReadLine();
                    resultNote.AppendLine(notes);
                }
                TextBlockMyNotes.Text = resultNote.ToString();
            }
            
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new PageWork());
        }
    }
}
