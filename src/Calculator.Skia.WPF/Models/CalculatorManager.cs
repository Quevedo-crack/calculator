using System;
using System.Runtime.InteropServices;

namespace CalculationManager
{
    public class CalculatorManager : IDisposable
    {
        private IntPtr _nativePtr;
        private readonly CalcDisplayCallback _callbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void CalcDisplayCallback(int callbackType, IntPtr data, int intParam, bool boolParam);

        [DllImport("CalcManager.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CalculatorManager_Create(CalcDisplayCallback callback);

        [DllImport("CalcManager.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CalculatorManager_Destroy(IntPtr manager);

        [DllImport("CalcManager.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CalculatorManager_SendCommand(IntPtr manager, int command);

        [DllImport("CalcManager.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CalculatorManager_SetStandardMode(IntPtr manager);

        [DllImport("CalcManager.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CalculatorManager_SetScientificMode(IntPtr manager);

        [DllImport("CalcManager.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CalculatorManager_SetProgrammerMode(IntPtr manager);

        [DllImport("CalcManager.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CalculatorManager_Reset(IntPtr manager, [MarshalAs(UnmanagedType.Bool)] bool clearMemory);

        public CalculatorManager(ICalcDisplay display)
        {
            _callbackDelegate = (type, data, intParam, boolParam) =>
            {
                switch ((CallbackType)type)
                {
                    case CallbackType.SetPrimaryDisplay:
                        string str = Marshal.PtrToStringUni(data) ?? "";
                        display.SetPrimaryDisplay(str, boolParam);
                        break;
                    case CallbackType.SetIsInError:
                        display.SetIsInError(boolParam);
                        break;
                    // Otros callbacks se pueden añadir si son necesarios
                }
            };
            _nativePtr = CalculatorManager_Create(_callbackDelegate);
        }

        public void SendCommand(Command cmd) => CalculatorManager_SendCommand(_nativePtr, (int)cmd);
        public void SetStandardMode() => CalculatorManager_SetStandardMode(_nativePtr);
        public void SetScientificMode() => CalculatorManager_SetScientificMode(_nativePtr);
        public void SetProgrammerMode() => CalculatorManager_SetProgrammerMode(_nativePtr);
        public void Reset(bool clearMemory = true) => CalculatorManager_Reset(_nativePtr, clearMemory);

        public void Dispose()
        {
            if (_nativePtr != IntPtr.Zero)
            {
                CalculatorManager_Destroy(_nativePtr);
                _nativePtr = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }

        private enum CallbackType
        {
            SetPrimaryDisplay = 0,
            SetIsInError = 1,
            SetExpressionDisplay = 2,
            SetMemorizedNumbers = 3,
            OnHistoryItemAdded = 4,
            SetParenthesisNumber = 5,
            OnNoRightParenAdded = 6,
            DisplayPasteError = 7,
            MaxDigitsReached = 8,
            BinaryOperatorReceived = 9,
            MemoryItemChanged = 10,
        }
    }
}
