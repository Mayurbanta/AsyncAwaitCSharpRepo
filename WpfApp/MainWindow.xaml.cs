using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
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

        private async void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            lblInformation.Content = await DosomethingAsync();

            var writeTask = WritetoFileAsync("ha ha ha !"); //starts executing in another thread from threadpool when this line executes
            await Task.Delay(10000);
            lblInformation.Content = "after delay is called";
            await writeTask;
        }

        #region Check when task get called

        private Task WritetoFileAsync(string text)
        {
            return Task.Run(() => Write(text));
        }

        private void Write(string text)
        {
            string path = @"d:\AsyncCheck.txt";

            if (File.Exists(path))
            {
                // Create a file to write to.
                File.WriteAllText(path, text);
            }

        }

        #endregion

        #region Example of how to get your method as Task
        private async Task<string> DosomethingAsync()
        {

            //await Task.Delay(5000);
            //return "some string";


            var t = TasktoGetString();

            //var a =    Task.WhenAll(t);
            //var result = a.Result.FirstOrDefault();
            var result = await t.ConfigureAwait(false);
            return result;

        }


        private Task<string> TasktoGetString()
        {
            //return Task.Run(() =>
            //{
            //    Debug.WriteLine("Debug Information-Product Starting ");
            //    return "string from task";
            //}
            //);


            return Task.Run<string>(() => MyMethod("method as task"));
        }


        private string MyMethod(string str)
        {
            return str + "...";
        }

        #endregion
    }
}
