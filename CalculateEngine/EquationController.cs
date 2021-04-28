using System;
using System.Collections.Generic;

namespace CalculateEngine
{
    public static class EquationController
    {
        public static Equation GetEquation(string equation, char mathVariable)
        {
            Equation result = default;
            float linearCoeff = default;
            float freeCoeff = default;
            TransformString(ref equation);

            if (GetEquationType(equation) == typeof(QuadraticEquation))
            {
                float quadraticCoeff = default;
                (quadraticCoeff, linearCoeff, freeCoeff) = QuadraticEquation.Decompose(equation, mathVariable);
                result = new QuadraticEquation(quadraticCoeff, linearCoeff, freeCoeff, mathVariable);
            }
            else
            {
                (linearCoeff, freeCoeff) = Equation.Decompose(equation, mathVariable);
                result = new LinearEquation(linearCoeff, freeCoeff, mathVariable);
            }

            return result;
        }

        internal static void TransformString(ref string equation)   //Приводит строку к формату: "x +2 =0"
        {
            List<char> eqElements = new List<char>(equation);
            equation = null;
            for (int i = 0; i < eqElements.Count; ++i)
            {
                if (eqElements[i] == '+' || eqElements[i] == '-' || eqElements[i] == '=')
                {
                    if (i != 0 && !char.IsWhiteSpace(eqElements[i - 1]))
                        eqElements.Insert(i, ' ');
                    else if (char.IsWhiteSpace(eqElements[i + 1]))
                        eqElements.RemoveAt(i + 1);
                    else if (i - 1 == 0 && char.IsWhiteSpace(eqElements[i - 1]))
                        eqElements.RemoveAt(i - 1);
                }
            }

            foreach (var symbol in eqElements)
                equation += symbol;
        }

        public static Type GetEquationType(string eq)
        {
            return eq.Contains("^2") ? typeof(QuadraticEquation) : typeof(LinearEquation);
        }

        public static List<float> GetSolution(Equation eq)
        {
            List<float> solution = new List<float>();

            if (eq is LinearEquation)
                solution.Add(-eq.freeCoefficient / eq.linearCoefficient);
            else if (eq is QuadraticEquation)
            {
                var quadEq = eq as QuadraticEquation;
                float sqrtOfDiscriminant = (float)
                    Math.Sqrt(Math.Pow(quadEq.linearCoefficient, 2) - 4 * quadEq.quadraticCoefficient * quadEq.freeCoefficient);
                solution.Add((-quadEq.freeCoefficient + sqrtOfDiscriminant) / (2 * quadEq.quadraticCoefficient));
                solution.Add((-quadEq.freeCoefficient - sqrtOfDiscriminant) / (2 * quadEq.quadraticCoefficient));
            }

            if (solution.Contains(0f))
                solution = new List<float> { 0f };

            return solution;
        }
    }
}
