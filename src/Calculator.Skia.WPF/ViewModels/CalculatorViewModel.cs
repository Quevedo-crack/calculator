using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalculationManager;

namespace Calculator.Skia.WPF.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged, ICalcDisplay
    {
        private CalculatorManager? _manager;
        private string _displayText = "0";
        private bool _isError;

        public string DisplayText { get => _displayText; private set { _displayText = value; OnPropertyChanged(); } }
        public bool IsError { get => _isError; private set { _isError = value; OnPropertyChanged(); } }

        public void Initialize()
        {
            _manager?.Dispose();
            _manager = new CalculatorManager(this);
            _manager.Reset(true);
        }

        public void SendCommand(string commandStr)
        {
            if (_manager == null) return;

            if (System.Enum.TryParse(commandStr, out Command cmd))
            {
                _manager.SendCommand(cmd);
                return;
            }

            switch (commandStr)
            {
                case "+": _manager.SendCommand(Command.Add); break;
                case "-": _manager.SendCommand(Command.Subtract); break;
                case "*": _manager.SendCommand(Command.Multiply); break;
                case "/": _manager.SendCommand(Command.Divide); break;
                case "=": _manager.SendCommand(Command.Equals); break;
                case "C": _manager.SendCommand(Command.Clear); break;
                case "CE": _manager.SendCommand(Command.ClearEntry); break;
                case "←": _manager.SendCommand(Command.Backspace); break;
                case "±": _manager.SendCommand(Command.Negate); break;
                case ".": _manager.SendCommand(Command.Decimal); break;
                case "√": _manager.SendCommand(Command.SquareRoot); break;
                case "%": _manager.SendCommand(Command.Percent); break;
                case "1/x": _manager.SendCommand(Command.Invert); break;
                default:
                    if (int.TryParse(commandStr, out int num) && num >= 0 && num <= 9)
                        _manager.SendCommand((Command)num);
                    break;
            }
        }

        public void SetMode(string mode)
        {
            if (_manager == null) return;
            switch (mode)
            {
                case "Standard": _manager.SetStandardMode(); break;
                case "Scientific": _manager.SetScientificMode(); break;
                case "Programmer": _manager.SetProgrammerMode(); break;
            }
        }

        // Implementación de ICalcDisplay
        public void SetPrimaryDisplay(string displayString, bool isError) { DisplayText = displayString; IsError = isError; }
        public void SetIsInError(bool isError) => IsError = isError;
        public void SetExpressionDisplay(List<(string, int)> tokens, List<object> commands) { }
        public void SetMemorizedNumbers(List<string> memorizedNumbers) { }
        public void OnHistoryItemAdded(uint addedItemIndex) { }
        public void SetParenthesisNumber(uint parenthesisCount) { }
        public void OnNoRightParenAdded() { }
        public void DisplayPasteError() { }
        public void MaxDigitsReached() { }
        public void BinaryOperatorReceived() { }
        public void MemoryItemChanged(uint indexOfMemory) { }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
