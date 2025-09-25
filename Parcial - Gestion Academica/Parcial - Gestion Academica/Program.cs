using Parcial___Gestion_Academica;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcial___Gestion_Academica
{
    internal class Program
    {
        static List<Profesor> profesores = new List<Profesor>();
        static List<Estudiante> estudiantes = new List<Estudiante>();
        static List<Curso> cursos = new List<Curso>();

        static void Main(string[] args)
        {
            RegistroPersonas();

            int opcion;
            do
            {
                Console.WriteLine("\n--- Sistema de Gestion Academica ---");
                Console.WriteLine("1. Mostrar profesores activos");
                Console.WriteLine("2. Mostrar estudiates activos");
                Console.WriteLine("3. Registrar notas");
                Console.WriteLine("4. Mostrar informacion de los cursos");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        foreach (var prof in profesores)
                            prof.MostrarInformacion();
                        break;

                    case 2:
                        foreach (var est in estudiantes)
                            est.MostrarInformacion();
                        break;

                    case 3:
                        RegistrarNota();
                        break;

                    case 4:
                        MostrarCurso();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Seleccione una opcion valida");
                        break;
                }

            } while (opcion != 0);
        }

        static void RegistroPersonas()
        {
            var prof1 = new Profesor { Nombre = "Ing. Jose Martinez", Dpi = "12121212121212", Correo = "josem@upana.edu.gt", Especialidad = "Matematica Aplicada" };
            var prof2 = new Profesor { Nombre = "Ing. Mario Martinez", Dpi = "3434343434343", Correo = "mariom@upana.edu.gt", Especialidad = "Ingenieria de Software" };
            profesores.AddRange(new[] { prof1, prof2 });

            var est1 = new Estudiante { Nombre = "Jose Perez", Dpi = "1111111111111", Correo = "josep@upana.edu.gt", Carnet = "20250001" };
            var est2 = new Estudiante { Nombre = "Juan Marroquin", Dpi = "2222222222222", Correo = "juanm@upana.edu.gt", Carnet = "20250002" };
            var est3 = new Estudiante { Nombre = "Luis Mendoza", Dpi = "3333333333333", Correo = "luism@upana.edu.gt", Carnet = "20250003" };
            var est4 = new Estudiante { Nombre = "Mario Castellanos", Dpi = "4444444444444", Correo = "marioc@upana.edu.gt", Carnet = "20250004" };
            estudiantes.AddRange(new[] { est1, est2, est3, est4 });

            var curso1 = new Curso { Codigo = "101", Nombre = "Matematica" };
            var curso2 = new Curso { Codigo = "102", Nombre = "Programacion" };
            var curso3 = new Curso { Codigo = "103", Nombre = "Fisica General" };
            cursos.AddRange(new[] { curso1, curso2, curso3 });

            curso1.AsignarProfesor(prof1);
            curso2.AsignarProfesor(prof2);
            curso3.AsignarProfesor(prof1);
            curso1.AgregarEstudiante(est1);
            curso1.AgregarEstudiante(est2);
            curso2.AgregarEstudiante(est2);
            curso2.AgregarEstudiante(est3);
            curso2.AgregarEstudiante(est4);
            curso3.AgregarEstudiante(est1);
            curso3.AgregarEstudiante(est4);
        }

        static void RegistrarNota()
        {
            Console.Write("Ingrese nombre del curso: ");
            string nombreCurso = Console.ReadLine();

            var curso = cursos.FirstOrDefault(c => c.Nombre.Equals(nombreCurso, StringComparison.OrdinalIgnoreCase));
            if (curso == null)
            {
                Console.WriteLine("Curso no encontrado.");
                return;
            }

            Console.Write("Ingrese carnet del estudiante: ");
            string carnet = Console.ReadLine();

            var estudiante = curso.Estudiantes.FirstOrDefault(e => e.Carnet == carnet);
            if (estudiante == null)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            Console.Write("Ingrese nota: ");
            if (float.TryParse(Console.ReadLine(), out float nota))
            {
                curso.RegistrarNota(estudiante, nota);
                Console.WriteLine("Nota registrada exitosamente.");
            }
            else
            {
                Console.WriteLine("Ingrese una nota valida.");
            }
        }


        static void MostrarCurso()
        {
            Console.WriteLine("\n--- Cursos activos ---");
            foreach (var curso in cursos)
            {
                Console.WriteLine($"- {curso.Nombre}");
            }

            Console.Write("\nIngrese el nombre del curso: ");
            string nombreCurso = Console.ReadLine();

            var cursoSeleccionado = cursos.FirstOrDefault(c =>
                c.Nombre.Equals(nombreCurso, StringComparison.OrdinalIgnoreCase));

            if (cursoSeleccionado == null)
            {
                Console.WriteLine(" Nombre del curso no encontrado");
                return;
            }

            Console.WriteLine($"\nCurso: {cursoSeleccionado.Nombre}");

            if (cursoSeleccionado.Profesor != null)
            {
                Console.WriteLine($"Profesor: {cursoSeleccionado.Profesor.Nombre} (Especialidad: {cursoSeleccionado.Profesor.Especialidad})");
            }
            else
            {
                Console.WriteLine("Profesor:");
            }

            Console.WriteLine($"Estudiantes inscritos: {cursoSeleccionado.Estudiantes.Count}");

            if (cursoSeleccionado.Estudiantes.Count == 0)
            {
                Console.WriteLine(" No hay estudiantes inscritos. ");
            }
            else
            {
                foreach (var est in cursoSeleccionado.Estudiantes)
                {
                    string nota = est.Notas.ContainsKey(cursoSeleccionado.Nombre)
                        ? est.Notas[cursoSeleccionado.Nombre].ToString("F2")
                        : " 0 ";

                    Console.WriteLine($"- {est.Nombre} (Carnet: {est.Carnet}) - Nota: {nota}");
                }
            }

            float promedio = cursoSeleccionado.CalcularPromedio();
            Console.WriteLine($"\nPromedio del curso: {promedio:F2}");
        }

    }

    public class Curso
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Profesor Profesor { get; set; }
        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        public void AsignarProfesor(Profesor p)
        {
            Profesor = p;
            p.CursosAsignados.Add(this);
        }

        public void AgregarEstudiante(Estudiante e)
        {
            Estudiantes.Add(e);
        }

        public void RegistrarNota(Estudiante e, float nota)
        {
            if (!Estudiantes.Contains(e))
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }
            e.Notas[Nombre] = nota;
        }

        public float CalcularPromedio()
        {
            var notas = Estudiantes
                .Where(e => e.Notas.ContainsKey(Nombre))
                .Select(e => e.Notas[Nombre])
                .ToList();

            return notas.Count == 0 ? 0 : notas.Average();
        }
    }


    public class Persona
    {
        public string Nombre { get; set; }
        public string Dpi { get; set; }
        public string Correo { get; set; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre:{Nombre}, DPI: {Dpi}, Correo: {Correo}");
        }
    }

    public class Estudiante : Persona
    {
        public string Carnet { get; set; }
        public Dictionary<string, float> Notas { get; set; } = new Dictionary<string, float>();

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Carnet: {Carnet}");
            foreach (var nota in Notas)
            {
                Console.WriteLine($"Curso: {nota.Key}, Nota: {nota.Value}");
            }
        }
    }

    public class Profesor : Persona
    {
        public string Especialidad { get; set; }
        public List<Curso> CursosAsignados { get; set; } = new List<Curso>();

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Especialidad: {Especialidad}");
        }
    }

}



