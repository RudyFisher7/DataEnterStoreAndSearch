using DataEnterStoreAndSearch.Controller;
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
        #region Error Messages
        private const string ID_NUMBER_ALREADY_EXISTS = "Failed. ID number already exists.";
        #endregion

        private Regex integerRegularExpression = new Regex("[^0-9]+");
        private IController controller;

        public MainWindow()
        {
            InitializeComponent();

            EmployeeDataGrid.ItemsSource = null;
            controller = new ControllerJSON();
        }

        private bool IsStorePathValid()
        {
            //TODO: really validate for real
            return true;
        }

        private void DisplayError(string error)
        {
            InputErrorMessageLabel.Content = error;
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
            bool didSuccessfullyWriteToStore = false;

            int.TryParse(IDNumberLabelledTextBox.MyTextBox.Text, out idNumber); //TODO: Do this in validator class

            didSuccessfullyWriteToStore = controller.WriteToStore(StorePathTextBox.Text, name, idNumber, department);

            if (!didSuccessfullyWriteToStore)
            {
                DisplayError(ID_NUMBER_ALREADY_EXISTS);
            }
        }

        private void OnSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayList dataToDisplay = new ArrayList(32);
            controller.SearchStore(StorePathTextBox.Text, SearchFieldLabelledTextBox.MyTextBox.Text, dataToDisplay);

            // Cache results into the DataGrid
            EmployeeDataGrid.ItemsSource = dataToDisplay;
        }

        private void OnValidateStorePathButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: clear datagrid
            //TODO: validate store path
        }
    }
}
