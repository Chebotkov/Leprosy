using System;
using System.Windows;
using System.Windows.Forms;

namespace CSRemover
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private string selectedPath;

        public Settings()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            selectedPath = dialog.SelectedPath;
            if (selectedPath != null)
            {
                LabelForPath.Content = selectedPath;
            }
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(selectedPath))
            {
                Loading loading = new Loading();
                this.Visibility = Visibility.Collapsed;
                loading.ShowDialog();
                /*if (CSRemover.Additional_Classes.Remover.Remove(selectedPath))
                {

                    //Shutdown();
                }
                else System.Windows.MessageBox.Show("This path doesn't exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    */        
            }
            else
            {
                System.Windows.MessageBox.Show("Select the path to your counter-strike or choose cheats for installing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Shutdown()
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
        }
    }
}
