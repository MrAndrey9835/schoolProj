using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalculateEngine
{
    enum EquationType { Linear, Modulus, Parabola, Root, Hyperbola }

    public class Equation
    {
        internal EquationType type = default;
        internal int coeffVarSquared = 0;        //Коэфициент при переменной^2; null так как может отсутствовать
        internal int coeffVar = 0;               //Коэфициент при переменной
        internal int freeNumber = 0;
        internal char variable = default;

        public Equation(string equation, char usedVariable) 
        {
            variable = usedVariable;
            string[] EquationElements = equation.Split(' ');
            var EquationPatterns = new Dictionary<Regex, EquationType>
            {
                { new Regex(@"\d*\w ([\+|-] \d+ )?= 0"), EquationType.Linear },
                { new Regex(@"((\d*\|\w\||\|\d*\w\|) ([\+|-] \d+)?|\|\d*\w [\+|-] \d+\|) = 0"), EquationType.Modulus },
                { new Regex(@"√\w"), EquationType.Root },
                { new Regex(@"\d*\w\^2 ([\+|-] \d*\w )?([\+|-] \d+ )?= 0"), EquationType.Parabola }
            };                                                          //ДОДЕЛАТЬ

            foreach (var pattern in EquationPatterns.Keys)
                if (pattern.IsMatch(equation))
                {
                    type = EquationPatterns[pattern];
                    break;
                }

            switch (type)
            {
                case EquationType.Linear:
                    LinearEquationDecomposition(EquationElements);
                    break;
                case EquationType.Parabola:
                    //Метод
                    break;
            }
        }

        void LinearEquationDecomposition(string[] equationElements)
        {
            coeffVar = Convert.ToInt32(equationElements[0].Substring(0, equationElements[0].Length - 1));
            freeNumber = Convert.ToInt32(equationElements[1] + equationElements[2]);
        }
    }
}
