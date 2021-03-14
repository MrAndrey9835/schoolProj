using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateEngine
{
    public static class EquationController
    {
        //Создание уравнения
        public static Equation GetEquation(string stringEquation, char mathVariable)
        {
            Equation equation;
            if (LinearEquation.equationPattern.IsMatch(stringEquation))

                /*Проверять через IsMatch(stringEquation)
                 * Если true, парсить и создавать объект, который потом запихать в equation
                 */
            return equation;
        }
        //Определить методы для решения уравнения
        //Определить методы для определения типа уравнения /ПОПРАВКА: не уверен что необходимо
    }
}
