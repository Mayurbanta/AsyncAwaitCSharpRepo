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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TaskCancellationProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CancellationTokenSource _tokenSource = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnProcessAsync_Click(object sender, RoutedEventArgs e)
        {
            lblStatus.Content = "in progress...";
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            lstItems.Items.Clear();
            _progressBar.Equals(0);


            try
            {
                await LongProcessAsync(token);
            }
            catch (OperationCanceledException )
            {

                lblStatus.Content = "Operation Cancelled";
            }
            finally
            {
                _tokenSource.Dispose();
            }
           
        }

        private  void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            lstItems.Items.Clear();
            _progressBar.Equals(0);
            LongProcess();
        }

        private Task LongProcessAsync(CancellationToken token)
        {
            IProgress<double> progress = new Progress<double>(UpdateProgressText);

            return Task.Run(() =>
            {
                int maxRecords = 1000000;

                for (int i = 0; i < maxRecords; i++)
                {
                    if (i % 1000 == 0)
                    {
                        double percentage = (double)i / maxRecords;
                        progress.Report(percentage);
                    }

                    if (token.IsCancellationRequested)
                    {
                        //return;
                        token.ThrowIfCancellationRequested();
                    }

                    //Dispatcher is used to update UI thread from seconday threads
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lstItems.Items.Add(i.ToString());

                    }), DispatcherPriority.Background);

                }

            });
        }

        private void LongProcess()
        {
            IProgress<double> progress = new Progress<double>(UpdateProgressText);

            
                int maxRecords = 1000000;

                for (int i = 0; i < maxRecords; i++)
                {
                    if (i % 1000 == 0)
                    {
                        double percentage = (double)i / maxRecords;
                        progress.Report(percentage);
                    }

                        lstItems.Items.Add(i.ToString());
                }
        }

        public void UpdateProgressText(double percentage)
        {
            _progressBar.Value = percentage;
            _progressText.Text = (percentage).ToString("0%");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _tokenSource?.Cancel();
        }
    }
}
