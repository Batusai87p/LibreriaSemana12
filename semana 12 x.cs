using System;

class Libreria
{
    string[] nombres = new string[0];
    double[] precios = new double[0];

    // MÉTODO REGISTRAR
    public void Registrar()
    {
        Console.Write("Ingrese nombre del libro: ");
        string nombre = Console.ReadLine();

        // Validaciones
        if (string.IsNullOrEmpty(nombre))
        {
            Console.WriteLine(" El nombre no puede estar vacío.");
            return;
        }

        // Verificar duplicado
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].ToLower() == nombre.ToLower())
            {
                Console.WriteLine(" Ese libro ya existe.");
                return;
            }
        }

        // Ingresar precio
        Console.Write("Ingrese precio del libro: ");
        string textoPrecio = Console.ReadLine();
        double precio;

        if (!double.TryParse(textoPrecio, out precio))
        {
            Console.WriteLine(" El precio debe ser numérico.");
            return;
        }

        if (precio < 0 || precio > 1000)
        {
            Console.WriteLine(" El precio debe ser entre 0 y 1000.");
            return;
        }

        // Registrar libro
        Array.Resize(ref nombres, nombres.Length + 1);
        Array.Resize(ref precios, precios.Length + 1);
        nombres[^1] = nombre;
        precios[^1] = precio;

        Console.WriteLine(" Libro registrado correctamente.");
    }

    // MÉTODO MOSTRAR
    public void Mostrar()
    {
        if (nombres.Length == 0)
        {
            Console.WriteLine(" No hay libros registrados.");
            return;
        }

        Console.WriteLine("\n--- LISTA DE LIBROS ---");
        for (int i = 0; i < nombres.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {nombres[i]} - S/{precios[i]:0.00}");
        }
    }

    // MÉTODO MODIFICAR
    public void Modificar()
    {
        Console.Write("Ingrese el nombre del libro a modificar: ");
        string buscar = Console.ReadLine();

        int index = -1;
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].ToLower() == buscar.ToLower())
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine(" El libro no existe.");
            return;
        }

        Console.Write("Ingrese el nuevo nombre del libro: ");
        string nuevoNombre = Console.ReadLine();

        if (string.IsNullOrEmpty(nuevoNombre))
        {
            Console.WriteLine(" El nombre no puede estar vacío.");
            return;
        }

        // Validar que el nuevo nombre no exista ya
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].ToLower() == nuevoNombre.ToLower() && i != index)
            {
                Console.WriteLine(" Ya existe otro libro con ese nombre.");
                return;
            }
        }

        Console.Write("Ingrese el nuevo precio del libro: ");
        string texto = Console.ReadLine();
        double nuevoPrecio;

        if (!double.TryParse(texto, out nuevoPrecio))
        {
            Console.WriteLine(" El precio debe ser numérico.");
            return;
        }

        if (nuevoPrecio < 0 || nuevoPrecio > 1000)
        {
            Console.WriteLine(" El precio debe ser entre 0 y 1000.");
            return;
        }

        nombres[index] = nuevoNombre;
        precios[index] = nuevoPrecio;

        Console.WriteLine(" Libro modificado correctamente.");
    }

    // MÉTODO ELIMINAR
    public void Eliminar()
    {
        Console.Write("Ingrese el nombre del libro a eliminar: ");
        string buscar = Console.ReadLine();

        int index = -1;
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].ToLower() == buscar.ToLower())
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine(" El libro no existe.");
            return;
        }

        for (int i = index; i < nombres.Length - 1; i++)
        {
            nombres[i] = nombres[i + 1];
            precios[i] = precios[i + 1];
        }

        Array.Resize(ref nombres, nombres.Length - 1);
        Array.Resize(ref precios, precios.Length - 1);

        Console.WriteLine(" Libro eliminado correctamente.");
    }
}

class Program
{
    static void Main()
    {
        Libreria libreria = new Libreria();
        int opcion;

        do
        {
            Console.WriteLine("\n===== MENÚ LIBRERÍA =====");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Mostrar libros");
            Console.WriteLine("3. Modificar libro");
            Console.WriteLine("4. Eliminar libro");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine(" Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1: libreria.Registrar(); break;
                case 2: libreria.Mostrar(); break;
                case 3: libreria.Modificar(); break;
                case 4: libreria.Eliminar(); break;
                case 5: Console.WriteLine(" Saliendo del programa..."); break;
                default: Console.WriteLine(" Opción inválida."); break;
            }

        } while (opcion != 5);
    }
}
