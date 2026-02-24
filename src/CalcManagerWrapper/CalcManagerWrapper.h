#pragma once
using namespace System;

class StandardCalculatorManager; // forward declaration

namespace CalcManagerWrapper
{
    public ref class StandardCalculatorManagerWrapper
    {
    private:
        StandardCalculatorManager* nativeManager;

    public:
        StandardCalculatorManagerWrapper();
        ~StandardCalculatorManagerWrapper();

        void Init();
        void ProcessCommand(String^ command);
        String^ GetDisplayText();
        void Clear();
    };
}
