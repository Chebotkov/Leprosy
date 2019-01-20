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

namespace CSRemover
{
    /// <summary>
    /// Interaction logic for Terms.xaml
    /// </summary>
    public partial class Terms : Window
    {
        private List<string> TermsListData = new List<string>(); 

        public Terms()
        {
            InitializeComponent();
            TermsListData.Add("By using this cheat you are agree with next terms:");
            TermsListData.Add("The creator is not responsible for the consequences occuring in use this cheat.");
            TermsListData.Add("Cheat may contain bugs, so use of this tool is at your own risk.");
            TermsListData.Add("Cheat may remove some of your counter-strike data, so you use this tool at your own risk and agree with consequences.");
            TermsList.ItemsSource = TermsListData;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
