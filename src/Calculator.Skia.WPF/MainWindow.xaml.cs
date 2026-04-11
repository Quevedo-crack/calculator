using System.Windows;
using Calculator.Skia.WPF.ViewModels;

namespace Calculator.Skia.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) => (DataContext as CalculatorViewModel)?.Initialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is string cmd)
            {
                (DataContext as CalculatorViewModel)?.SendCommand(cmd);
            }
        }
    }
}
