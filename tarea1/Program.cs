using System;
using System.Collections.Generic;

// ====================== Escuela =======================

// Clase base: Persona
public class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

// Clase Estudiante que hereda de Persona
public class Estudiante : Persona
{
    public int NumeroUnico { get; set; }

    public Estudiante(string nombre, int numeroUnico) : base(nombre)
    {
        NumeroUnico = numeroUnico;
    }
}

// Clase Profesor que hereda de Persona
public class Profesor : Persona
{
    public List<Curso> Cursos { get; set; }

    public Profesor(string nombre) : base(nombre)
    {
        Cursos = new List<Curso>();
    }

    public void AgregarCurso(Curso curso)
    {
        Cursos.Add(curso);
    }
}

// Clase Curso
public class Curso
{
    public string Nombre { get; set; }
    public int RecuentoClases { get; set; }
    public int RecuentoEjercicios { get; set; }

    public Curso(string nombre, int recuentoClases, int recuentoEjercicios)
    {
        Nombre = nombre;
        RecuentoClases = recuentoClases;
        RecuentoEjercicios = recuentoEjercicios;
    }
}

// Clase Clase (un conjunto de estudiantes y profesores)
public class Clase
{
    public string Identificador { get; set; }
    public List<Estudiante> Estudiantes { get; set; }
    public List<Profesor> Profesores { get; set; }

    public Clase(string identificador)
    {
        Identificador = identificador;
        Estudiantes = new List<Estudiante>();
        Profesores = new List<Profesor>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        Estudiantes.Add(estudiante);
    }

    public void AgregarProfesor(Profesor profesor)
    {
        Profesores.Add(profesor);
    }
}

// Clase Escuela
public class Escuela
{
    public List<Clase> Clases { get; set; }

    public Escuela()
    {
        Clases = new List<Clase>();
    }

    public void AgregarClase(Clase clase)
    {
        Clases.Add(clase);
    }
}

// ====================== Formas Geométricas =======================

// Clase abstracta Shape
public abstract class Shape
{
    public double Ancho { get; set; }
    public double Alto { get; set; }

    // Constructor de la clase abstracta
    public Shape(double ancho, double alto)
    {
        Ancho = ancho;
        Alto = alto;
    }

    // Método abstracto para calcular el área
    public abstract double CalculateSurface();
}

// Clase Rectangle que hereda de Shape
public class Rectangle : Shape
{
    public Rectangle(double ancho, double alto) : base(ancho, alto) { }

    // Implementación de CalculateSurface para un rectángulo
    public override double CalculateSurface()
    {
        return Ancho * Alto;
    }
}

// Clase Triangle que hereda de Shape
public class Triangle : Shape
{
    public Triangle(double ancho, double alto) : base(ancho, alto) { }

    // Implementación de CalculateSurface para un triángulo
    public override double CalculateSurface()
    {
        return (Ancho * Alto) / 2;
    }
}

// Clase Circle que hereda de Shape
public class Circle : Shape
{
    // Constructor que inicializa Ancho y Alto con el mismo valor (radio)
    public Circle(double radio) : base(radio, radio) { }

    // Implementación de CalculateSurface para un círculo
    public override double CalculateSurface()
    {
        // Fórmula del área del círculo: π * radio^2
        double radio = Ancho; // Ya que Ancho y Alto son iguales
        return Math.PI * radio * radio;
    }
}

// ====================== Programa Principal =======================

public class Program
{
    public static void Main(string[] args)
    {
        // ====================== Punto 1: Escuela =======================

        // Crear una escuela
        Escuela escuela = new Escuela();

        // Crear una clase
        Clase clase1 = new Clase("Clase 1");

        // Crear algunos estudiantes
        Estudiante estudiante1 = new Estudiante("Juan", 1);
        Estudiante estudiante2 = new Estudiante("Maria", 2);

        // Crear algunos profesores
        Profesor profesor1 = new Profesor("Profesor A");
        Profesor profesor2 = new Profesor("Profesor B");

        // Crear algunos cursos
        Curso curso1 = new Curso("Matemáticas", 20, 10);
        Curso curso2 = new Curso("Historia", 15, 5);

        // Asignar cursos a los profesores
        profesor1.AgregarCurso(curso1);
        profesor2.AgregarCurso(curso2);

        // Agregar estudiantes y profesores a la clase
        clase1.AgregarEstudiante(estudiante1);
        clase1.AgregarEstudiante(estudiante2);
        clase1.AgregarProfesor(profesor1);
        clase1.AgregarProfesor(profesor2);

        // Agregar la clase a la escuela
        escuela.AgregarClase(clase1);

        // Mostrar información
        Console.WriteLine("Escuela:");
        foreach (Clase clase in escuela.Clases)
        {
            Console.WriteLine($"Clase: {clase.Identificador}");
            Console.WriteLine("Estudiantes:");
            foreach (Estudiante estudiante in clase.Estudiantes)
            {
                Console.WriteLine($"- {estudiante.Nombre} (ID: {estudiante.NumeroUnico})");
            }
            Console.WriteLine("Profesores:");
            foreach (Profesor profesor in clase.Profesores)
            {
                Console.WriteLine($"- {profesor.Nombre}");
                Console.WriteLine("Cursos:");
                foreach (Curso curso in profesor.Cursos)
                {
                    Console.WriteLine($"  * {curso.Nombre} (Clases: {curso.RecuentoClases}, Ejercicios: {curso.RecuentoEjercicios})");
                }
            }
        }

        // ====================== Punto  2: Formas Geométricas =======================

        // Crear una matriz de diferentes formas
        Shape[] shapes = new Shape[]
        {
            new Rectangle(10, 5),   // Rectángulo de ancho 10 y alto 5
            new Triangle(10, 5),    // Triángulo de ancho 10 y alto 5
            new Circle(5)           // Círculo con radio 5
        };

        // Calcular el área de cada forma y mostrarlo en consola
        Console.WriteLine("\nÁreas de las formas geométricas:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"El área de la {shape.GetType().Name} es: {shape.CalculateSurface():0.00}");
        }
    }
}
