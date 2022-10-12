using System;
using System.Collections;
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

namespace ASPMVCCoreMultiThread
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

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            execute();
        }
         int Fibonachi(int numb)
        {
            if (numb ==  0 || numb == 1) 
                return numb;

            return Fibonachi(numb - 1) + Fibonachi(numb - 2);
        }

        private void execute()
        {
            start.IsEnabled = false;
            var thread = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    var result = Fibonachi(i);
                    FibonText.Dispatcher.Invoke(() =>
                    {
                        FibonText.Text = result.ToString();
                    });
                    Thread.Sleep(5000);
                }
                start.Dispatcher.Invoke(() =>
                {
                    start.IsEnabled = true;
                });
            })
            {
                IsBackground = true
            };
            thread.Start();
        }
    }
}

