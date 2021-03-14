using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculateEngine
{
    class LinearEquation : Equation
    {
        static LinearEquation()
        {
            equationPattern = new Regex(@"\d*\w ([\+|-] \d+ )?= 0");
        }

        public LinearEquation(float coeffVar, float freeCoeff, char mathVar)
        {
            varCoefficient = coeffVar;
            freeCoefficient = freeCoeff;
            this.mathVar = mathVar;
        }
    }

    class ParabolaEquation : Equation
    {
        static ParabolaEquation()
        {
            equationPattern = new Regex(@"\d*\w\^2 ([\+|-] \d*\w )?([\+|-] \d+ )?= 0");
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
