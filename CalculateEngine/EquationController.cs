using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateEngine
{
    public static class EquationController
    {
        //Создание уравнения
        public static Equation GetEquation(string equation, char mathVariable)
        {
            Equation result = null;
            float linearCoeff;
            float freeCoeff;
            equation = RemoveWhitespaceAfterSigns(equation);
            List<string> equationElements = new List<string>(equation.Split(' '));



            return result;
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

        public static List<float> GetSolution(Equation eq)
        {
            List<float> solution = new List<float>();

            if (eq is LinearEquation)
                solution.Add(-eq.freeCoefficient / eq.linearCoefficient);
            else if (eq is QuadraticEquation)
            {
                var quadEq = eq as QuadraticEquation;
                float sqrtOfDiscriminant = (float)Math.Sqrt(Math.Pow(quadEq.linearCoefficient, 2) - 4 * quadEq.quadraticCoefficient * quadEq.freeCoefficient);
                solution.Add((-quadEq.freeCoefficient + sqrtOfDiscriminant) / (2 * quadEq.quadraticCoefficient));
                solution.Add((-quadEq.freeCoefficient - sqrtOfDiscriminant) / (2 * quadEq.quadraticCoefficient));
            }

            return solution;
        }
        //Определить методы для решения уравнения
        //Определить методы для определения типа уравнения /ПОПРАВКА: не уверен что необходимо
    }
}
