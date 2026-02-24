#pragma once
using namespace System;

namespace CalcManagerWrapper
{
    public ref class StandardCalculatorManagerWrapper
    {
    public:
        StandardCalculatorManagerWrapper();
        void Init();
        double Add(double a, double b);
    };
}
