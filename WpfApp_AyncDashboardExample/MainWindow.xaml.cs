using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp_AyncPatientChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClass _myClass;
        public MainWindow()
        {
            InitializeComponent();

            _myClass = new MyClass();
        }

        private void btnSyncCall_Click(object sender, RoutedEventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            lblTotalTimeElapsed.Content = string.Empty;

            lblBlock1.Content = _myClass.Block1Data();
            lblBlock1.Background = new SolidColorBrush(Colors.Aqua);
            lblTotalTimeElapsed.Content = "25%";

            lblBlock2.Content = _myClass.Block2Data();
            lblBlock2.Background = new SolidColorBrush(Colors.Aqua);
            lblTotalTimeElapsed.Content = "50%";

            lblBlock3.Content = _myClass.Block3Data();
            lblBlock3.Background = new SolidColorBrush(Colors.Aqua);
            lblTotalTimeElapsed.Content = "75%";

            lblBlock4.Content = _myClass.Block4Data();
            lblBlock4.Background = new SolidColorBrush(Colors.Aqua);

            stopwatch.Stop();

            lblTotalTimeElapsed.Content = "Total Time: " + stopwatch.ElapsedMilliseconds;
        }

        private async void btnAsyncCall_Click(object sender, RoutedEventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            lblTotalTimeElapsed.Content = string.Empty;

            lblBlock1.Content =  await _myClass.Block1DataAsync();
            lblBlock1.Background =  new SolidColorBrush(Colors.Aqua);
            lblTotalTimeElapsed.Content = "25%";

            lblBlock2.Content = await _myClass.Block2DataAsync();
            lblBlock2.Background = new SolidColorBrush(Colors.Aqua);
            lblTotalTimeElapsed.Content = "50%";

            lblBlock3.Content = await _myClass.Block3DataAsync();
            lblBlock3.Background = new SolidColorBrush(Colors.Aqua);
            lblTotalTimeElapsed.Content = "75%";

            lblBlock4.Content = await _myClass.Block4DataAsync();
            lblBlock4.Background = new SolidColorBrush(Colors.Aqua);

            stopwatch.Stop();

            lblTotalTimeElapsed.Content = "Total Time: " + stopwatch.ElapsedMilliseconds;

        }

        private void lblReset_Click(object sender, RoutedEventArgs e)
        {
            lblBlock1.Content = "1st block";
            lblBlock2.Content = "2nd block";
            lblBlock3.Content = "3rd block";
            lblBlock4.Content = "4th block";

            lblBlock1.Background = new SolidColorBrush(Colors.White);
            lblBlock2.Background = new SolidColorBrush(Colors.White);
            lblBlock3.Background = new SolidColorBrush(Colors.White);
            lblBlock4.Background = new SolidColorBrush(Colors.White);

            lblTotalTimeElapsed.Content = "Total Time: ...";
        }

        private async void btnTaskAll_Click(object sender, RoutedEventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            lblTotalTimeElapsed.Content = string.Empty;


            var block1Task =  _myClass.Block1DataAsync();
            lblTotalTimeElapsed.Content = "25%";

            var block2Task = _myClass.Block2DataAsync();
            lblTotalTimeElapsed.Content = "50%";

            var block3Task = _myClass.Block3DataAsync();
            lblTotalTimeElapsed.Content = "75%";

            var block4Task = _myClass.Block4DataAsync();
            lblTotalTimeElapsed.Content = "100%";
            await Task.WhenAll(block1Task, block2Task, block3Task, block4Task);



            lblBlock1.Content = block1Task.Result;
            lblBlock1.Background = new SolidColorBrush(Colors.Aqua);

            lblBlock2.Content = block2Task.Result;
            lblBlock2.Background = new SolidColorBrush(Colors.Aqua);

            lblBlock3.Content = block3Task.Result;
            lblBlock3.Background = new SolidColorBrush(Colors.Aqua);

            lblBlock4.Content = block4Task.Result;
            lblBlock4.Background = new SolidColorBrush(Colors.Aqua);


            stopwatch.Stop();

            lblTotalTimeElapsed.Content = "Total Time: " + stopwatch.ElapsedMilliseconds;
        }
    }
}
