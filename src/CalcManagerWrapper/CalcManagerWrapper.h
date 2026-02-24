#pragma once

using namespace System;

namespace CalcManagerWrapper
{
    public ref class StandardCalculatorManagerWrapper
    {
    public:
        StandardCalculatorManagerWrapper();
        void Init();
        int Add(int a, int b);
    };
}
