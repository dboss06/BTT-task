using System;
partial class Program
{
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {

            Console.WriteLine("Select what you want to Calculate:  option (1-4): \n1. Quadratic Equation \n2. Area Of A Circle \n3. Pythagoras Theorem \n4. Exit ");
            string? userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Input number: ");
                    double.TryParse(Console.ReadLine(), out double D);
                    Console.WriteLine("Input the second number: ");
                    double.TryParse(Console.ReadLine(), out double E);
                    Console.WriteLine("Input the third number: ");
                    double.TryParse(Console.ReadLine(), out double F);

                    QuadEqn(D, E, F);
                    break;
                case "2":

                    Console.WriteLine("Input Radius: ");
                    double.TryParse(Console.ReadLine(), out double radius);

                    double Area = AreaCircle(radius);
                    Console.WriteLine(Area);
                    break;
                case "3":
                    Console.WriteLine("Input first number: ");
                    double.TryParse(Console.ReadLine(), out double A);
                    Console.WriteLine("Input second number: ");
                    double.TryParse(Console.ReadLine(), out double B);

                    double C = PythTheorem(A, B);
                    Console.WriteLine(C);
                    break;
                case "4":
                    return;

            }
            Console.WriteLine("Do you want to go again(Y/N): ");
            string? userInput = Console.ReadLine();

            if (userInput?.Trim().ToUpper() == "N")
            {
                isRunning = false;
                Console.WriteLine("Thank you for using the stuff");
            }
        }


    }

    static void QuadEqn(double a, double b, double c)
    {
        double discriminant = Math.Pow(b, 2) - (4 * a * c);

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            Console.WriteLine($"Two Real Roots: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);

            Console.WriteLine($"The Real Roots: x = {x}");
        }
        else
        {
            Console.WriteLine($"No Real Root cause the discriminant {discriminant} is < 0");
        }
    }


    static double AreaCircle(double r)
    {
        double Area = Math.PI * Math.Pow(r, 2);
        return Area;
    }
    static double PythTheorem(double a, double b)
    {
        double result = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        return result;
    }
}
