using System;
using System.Collections.Generic;

class Program
{
    // Lista de libros
    static List<Libro> libros = new List<Libro>()
    {
        new Libro("Cien años de soledad", "Gabriel García Márquez", 1967, "Realismo mágico en Latinoamérica."),
        new Libro("El Quijote", "Miguel de Cervantes", 1605, "Historia de un caballero loco."),
        new Libro("Harry Potter", "J.K. Rowling", 1997, "Un joven mago descubre su destino."),
        new Libro("La Odisea", "Homero", -800, "El viaje de Odiseo."),
        new Libro("El principito", "Antoine de Saint-Exupéry", 1943, "Reflexión filosófica infantil.")
    };

    static List<string> autoresOrdenados = new List<string>()
    {
        "Antoine de Saint-Exupéry",
        "Gabriel García Márquez",
        "Homero",
        "J.K. Rowling",
        "Miguel de Cervantes"
    };

    static void Main()
    {
        int opcion = 0;

        while (opcion != 5)
        {
            Console.WriteLine("\n--- Sistema de Búsqueda Biblioteca Digital ---");
            Console.WriteLine("1. Búsqueda lineal de libro");
            Console.WriteLine("2. Búsqueda binaria de autor");
            Console.WriteLine("3. Libro más reciente y más antiguo");
            Console.WriteLine("4. Buscar palabra en descripción");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    BuscarLibroLineal();
                    break;
                case 2:
                    BuscarAutorBinario();
                    break;
                case 3:
                    BuscarRecienteAntiguo();
                    break;
                case 4:
                    BuscarEnDescripcion();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    // ✅ Búsqueda lineal de libros
    static void BuscarLibroLineal()
    {
        Console.Write("\nIngrese el título del libro: ");
        string titulo = Console.ReadLine().ToLower();

        foreach (var libro in libros)
        {
            if (libro.Titulo.ToLower().Contains(titulo))
            {
                Console.WriteLine($"Encontrado: {libro.Titulo} ({libro.Anio})");
                return;
            }
        }

        Console.WriteLine("Libro no encontrado.");
    }

    // ✅ Búsqueda binaria de autores
    static void BuscarAutorBinario()
    {
        Console.Write("\nIngrese el autor: ");
        string autor = Console.ReadLine();

        int inicio = 0;
        int fin = autoresOrdenados.Count - 1;

        while (inicio <= fin)
        {
            int medio = (inicio + fin) / 2;

            int comparacion = string.Compare(autor, autoresOrdenados[medio], true);

            if (comparacion == 0)
            {
                Console.WriteLine($"Autor encontrado: {autoresOrdenados[medio]}");
                return;
            }
            else if (comparacion < 0)
            {
                fin = medio - 1;
            }
            else
            {
                inicio = medio + 1;
            }
        }

        Console.WriteLine("Autor no encontrado.");
    }

    // ✅ Libro más reciente y más antiguo
    static void BuscarRecienteAntiguo()
    {
        Libro reciente = libros[0];
        Libro antiguo = libros[0];

        foreach (var libro in libros)
        {
            if (libro.Anio > reciente.Anio)
                reciente = libro;
            if (libro.Anio < antiguo.Anio)
                antiguo = libro;
        }

        Console.WriteLine($"\nLibro más reciente: {reciente.Titulo} ({reciente.Anio})");
        Console.WriteLine($"Libro más antiguo: {antiguo.Titulo} ({antiguo.Anio})");
    }

    // ✅ Búsqueda dentro de descripción
    static void BuscarEnDescripcion()
    {
        Console.Write("\nIngrese palabra a buscar: ");
        string palabra = Console.ReadLine().ToLower();

        bool encontrado = false;

        foreach (var libro in libros)
        {
            if (libro.Descripcion.ToLower().Contains(palabra))
            {
                Console.WriteLine($"Coincidencia en: {libro.Titulo}");
                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine("No hay coincidencias.");
    }
}

class Libro
{
    public string Titulo;
    public string Autor;
    public int Anio;
    public string Descripcion;

    public Libro(string titulo, string autor, int anio, string descripcion)
    {
        Titulo = titulo;
        Autor = autor;
        Anio = anio;
        Descripcion = descripcion;
    }
}
