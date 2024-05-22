using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Proyecto2;

public class Tablero
{
    //Se inicializan las varibales y la matriz 8*8
    public Pieza[,] matriz = new Pieza[8, 8];
    int FilaPieza = 0;
    int ColumnaPieza = 0;

    //Se llaman guarda en esta función la todo lo que se creó previamente en la clase pieza sobre todas las piezas.
    public void GuardarInfo()
    {
        Console.WriteLine();
        Console.WriteLine("Ingrese la cantiadad de piezas");
        int CantidadPiezas = int.Parse(Console.ReadLine());
        Console.WriteLine();
        string ColorSi;
        
        for (int i = 0; i < CantidadPiezas; i++)
        {
            Pieza pieza = new Pieza();

            Console.WriteLine("Ingrese la coordernada de la pieza " + (i + 1));
            pieza.Coordenada = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Ingrese la pieza que desea: (Caballo(C), Alfil(A), Peón(P), Torre(T), Rey(R) ");
            pieza.TipoPieza = Console.ReadLine();
            pieza.AgregarPieza(pieza.TipoPieza);
            Console.WriteLine();

            //Validación del color de las piezas
            do
            {
            Console.WriteLine("Ingrese el color de la pieza: (Blanco o Negro) ");
            pieza.ColorPieza = Console.ReadLine();
            ColorSi = pieza.AgregarColor();
            Console.WriteLine();
            }
            while (ColorSi == null);

            for (int x = 0; x < 8; x++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pieza.Tableron[x, j] == pieza.Coordenada)
                    {
                        FilaPieza = x;
                        ColumnaPieza = j;
                    }
                }
            }
            if (matriz[FilaPieza, ColumnaPieza] == null)
            {
                matriz[FilaPieza, ColumnaPieza] = pieza;
            }

        }
    }

    //Se llaman guarda en esta función la todo lo que se creó previamente en la clase pieza sobre todas las damas.
    public void GuardarDama()
    {
        string ColorSi;
        Console.WriteLine("Ingrese la coordernada de la Dama: ");
        string coordenada = Console.ReadLine();
        Console.WriteLine();

        Pieza pieza = new Pieza();
        pieza.TipoPieza = "D";

        //Validación del color de la Dama
        do
        {
        Console.WriteLine("Ingrese el color de la Dama: (Blanco o Negro) ");
        pieza.ColorPieza = Console.ReadLine();
        ColorSi = pieza.AgregarColor();
        Console.WriteLine();
        }
        while (ColorSi == null);

        for (int x = 0; x < 8; x++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (pieza.Tableron[x, j] == coordenada)
                {
                    FilaPieza = x;
                    ColumnaPieza = j;
                }
            }
        }
        if (matriz[FilaPieza, ColumnaPieza] == null)
        {
            matriz[FilaPieza, ColumnaPieza] = pieza;
        }
    }

