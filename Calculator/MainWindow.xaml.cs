using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CalculateEngine;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char variable = default;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EquationTextBox.Text.Contains('=') || !EquationTextBox.Text.Contains(variable) || variable == default)
                return; 

            List<float> solution;
            if (string.Empty == EquationTextBox.Text)
                return;

            Equation eq = EquationController.GetEquation(EquationTextBox.Text, variable);

            solution = EquationController.GetSolution(eq);
            if (solution.Count == 1)
                SolutionTextBox.Text = Convert.ToString(solution[0]);
            else
            {
                foreach (var el in solution)
                    SolutionTextBox.Text += el + "; ";
                SolutionTextBox.Text = SolutionTextBox.Text.Remove(SolutionTextBox.Text.Length - 2);
            }
        }

        private void EquationTextBox_Input(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString().Length > 2)
                return;

            char inputCharacter = e.Key.ToString().ToLower()[^1];

            if (char.IsLetter(inputCharacter))
            {
                if (variable == default)
                    variable = inputCharacter;
                else if (!EquationTextBox.Text.Contains(variable))
                    variable = inputCharacter;
                else if (inputCharacter != variable)
                {
                    MessageBox.Show("Нельзя ввести больше одной переменной");
                    var newText = EquationTextBox.Text.ToList();
                    newText.RemoveAll(c => c == inputCharacter);
                    EquationTextBox.Clear();
                    foreach (var element in newText)
                        EquationTextBox.Text += element.ToString();
                    EquationTextBox.CaretIndex = EquationTextBox.Text.Length;
                }
            }
        }
    }
}