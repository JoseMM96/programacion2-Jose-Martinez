using System;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de operaciones multiples:");
            Console.Write("Ingrese el primer numero: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese el segundo numero: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

        
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicacion");
            Console.WriteLine("4. Division");
            int opcion = Convert.ToInt32(Console.ReadLine());

            double resultado = 0;

            switch (opcion)
            {
                case 1:
                    resultado = Sumar(num1, num2);
                    Console.WriteLine($"El resultado es: {resultado}");
                    break;
                case 2:
                    resultado = Restar(num1, num2);
                    Console.WriteLine($"El resultado es: {resultado}");
                    break;
                case 3:
                    resultado = Multiplicar(num1, num2);
                    Console.WriteLine($"El resultado es: {resultado}");
                    break;
                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Divisor invalido.");
                    }
                    else
                    {
                        resultado = Dividir(num1, num2);
                        Console.WriteLine($"El resultado es: {resultado}");
                    }
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        }

 
    static double Sumar(double a, double b)
    {
    return a + b;
    }

    static double Restar(double a, double b)
    {
    return a - b;
    }

    static double Multiplicar(double a, double b)
    {
    return a * b;
    }

    static double Dividir(double a, double b)
    {
    return a / b;
    }
}
}
    

