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
            Equation equation = null;
            float linearCoeff;
            float freeCoeff;
            stringEquation = RemoveWhitespaceAfterSigns(stringEquation);

            if (LinearEquation.EquationPattern.IsMatch(stringEquation))
            {
                (linearCoeff, freeCoeff) = LinearEquation.Decompose(stringEquation);
                equation = new LinearEquation(linearCoeff, freeCoeff, mathVariable);
            }
            else if (QuadraticEquation.EquationPattern.IsMatch(stringEquation))
            {
                float quadraticCoeff;
                (quadraticCoeff, linearCoeff, freeCoeff) = QuadraticEquation.Decompose(stringEquation);
                equation = new QuadraticEquation(quadraticCoeff, linearCoeff, freeCoeff, mathVariable);
            }

            return equation;
        }

        private static string RemoveWhitespaceAfterSigns(string equation)     //x^2 - 4x + 7 = 0 → x^2 -4x +7 = 0
        {
            List<char> equationElements = new List<char>(equation);
            equation = "";
            for (int i = 0; i < equationElements.Count; ++i)
            {
                if ((equationElements[i] == '+' || equationElements[i] == '-') && char.IsWhiteSpace(equationElements[i + 1]))
                    equationElements.RemoveAt(i + 1);
                equation += equationElements[i];
            }

            return equation;
        }
        //Определить методы для решения уравнения
        //Определить методы для определения типа уравнения /ПОПРАВКА: не уверен что необходимо
    }
}
