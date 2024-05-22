using System.Reflection.Metadata;
using Proyecto2;

class Program
{
    static void Main(string[] args)
    {
        //Se le da la bienvenida al usuario
        Console.WriteLine();
        Console.WriteLine("¡Bienvenido a ChestMaster!");
        Console.WriteLine();
        Console.WriteLine("El Tablero de coordenadas es: ");
        Console.WriteLine();

        //Se llaman a las clases y las funciones que se necesitan
        Pieza pieza = new Pieza();
        pieza.NotacionTablero(); 


        Tablero tablero = new Tablero();
        tablero.GuardarInfo();
        tablero.GuardarDama();
        tablero.MovimientosDama();     
        tablero.TableroAjedrez();   


        


    }
}