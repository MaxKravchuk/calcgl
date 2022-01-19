using System;
using Calculator;

namespace CalculatorPrj
{
    class Program
    {
        static void Main()
        {
            TurnOnCalculator();
        }

        static void TurnOnCalculator()
        {
            Calc c = new();
            while (true)
            {
                Console.WriteLine("Enter the expression separating each element with a space\nStop -> enter 0");
                Console.Write("Expression -> ");
                var expression = Console.ReadLine();
                if (expression.Contains('0')) break;
                try
                {
                    Console.WriteLine($"Result {expression} = {c.Result(expression)}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
