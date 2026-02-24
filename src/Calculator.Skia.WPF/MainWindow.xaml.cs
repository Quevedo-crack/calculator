using CalcManagerWrapper;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var manager = new StandardCalculatorManagerWrapper();
        manager.Init();
        double result = manager.Add(5, 7);
        MessageBox.Show($"Resultado: {result}");
    }
}
