using PersonDatabase.Model;
using System.Windows;

namespace PersonDatabase.WpfApplication
{
    /// <summary>
    /// Logika interakcji dla klasy DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        
        public DialogWindow()
        {
            InitializeComponent();
            
        }
        public Person Person
        {
            get
            {
                return new Person(firstNameTextBox.Text, lastNameTextBox.Text, int.Parse(ageTextBox.Text), sexTextBox.Text, int.Parse(heighTextBox.Text));
            }
        }

        public DialogWindow(Person person)
        {
            InitializeComponent();
            firstNameTextBox.Text = person.FirstName;
            lastNameTextBox.Text = person.LastName;
            ageTextBox.Text = person.Age + "";
            sexTextBox.Text = person.Sex;
            heighTextBox.Text = person.Height + "";
        }
        private void Button_Okey(object sender, RoutedEventArgs e)
        {
            int n;
            bool isokey = true;
            if(!int.TryParse(ageTextBox.Text,out n))
            {
                MessageBox.Show("Podano nieprawidłowy wiek");
                isokey = false;

            }
           
            if(!int.TryParse(heighTextBox.Text, out n))
            {
                MessageBox.Show("Podano nieprawidłowy wzrost");
                isokey = false;
            }

            if (isokey)
            {
                DialogResult = true;

            }

            else
            {
                DialogResult = null;
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

      


    }
}
