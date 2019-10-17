using PersonDatabase.Model;
using System.Windows;

namespace PersonDatabase.WpfApplication
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonCollection persons;



        public MainWindow()
        {
            InitializeComponent();
            persons = new PersonCollection("baza.db");
            table.ItemsSource = persons.Persons;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            persons.Save("persons.txt");

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
