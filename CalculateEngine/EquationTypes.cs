using System;
using System.Collections.Generic;

namespace CalculateEngine
{
    public class LinearEquation : Equation
    {
        public LinearEquation(float linearCoeff, float freeCoeff, char mathVar) : base(linearCoeff, freeCoeff, mathVar) { }
    }

    public class QuadraticEquation : Equation
    {
        internal float quadraticCoefficient;

        public QuadraticEquation(float quadraticCoeff, float linearCoeff, float freeCoeff, char mathVar)
            : base(linearCoeff, freeCoeff, mathVar)
        {
            quadraticCoefficient = quadraticCoeff;
        }

        internal static new (float, float, float) Decompose(string equation, char mathVar)
        {
            var eqTerms = new List<string>(equation.Split(' '));
            float quadraticCoeff = default, linearCoeff, freeCoeff;

            int qTermIndex = eqTerms.FindIndex(term => term.Contains(mathVar + "^2"));
            if (eqTerms[qTermIndex] == mathVar + "^2")
                quadraticCoeff = 1;
            else
                quadraticCoeff = Convert.ToSingle(eqTerms[qTermIndex][..^3]);

            eqTerms.RemoveAt(qTermIndex);
            equation = null;
            foreach (var term in eqTerms)
                equation += term;
            EquationController.TransformString(ref equation);

            (linearCoeff, freeCoeff) = Equation.Decompose(equation, mathVar);

            return (quadraticCoeff, linearCoeff, freeCoeff);
        }
    }
}
