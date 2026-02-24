using System.Windows;
using CalcManager;

namespace Calculator.Skia.WPF
{
    public partial class MainWindow : Window
    {
        private StandardCalculatorManager _manager = new StandardCalculatorManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDigitClick(object sender, RoutedEventArgs e)
        {
            var digit = (string)((System.Windows.Controls.Button)sender).Content;
            _manager.SendCommand(Command.Digit0 + int.Parse(digit));
            Display.Text = _manager.DisplayValue;
        }

        private void OnOperatorClick(object sender, RoutedEventArgs e)
        {
            _manager.SendCommand(Command.Add);
            Display.Text = _manager.DisplayValue;
        }

        private void OnEqualsClick(object sender, RoutedEventArgs e)
        {
            _manager.SendCommand(Command.Equals);
            Display.Text = _manager.DisplayValue;
        }
    }
}
