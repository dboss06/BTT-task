using System;

namespace Task1
{

    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Enter a figure");
            double.TryParse(Console.ReadLine(), out double A);
            Console.WriteLine("Enter a second figure");
            double.TryParse(Console.ReadLine(), out double b);

            Console.WriteLine("Enter a third figure");
            double.TryParse(Console.ReadLine(), out double D);

            Console.WriteLine("Enter a fourth figure");
            double.TryParse(Console.ReadLine(), out double T);
            Console.WriteLine("Enter a fifth figure");
            double.TryParse(Console.ReadLine(), out double C);

            double myresult = MyEqn(A, b, D, T, C);
            Console.WriteLine(myresult);
        }

        static double MyEqn(double a, double b, double d, double t, double c)
        {
            double numerator = (Math.Sqrt((a * b) / (2.0 * d)) * 3) - Math.Sqrt(Math.Pow(Math.Sqrt(t * c) / (2.0 * d), 2));

            double denominator = 4 * a * c;

            double result = numerator / denominator;
            return result;

        }
        
    }



}