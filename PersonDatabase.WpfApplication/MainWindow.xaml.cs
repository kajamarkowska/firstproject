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
            persons = new PersonCollection("persons.txt");
            table.ItemsSource = persons.Persons;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            persons.Save("persons.txt");

        }
    }
}
