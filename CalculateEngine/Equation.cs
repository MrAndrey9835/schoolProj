using System;
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

        internal static (float, float) Decompose(string equation, char mathVar)
        {
            string[] eqTerms = equation.Split(' ');
            float linearCoeff = default;
            float freeCoeff = default;
            
            foreach (var term in eqTerms)
            {
                if (term.Contains(mathVar))
                {
                    if (term[0] == mathVar)     //x +4 =0; Перед x ничего нет
                        linearCoeff = 1;
                    else
                        linearCoeff = Convert.ToSingle(term[..^1]);
                }
                else if (!term.Contains('=') && !term.Contains(mathVar))
                    freeCoeff = Convert.ToSingle(term);
            }

            return (linearCoeff, freeCoeff);
        }
    }
}
