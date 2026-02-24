#define WIN32_LEAN_AND_MEAN
#include "CalcManagerWrapper.h"
#include <msclr/marshal_cppstd.h>

using namespace CalcManagerWrapper;
using namespace msclr::interop;

StandardCalculatorManagerWrapper::StandardCalculatorManagerWrapper()
{
    nativeManager = new CalculatorManager();  // Usar CalculatorManager
}

StandardCalculatorManagerWrapper::~StandardCalculatorManagerWrapper()
{
    delete nativeManager;
}

void StandardCalculatorManagerWrapper::Init()
{
    nativeManager->Initialize();  // Verifica que el método exista en CalculatorManager
}

void StandardCalculatorManagerWrapper::ProcessCommand(String^ command)
{
    std::wstring cmd = marshal_as<std::wstring>(command);
    nativeManager->ProcessCommand(cmd);  // Ajusta al nombre real del método
}

String^ StandardCalculatorManagerWrapper::GetDisplayText()
{
    std::wstring text = nativeManager->GetDisplayText();  // Ajusta al nombre real del método
    return gcnew String(text.c_str());
}

void StandardCalculatorManagerWrapper::Clear()
{
    nativeManager->Clear();  // Ajusta al nombre real del método
}
