using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Proyecto2;

public class Pieza
{
//Se inicializa todas las varibales
public string ColorPieza;
public string TipoPieza;
public int CantidadPiezas;
public string ColorDama;
public string Coordenada;
public string [,] Tableron = new string [8,8];

public Pieza()
{
    ColorPieza = "";
    TipoPieza = "";
    ColorDama = "";

for (int fila = 0; fila < 8; fila++)
{
    for (int columna = 0; columna < 8; columna++)
    {
        //Char convierte el resultado de la suma en un carácter "a" hacia "h" 
        char letraColumna = (char)('a' + columna);
        //Cuenta de 8 hacia abajo (disminución de de columnas de 8 hacia uno)
        int numeroFila = 8 - fila;
        Tableron[fila, columna] = letraColumna.ToString() + numeroFila.ToString();
    }
}

}

//Se crea la función que value que la cantidad de piezas que quiera ingresar sea menor 32
public int AgregarCantidadPiezas(int x)
{
    while(CantidadPiezas <= 32)
    {
        CantidadPiezas = x;
    }
    return CantidadPiezas;
}

//Se guardará en esta función los posibles colores de la pieza
 public string AgregarColor()
 {
   switch(ColorPieza)
   {
    case "Blanco":
        ColorPieza = "Blanco";       
    break;

    case "Negro":
        ColorPieza = "Negro";
    break;
    
    default:
        Console.WriteLine("El color solicitado no existe.");
        return null;
    break;
   }
   return ColorPieza;

 }

//Se guardará en esta función las posibles piezas que el usuario elegirá
public string AgregarPieza(string TipoPiezaC)
{
    switch (TipoPiezaC)
    {
        case "Torre":
            TipoPiezaC = "T";
        break;

        case "Alfil":
            TipoPiezaC = "A";
        break;

        case "Peón" :
            TipoPiezaC = "P";
        break;
        case "Caballo":
            TipoPiezaC = "C";
        break;
        case "Rey":
            TipoPiezaC = "R";
        break;
    }
    return TipoPiezaC;
}
 
 //Se guardará en estaa función el color que el usuario pueda elegir
 public string AgregarColorDama()
 {
    switch(ColorDama)
    {
        case "Blanco":
            ColorDama = "Blanco";
        break; 

        case "Negro":
            ColorDama = "Negro";
        break;
    }
    return ColorDama; 
 }

//Se crearon las coordenadas del tablero para cada espacio designado de la matriz
 public void NotacionTablero()
 {

for (int fila = 0; fila < 8; fila++)
{
    for (int columna = 0; columna < 8; columna++)
    {
        char letraColumna = (char)('a' + columna);
        int numeroFila = 8 - fila;
        Tableron[fila, columna] = letraColumna.ToString() + numeroFila.ToString();
    }
}

for (int fila = 0; fila < 8; fila++)
{
    for (int columna = 0; columna < 8; columna++)
    {
        Console.Write(Tableron[fila, columna] + "\t");
    }
    Console.WriteLine();
}

    }
}
