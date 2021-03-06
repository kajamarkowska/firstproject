﻿using PersonDatabase.Model;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using mshtml;

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
            LoadReportstoComboBox();
        }
        private void LoadReportstoComboBox()
        {
            DirectoryInfo directory = new DirectoryInfo("Raporty");

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                reportComboBox.Items.Add(file.Name);
            }

            reportComboBox.SelectedIndex = 0;
        }

        private void GenerateReport()
        {
            ReportGenerator rg = new ReportGenerator("baza.db");
            string reportFileName = "Raporty/" + (string)reportComboBox.SelectedItem;
            string report = rg.Generate(reportFileName, "template.html");
            browser.NavigateToString(report);

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            persons.Save("persons.txt");

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            List<Person> list = new List<Person>();

            string text = textBox.Text.ToLower();

            foreach(Person person in persons.Persons)
            {
                if (person.FirstName.ToLower().Contains(text) ||
                    person.LastName.ToLower().Contains(text) ||
                    person.Age.ToString().ToLower().Contains(text) ||
                    person.Sex.ToLower().Contains(text) ||
                    person.Height.ToString().ToLower().Contains(text) )


                    
                {
                    list.Add(person);

                }

            }

            table.ItemsSource = list;


            

        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
            GenerateReport();
        }

    

        private void ExportToPdfButtonClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.DefaultExt = ".pdf";
            dialog.Filter = "Pdf document (.pdf)|*.pdf";

            if ((bool)dialog.ShowDialog())
            {
                string html = (browser.Document as HTMLDocument).documentElement.innerHTML;
                Pdf.SaveHtmlAsPdf(dialog.FileName, html);
            } 
          

        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            DialogWindow dialog = new DialogWindow();

            if ((bool)dialog.ShowDialog())
            {
                persons.Add(dialog.Person);
                RefreshData();
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Person person = (Person)table.SelectedItem;

            if (person!= null)
            {
                if (MessageBox.Show("Czy usunąć wybrane pole?", "Potwierdzenie", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                {
                    persons.Delete(person);
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz do usunięcia");
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Person person = (Person)table.SelectedItem;

            if (person != null)
            {
                DialogWindow dialog = new DialogWindow(person);
                if ((bool)dialog.ShowDialog())
                {
                    persons.Edit(dialog.Person, table.SelectedIndex);
                    int i = table.SelectedIndex;
                    RefreshData();
                    table.SelectedIndex = i;
                }
                
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz do edycji");
            }

           
        }
        private void RefreshData()
        {
            table.ItemsSource = null;
            table.ItemsSource = persons.Persons;

        }
    }
}
