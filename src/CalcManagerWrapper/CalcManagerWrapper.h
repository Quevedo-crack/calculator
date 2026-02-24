#pragma once

// Incluye el header correcto del motor
#include "..\\CalcManager\\CalculatorManager.h"

using namespace System;

namespace CalcManagerWrapper
{
    public ref class StandardCalculatorManagerWrapper
    {
    private:
        CalculatorManager* nativeManager;  // Usar CalculatorManager

    public:
        StandardCalculatorManagerWrapper();
        ~StandardCalculatorManagerWrapper();

        void Init();
        void ProcessCommand(String^ command);
        String^ GetDisplayText();
        void Clear();
    };
}
