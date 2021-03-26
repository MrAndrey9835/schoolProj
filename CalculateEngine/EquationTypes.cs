using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculateEngine
{
    class LinearEquation : Equation
    {
        internal static readonly Regex EquationPattern = new Regex(@"[-]?\d*\w ([\+|-] \d+ )?= 0");

        public LinearEquation(float linearCoeff, float freeCoeff, char mathVar) : base(linearCoeff, freeCoeff, mathVar) { }
    }

    class QuadraticEquation : Equation
    {
        internal float quadraticCoefficient;
        internal static readonly Regex EquationPattern = new Regex(@"[-]?\d*\w\^2 ([\+|-] \d*\w )?([\+|-] \d+ )?= 0");

        public QuadraticEquation(float quadraticCoeff, float linearCoeff, float freeCoeff, char mathVar)
            : base(linearCoeff, freeCoeff, mathVar)
        {
            quadraticCoefficient = quadraticCoeff;
        }

        internal static (float, float, float) Decompose(string equation)
        {
            string[] equationElements = equation.Split(' ');
            float quadraticCoeff = Convert.ToSingle(equationElements[0][0..^3]);
            float linearCoeff, freeCoeff;
            (linearCoeff, freeCoeff) = Decompose(equation, mathVarElementIndex: 1);
            return (quadraticCoeff, linearCoeff, freeCoeff);
        }
    }

    /*class HyperbolaEquation : Equation
    {

    }

    class RootEquation : Equation
    {

    }

    class ModulusEquation : Equation
    {

    }*/
}
