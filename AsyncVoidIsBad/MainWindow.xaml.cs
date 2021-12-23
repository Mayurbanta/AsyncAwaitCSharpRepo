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

namespace AsyncVoidIsBad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBlockStatus.Text = "Status";
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            textBlockStatus.Text = "Status";

            MyService myService = new MyService();

            textBlockStatus.Text = "Process complete";
        }

    }
}
