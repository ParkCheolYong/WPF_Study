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

namespace WpfDialogBox
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

        private void btnOkCancel_Click(object sender, RoutedEventArgs e)
        {
            var okCancelDialog = new OkCancelDialog("Title", "Message");
            bool? result = okCancelDialog.ShowDialog();
            MessageBox.Show(result.ToString());
        }

        private void btnMessageBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInputBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
