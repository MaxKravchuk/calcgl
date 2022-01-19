using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calc
    {
        private readonly List<int> addents;
        private readonly List<string> operations;

        public Calc()
        {
            addents = new List<int>();
            operations = new List<string>();
        }

        public int Result(string expression)
        {
            PrepareString(expression);
            Solve("*", (a, b) => a * b, "/", (a, b) => a / b);
            Solve("+", (a, b) => a + b, "-", (a, b) => a - b);

            return addents[0];
        }

        private void PrepareString(string expression)
        {
            addents.Clear();
            operations.Clear();

            if (expression.Length == 0) throw new ArgumentException("Pls enter expression");
            var parts = expression.Split(' ');

            for (var i = 0; i < parts.Length; i += 2)
            {
                addents.Add(Convert.ToInt32(parts[i]));
                if (i + 1 < parts.Length)
                {
                    if (!(parts[i + 1].Contains("+") || parts[i + 1].Contains("-")|| parts[i + 1].Contains("/") || parts[i + 1].Contains("*"))) throw new ArithmeticException("Wrong operation! Use \"+\" \"-\" \"*\" \"/\"");
                    operations.Add(parts[i + 1]);
                }
            }
        }

        private void Solve(string currentOperation1, Func<int, int, int> function1, string currentOperation2, Func<int, int, int> function2)
        {
            while (true)
            {

                var i1 = operations.IndexOf(currentOperation1);
                var i2 = operations.IndexOf(currentOperation2);

                int index;
                if (i1 >= 0 && i2 >= 0)
                {
                    index = Math.Min(i1, i2);
                }
                else
                {
                    index = Math.Max(i1, i2);
                }

                if (index < 0)
                {
                    break;
                }

                if (index == i1)
                {
                    addents[index] = function1(addents[index], addents[index + 1]);
                }
                else
                {
                    addents[index] = function2(addents[index], addents[index + 1]);
                }

                operations.RemoveAt(index);
                addents.RemoveAt(index + 1);
            }
        }
    }
}
