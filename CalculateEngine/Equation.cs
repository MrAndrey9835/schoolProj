﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalculateEngine
{
    public abstract class Equation
    {
        internal float linearCoefficient;
        internal float freeCoefficient;             //Коэффициент при переменной; Свободный коэф
        internal char mathVar;                      //Буковка в кач-ве переменной

        protected Equation(float linearCoeff, float freeCoeff, char mathVar)
        {
            linearCoefficient = linearCoeff;
            freeCoefficient = freeCoeff;
            this.mathVar = mathVar;
        }

        internal static (float, float) Decompose(string equation, int mathVarElementIndex = 0)
        {                                                        //↑Индекс элемента массива, где находится переменная
            string[] equationElements = equation.Split(' ');
            float linearCoeff = 0;
            float freeCoeff = 0;
            try
            {
                linearCoeff = Convert.ToSingle(equationElements[mathVarElementIndex][0..^1]);
                freeCoeff = Convert.ToSingle(equationElements[mathVarElementIndex + 1]);
            }
            finally { }
            return (linearCoeff, freeCoeff);
        }
    }
}
