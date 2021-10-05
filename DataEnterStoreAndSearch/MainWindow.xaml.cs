using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DataEnterStoreAndSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArrayList employees = null; //TODO: put this in store manager class and rename to searchResults
        private Regex integerRegularExpression = new Regex("[^0-9]+");

        public MainWindow()
        {
            InitializeComponent();

            employees = new ArrayList();

            for (int i = 0; i < 4; i++)
            {
                employees.Add(new DataClass("Juicy Fruit", 800 + i, "Veggetables"));
            }

            EmployeeDataGrid.ItemsSource = employees;
        }

        private bool IsStorePathValid()
        {
            //TODO: really validate for real
            return true;
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            //TODO: search for the next increment of idnumber and set to IDNumberLabelledTextBox.MyTextBox.Text
        }

        private void OnIDNumberLabelledTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = integerRegularExpression.IsMatch(e.Text);
        }

        private void OnIDNumberLabelledTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void OnSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameLabelledTextBox.MyTextBox.Text;
            int idNumber = 0;
            string department = DepartmentLabelledTextBox.MyTextBox.Text;

            int.TryParse(IDNumberLabelledTextBox.MyTextBox.Text, out idNumber);

            //TODO: add data to store
        }

        private void OnSearchButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: search store based on entered text

            // Check if text is a number. If so, search by idnumber

            // Else, check if any employee's name in the store matches. If so, get the all occurances

            // Else, check if there is a department that matches. If so, get all results based on department

            // Cache results into the DataGrid
        }

        private void OnValidateStorePathButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: clear datagrid
            //TODO: validate store path
        }
    }
}