//Se crea esta función para almacenar todos los posibles movimientos de la Dama
    public void MovimientosDama()
    {
        Pieza objpieza = new Pieza();
        Console.WriteLine("Los posibles movimientos de la Dama son: ");
        Console.WriteLine();
        //Movimiento vertical para arriba
        for (int fila = FilaPieza+1; fila < 8; fila++)
        {
            if(matriz[fila, ColumnaPieza]==null)
            {
                Console.WriteLine(objpieza.Tableron[fila,ColumnaPieza] + " esta vacío");
            }
            else
            {
                if(matriz[fila, ColumnaPieza].ColorPieza != matriz[FilaPieza, ColumnaPieza].ColorPieza)
                {
                    Console.WriteLine("Esta ocupada por "+ matriz [fila, ColumnaPieza].TipoPieza);
                    break;
                }
                else{
                    break;
                }
            }
        }
        //Movimiento vertical para abajo 
        for (int fila = FilaPieza-1; fila > -1; fila--)
        {
            if(matriz[fila, ColumnaPieza]==null)
            {
                Console.WriteLine(objpieza.Tableron[fila,ColumnaPieza]+" esta vacío");
            }
            else
            {
                if(matriz[fila, ColumnaPieza].ColorPieza != matriz[FilaPieza, ColumnaPieza].ColorPieza)
                {
                    Console.WriteLine("Esta ocupada por "+ matriz [fila, ColumnaPieza].TipoPieza);
                    break;
                }
                else{
                    break;
                }
            }
        }
        //Movimiento para la derecha
        for (int columna = ColumnaPieza+1; columna < 8; columna++)
        {
            if(matriz[FilaPieza, columna] == null)
            {
                Console.WriteLine(objpieza.Tableron[FilaPieza,columna]+" esta vacío");
            }
            else
            {
                if(matriz[FilaPieza, columna].ColorPieza != matriz[FilaPieza, ColumnaPieza].ColorPieza)
                {
                    Console.WriteLine("Esta ocupada por "+ matriz [FilaPieza, columna].TipoPieza);
                    break;
                }
                else{
                    break;
                }
            }
        }
        //Movimiento para la izquierda
        for (int columna = ColumnaPieza-1; columna >=0; columna--)
        {
            if(matriz[FilaPieza, columna] == null)
            {
                Console.WriteLine(objpieza.Tableron[FilaPieza,columna]+ " esta vacía");
            }
            else
            {
                if(matriz[FilaPieza, columna].ColorPieza != matriz[FilaPieza, ColumnaPieza].ColorPieza)
                {
                    Console.WriteLine("Esta ocupada por "+ matriz [FilaPieza, columna].TipoPieza);
                    break;
                }
                else{
                    break;
                }
            }
        }
        
        //Diagonales
        for (int fila = FilaPieza-1, columna = ColumnaPieza + 1; fila >= 0 && columna < 8 ; fila--, columna++)
        {

                if(matriz[fila, columna] == null)
                {
                    Console.WriteLine(objpieza.Tableron[fila,columna]+ " esta vacío");
                }
                else{
                    if(matriz[fila,columna].ColorPieza != matriz[FilaPieza,ColumnaPieza].ColorPieza)
                    {
                        Console.WriteLine("Esta ocupado por "+ matriz[fila,columna].TipoPieza);
                        break;
                    }
                    else{
                        break;
                    }
                }
        }

        for (int fila = FilaPieza-1, columna = ColumnaPieza-1; fila >= 0 && columna >= 0 ; fila--, columna--)
        {
                 if(matriz[fila, columna] == null)
                {
                    Console.WriteLine(objpieza.Tableron[fila,columna]+ " esta vacío");
                }
                else{
                    if(matriz[fila,columna].ColorPieza != matriz[FilaPieza,ColumnaPieza].ColorPieza)
                    {
                        Console.WriteLine("Esta ocupado por "+ matriz[fila,columna].TipoPieza);
                        break;
                    }
                    else{
                        break;
                    }
                }
        }

        for (int fila = FilaPieza+1, columna = ColumnaPieza+1; fila < 8 && columna < 8; fila++, columna++)
        {
                 if(matriz[fila, columna] == null)
                {
                    Console.WriteLine(objpieza.Tableron[fila,columna]+ " esta vacío");
                }
                else{
                    if(matriz[fila,columna].ColorPieza != matriz[FilaPieza,ColumnaPieza].ColorPieza)
                    {
                        Console.WriteLine("Esta ocupado por "+ matriz[fila,columna].TipoPieza);
                        break;
                    }
                    else{
                        break;
                    }
                }
        }

        for (int fila = FilaPieza+1, columna = ColumnaPieza-1; fila < 8 && columna >=0 ; fila++, columna--)
        {
             if(matriz[fila, columna] == null)
                {
                    Console.WriteLine(objpieza.Tableron[fila,columna]+ " esta vacío");
                }
                else{
                    if(matriz[fila,columna].ColorPieza != matriz[FilaPieza,ColumnaPieza].ColorPieza)
                    {
                        Console.WriteLine("Esta ocupado por "+ matriz[fila,columna].TipoPieza);
                        break;
                    }
                    else{
                        break;
                    }
                }
        }
        Console.WriteLine();
    }

//Se creó el tablero modificado para mostrar las posiciones de las piezas dentro de la matriz
    public void TableroAjedrez()
    {
        Console.WriteLine("Tablero con las piezas: ");
        Console.WriteLine();
        Pieza pieza= new Pieza();
        for (int x = 0; x < matriz.GetLength(0); x++)
        {
            for (int y = 0; y < matriz.GetLength(1) ; y++)
            {
                if(matriz[x,y]  == null)
                {
                    Pieza objpieza = new Pieza();
                    objpieza.TipoPieza = objpieza.Tableron[x,y] + " " + "▢";
                    matriz[x,y] = objpieza;
                }
                Console.Write(matriz [x,y].TipoPieza  + "\t");
            }
            Console.WriteLine(" ");
        }
    }

}

