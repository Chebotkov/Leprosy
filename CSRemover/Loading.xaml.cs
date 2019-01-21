using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CSRemover
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
        }

        private async void Load()
        {
            int i = 0;

            await Task.Run(() =>
            {
                while (i < 100)
                {
                    Progress.Dispatcher.Invoke(() => Progress.Value = i, DispatcherPriority.Background);
                    i++;
                    Thread.Sleep(1000);
                }
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Settings settings = this.Parent as Settings;
            Load();

            try
            {
                Additional_Classes.Remover.Remove(settings.selectedPath);
            }
            catch (Exception error) { MessageBox.Show(error.Message); }

            //Shutdown(); //Don't forget to uncomment.
        }

        private void Shutdown()
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
        }
    }
}
