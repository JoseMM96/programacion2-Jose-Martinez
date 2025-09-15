namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la temperatura en grados Celsius:");
            string temp = Console.ReadLine();
            double tempC;
            double tempF;

            if (double.TryParse(temp, out tempC))
            {
                tempF = 32 + (tempC * 9) / 5;
                Console.WriteLine($"La temperatura en grados Fahrenheit es {tempF}");
            }
            else
            {
                Console.WriteLine("Error, la temperatura ingresada es invalida");
            }
        }
    }
}
