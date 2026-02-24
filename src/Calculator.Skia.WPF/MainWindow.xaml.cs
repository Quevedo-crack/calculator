using CalcManagerWrapper;
using System.Windows;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private StandardCalculatorManagerWrapper manager;

        public MainWindow()
        {
            InitializeComponent();
            manager = new StandardCalculatorManagerWrapper();
            manager.Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cmd = (string)((System.Windows.Controls.Button)sender).Content;
            manager.ProcessCommand(cmd);
            Display.Text = manager.GetDisplayText();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            manager.Clear();
            Display.Text = "";
        }
    }
}
