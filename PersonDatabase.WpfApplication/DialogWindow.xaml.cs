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

        private void Button_Okey(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            //to nie wiem
        }


    }
}
