#include "CalcManagerWrapper.h"
#include "..\\CalcManager\\CalculatorManager.h"  // cabecera nativa

using namespace CalcManagerWrapper;

StandardCalculatorManagerWrapper::StandardCalculatorManagerWrapper()
{
    // Inicialización del motor nativo si hace falta
}

void StandardCalculatorManagerWrapper::Init()
{
    // Aquí llamarías a la inicialización real del motor nativo
    // Ejemplo: StandardCalculatorManager::Initialize();
}

double StandardCalculatorManagerWrapper::Add(double a, double b)
{
    // Ejemplo simple: en realidad deberías llamar a la función nativa
    return a + b;
}
