namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero entero:");
            string num = Console.ReadLine();
            int numeroentero;
            

            if (int.TryParse(num, out numeroentero))
            {
            string mensaje = "El numero";
                if (numeroentero < 0)
                {
                    mensaje += " es negativo";
                }
                else if (numeroentero == 0)
                {
                    mensaje += " es cero";
                }
                else
                {
                    mensaje += " es positivo";
                }


                if (numeroentero % 2 == 0)
                {
                    mensaje += ", es par";
                    if (numeroentero % 5 == 0)
                    {
                        mensaje += ", y es multiplo de 5.";
                    }
                    else
                    {
                        mensaje += ", y no es multiplo de 5.";
                    }
                }
                else
                {
                    mensaje += ", es impar";
                    if (numeroentero % 5 == 0)
                    {
                        mensaje += ", y es multiplo de 5.";
                    }
                    else
                    {
                        mensaje += ", y no es multiplo de 5.";
                    }
                }

                Console.WriteLine(mensaje);
            }
            else
            {
                Console.WriteLine("Error, numero entero invalido.");
            }

        }
    }
}
