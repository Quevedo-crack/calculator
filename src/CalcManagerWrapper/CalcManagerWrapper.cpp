#include "CalcManagerWrapper.h"

// Evitar conflicto entre COM y .NET IServiceProvider
#define WIN32_LEAN_AND_MEAN
#define NOMINMAX
#undef IServiceProvider

#include <windows.h>
#include <objbase.h>
#include <servprov.h>

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
