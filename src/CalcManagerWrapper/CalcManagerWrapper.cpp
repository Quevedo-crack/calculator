#include "CalcManagerWrapper.h"

// Evitar conflicto con IServiceProvider de .NET
#undef IServiceProvider

#include "..\\CalcManager\\CalculatorManager.h"
#include <msclr/marshal_cppstd.h>

using namespace CalcManagerWrapper;
using namespace msclr::interop;

StandardCalculatorManagerWrapper::StandardCalculatorManagerWrapper()
{
    nativeManager = new StandardCalculatorManager();
}

StandardCalculatorManagerWrapper::~StandardCalculatorManagerWrapper()
{
    delete nativeManager;
}

void StandardCalculatorManagerWrapper::Init()
{
    nativeManager->Initialize();
}

void StandardCalculatorManagerWrapper::ProcessCommand(String^ command)
{
    std::wstring cmd = marshal_as<std::wstring>(command);
    nativeManager->ProcessCommand(cmd);
}

String^ StandardCalculatorManagerWrapper::GetDisplayText()
{
    std::wstring text = nativeManager->GetDisplayText();
    return gcnew String(text.c_str());
}

void StandardCalculatorManagerWrapper::Clear()
{
    nativeManager->Clear();
}
