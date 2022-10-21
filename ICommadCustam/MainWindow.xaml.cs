using ICommadCustam.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ICommadCustam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        RelayCommand _Click;
        public ICommand Click
        {
            get
            {
                if (_Click == null)
                    _Click = new RelayCommand(ExecuteClickCommand, CanExecuteClickCommand);
                return _Click;
            }
        }

        private bool CanExecuteClickCommand(object obj)//кнопка будет доступна только тогда, когда поля будут введены 
        {
            return true;
        }

        public void ExecuteClickCommand(object parameter) 
        {
            MessageBox.Show($"Button Click: {parameter}" );
        }
    }
}
