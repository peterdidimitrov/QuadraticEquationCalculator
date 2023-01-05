namespace QuadraticEquationCalculator
{
    using System;

    internal class QuadraticEquationCalculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //This output encoding displays the superscript '2' in Quadratic Equation
                Console.OutputEncoding = System.Text.Encoding.Unicode;

                //The user should enter three variables
                Console.WriteLine("ax² + bx + c = 0");
                Console.WriteLine("Enter three variables (a, b and c):");

                double firstVariable = double.Parse(Console.ReadLine());
                Console.WriteLine($"a = {firstVariable}");

                double secondVariable = double.Parse(Console.ReadLine());
                Console.WriteLine($"b = {secondVariable}");

                double thirdVariable = double.Parse(Console.ReadLine());
                Console.WriteLine($"c = {thirdVariable}");

                //Displaying the whole expression
                Console.WriteLine("The expression is:");
                Console.WriteLine($"{firstVariable}x² + {secondVariable}x + {thirdVariable} = 0");

                //This method finds the discriminant
                double discriminant = GetDiscriminant(firstVariable, secondVariable, thirdVariable);

                //Displaying the different result in different colours, depend of value of discriminant
                //Here I am using a method which finds the roots
                if (discriminant > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The discriminant of the quadratic equation is greater than 0.");
                    Console.WriteLine("It has two roots which are distinct and real numbers.");
                    Console.ResetColor();

                    var roots = GetRoot(firstVariable, secondVariable, discriminant);

                    Console.WriteLine($"The roots are: {roots}");
                }
                else if (discriminant < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The discriminant of the quadratic equation is less than 0.");
                    Console.WriteLine("It has two roots which are distinct and complex numbers (non-real).");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The discriminant of the quadratic equation is equal to 0.");
                    Console.WriteLine("It has two equal real roots.");
                    Console.ResetColor();

                    var root = GetRoot(firstVariable, secondVariable, discriminant);

                    Console.WriteLine($"The roots is: {root}");
                }
            }
        }

        static double GetDiscriminant(double a, double b, double c)
        {
            double result = b * b - 4 * a * c;
            return result;
        }
        static Tuple<double, double> GetRoot(double a, double b, double D)
        {
            if (D > 0)
            {
                double firstResult = (-b + Math.Sqrt(D)) / 2 * a;
                double secondResult = (-b - Math.Sqrt(D)) / 2 * a;
                return new Tuple<double, double>(firstResult, secondResult);
            }
            else
            {
                double result = (-b + Math.Sqrt(D)) / 2 * a;
                return new Tuple<double, double>(result, result);
            }
        }
    }
}