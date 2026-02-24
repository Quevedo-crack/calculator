#include "CalcManagerWrapper.h"
#include <msclr/marshal_cppstd.h>

using namespace CalcManagerWrapper;
using namespace msclr::interop;

StandardCalculatorManagerWrapper::StandardCalculatorManagerWrapper()
{
    nativeManager = new CalculatorManager();
}

StandardCalculatorManagerWrapper::~StandardCalculatorManagerWrapper()
{
    delete nativeManager;
}

void StandardCalculatorManagerWrapper::Init()
{
    nativeManager->Initialize();   // confirma que existe en CalculatorManager
}

void StandardCalculatorManagerWrapper::ProcessCommand(String^ command)
{
    std::wstring cmd = marshal_as<std::wstring>(command);
    nativeManager->ProcessCommand(cmd);   // ajusta al nombre real del método
}

String^ StandardCalculatorManagerWrapper::GetDisplayText()
{
    std::wstring text = nativeManager->GetDisplayText();   // ajusta al nombre real del método
    return gcnew String(text.c_str());
}

void StandardCalculatorManagerWrapper::Clear()
{
    nativeManager->Clear();   // ajusta al nombre real del método
}
