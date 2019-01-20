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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSRemover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (TermsAgreement.IsChecked.Value)
            {
                Settings settingsWindow = new Settings();
                settingsWindow.Owner = this;
                Visibility = Visibility.Hidden;
                settingsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must agree with termms and conditions.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void TermsButton_Click(object sender, RoutedEventArgs e)
        {
            Terms termsWindow = new Terms();
            termsWindow.ShowDialog();
        }
    }
}
