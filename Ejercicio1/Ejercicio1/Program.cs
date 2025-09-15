namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su año de nacimiento:");
            string año = Console.ReadLine();
            int añonacimiento;
            int añoactual = DateTime.Now.Year;

            if (int.TryParse(año, out añonacimiento)) {
                int edad = añoactual-añonacimiento;
                Console.WriteLine($"Hola {nombre}, su edad es {edad} años.");
            }
            else {
                Console.WriteLine("Error, año invalido.");
            }
        }
    }
}
