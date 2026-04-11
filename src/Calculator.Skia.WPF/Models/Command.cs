namespace CalculationManager
{
    public enum Command
    {
        // Números
        Command0 = 0, Command1 = 1, Command2 = 2, Command3 = 3, Command4 = 4,
        Command5 = 5, Command6 = 6, Command7 = 7, Command8 = 8, Command9 = 9,
        // Operadores
        Add = 10, Subtract = 11, Multiply = 12, Divide = 13, Equals = 14,
        // Memoria
        MC = 15, MR = 16, MS = 17, MPlus = 18, MMinus = 19,
        // Acciones
        Clear = 20, ClearEntry = 21, Backspace = 22, Negate = 23, Decimal = 24,
        SquareRoot = 25, Percent = 26, Invert = 27,
        // Modos
        Standard = 28, Scientific = 29, Programmer = 30,
        // Científicas (puedes añadir más)
        Sin = 31, Cos = 32, Tan = 33, Log = 34, Ln = 35, Exp = 36, Factorial = 37, Pi = 38, E = 39, Degree = 40, Radian = 41,
        // Programador
        And = 42, Or = 43, Xor = 44, Not = 45, Lsh = 46, Rsh = 47, Hex = 48, Dec = 49, Oct = 50, Bin = 51,
        Qword = 52, Dword = 53, Word = 54, Byte = 55,
        // Historial
        HistoryClear = 56, HistoryItemSelected = 57,
    }
}
