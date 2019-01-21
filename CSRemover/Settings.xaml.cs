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
        public string selectedPath;

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
                if (CSRemover.Additional_Classes.Remover.IsPathExists(selectedPath))
                {
                    Loading loading = new Loading();
                    this.Visibility = Visibility.Collapsed;
                    loading.ShowDialog();
                }
                else System.Windows.MessageBox.Show("This directory doesn't exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);     
            }
            else
            {
                System.Windows.MessageBox.Show("Select the path to your counter-strike or choose cheats for installing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }        
    }
}
