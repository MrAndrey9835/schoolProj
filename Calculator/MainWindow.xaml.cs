using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            string solution = null;
            Equation eq = EquationController.GetEquation(EquationTextBox.Text, variable);
            foreach (var sol in EquationController.GetSolution(eq))
                solution += sol + " ";
            solution = solution[0..^1];
            SolutionTextBox.Text = solution;
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
                    MessageBox.Show("Нельзя ввести больше одной переменной"); //Заменить
                    var newText = EquationTextBox.Text.ToList();
                    newText.RemoveAll(c => c == inputCharacter);              //!ДОДЕЛАТЬ
                    EquationTextBox.Clear();
                    foreach (var element in newText)
                        EquationTextBox.Text += element.ToString();
                    EquationTextBox.CaretIndex = EquationTextBox.Text.Length;
                }
            }
        }
    }
}