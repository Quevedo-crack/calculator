using System.Collections.Generic;

namespace CalculationManager
{
    public interface ICalcDisplay
    {
        void SetPrimaryDisplay(string displayString, bool isError);
        void SetIsInError(bool isError);
        void SetExpressionDisplay(List<(string, int)> tokens, List<object> commands);
        void SetMemorizedNumbers(List<string> memorizedNumbers);
        void OnHistoryItemAdded(uint addedItemIndex);
        void SetParenthesisNumber(uint parenthesisCount);
        void OnNoRightParenAdded();
        void DisplayPasteError();
        void MaxDigitsReached();
        void BinaryOperatorReceived();
        void MemoryItemChanged(uint indexOfMemory);
    }
}
