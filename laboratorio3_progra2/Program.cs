using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class ConexionDBAsignaturas
{
    static void Main()
    {
        using (var context = new Context())
        {
            context.Database.EnsureCreated();

            while (true)
            {
                Console.WriteLine("1. Mostrar | 2. Insertar | 3. Modificar | 4. Salir");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Mostrar(context);
                        break;
                    case "2":
                        Insertar(context);
                        break;
                    case "3":
                        ActualizarNombre(context);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }

    static void Mostrar(Context ctx)
    {
        ctx.asignaturas.ToList().ForEach(a => Console.WriteLine($"ID: {a.id}, Nombre: {a.Nombre}, Unidades Valorativas: {a.UnidadesValorativas}, Ciclo: {a.Ciclo}, Inscritos: {a.Inscritos}"));
    }

    static void Insertar(Context ctx)
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Unidades Valorativas: ");
        int unidadesValorativas = LeerInt("Unidades Valorativas: ");
        Console.Write("Ciclo: ");
        string ciclo = Console.ReadLine();
        Console.Write("Inscritos: ");
        int inscritos = LeerInt("Inscritos: ");

        var nuevaAsignatura = new Asignaturas
        {
            Nombre = nombre,
            UnidadesValorativas = unidadesValorativas,
            Ciclo = ciclo,
            Inscritos = inscritos
        };

        ctx.asignaturas.Add(nuevaAsignatura);
        ctx.SaveChanges();
        Console.WriteLine("Asignatura insertada con éxito.");
    }

    static void ActualizarNombre(Context ctx)
    {
        int id = LeerInt("ID de la asignatura a actualizar el nombre: ");
        var asignatura = ctx.asignaturas.FirstOrDefault(a => a.id == id);

        if (asignatura != null)
        {
            asignatura.Nombre = LeerString("Nuevo nombre: ");
            ctx.SaveChanges();
            Console.WriteLine("Nombre de la asignatura actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Asignatura no encontrada.");
        }
    }

    static int LeerInt(string mensaje)
    {
        Console.Write(mensaje);
        return int.TryParse(Console.ReadLine(), out int result) ? result : 0;
    }

    static string LeerString(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine();
    }
}

