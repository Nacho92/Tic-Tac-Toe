using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        // Esta es la función principal donde se ejecuta el juego
        static void Main(string[] args)
        {
            // Declaro un array para crear el tablero
            char[,] arr = { { ' ', ' ', ' ' }, { ' ', ' ', ' '}, { ' ', ' ', ' '} };
            char jugador1Eleccion = ' ';
            char jugador2Eleccion = ' ';

            // Solicito que el jugador 1 elija entre 'X' o 'O'
            Console.WriteLine(" Introduce si quieres ser 'X' o 'O': ");
            while (true)
            {
                string introduce = Console.ReadLine();
                if (introduce.Length == 1) 
                {
                    if (introduce == "x" || introduce == "o")
                    {
                        jugador1Eleccion = Char.ToUpper(Convert.ToChar(introduce));
                        if (jugador1Eleccion == 'X')
                        {
                            jugador2Eleccion = 'O';
                            break;
                        }
                        else
                        {
                            jugador2Eleccion = 'X';
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("has introducido un caracter no valido");
                    }
                }
                else 
                {
                    Console.WriteLine(" Has introducido mas de un caracter");
                }
            }
            int jugador1Fila = 0;
            int jugador1Columna = 0;
            int jugador2Fila = 0;
            int jugador2Columna = 0;
            // Bucle principal que se ejecuta durante 9 rondas (hasta llenar todo el tablero)
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(Tablero(arr));

                string resultado = ""; // Variable para almacenar el resultado

                if (i % 2 == 0)
                {
                    // Turno jugador 1
                    bool controlador = true;
                    while (controlador)
                    {
                        try
                        {
                            Console.WriteLine("Turno Jugador 1");
                            Console.WriteLine("Introduce la Fila (1-3):");
                            int fila = Convert.ToInt32(Console.ReadLine()) - 1;
                            Console.WriteLine("Introduce la Columna (1-3):");
                            int columna = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (fila >= 0 && fila < 3 && columna >= 0 && columna < 3)
                            {
                                if (arr[fila, columna] == ' ')
                                {
                                    arr[fila, columna] = jugador1Eleccion;
                                    controlador = false;
                                }
                                else
                                {
                                    Console.WriteLine("¡Casilla ocupada, prueba otra!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("¡Posición fuera de rango! Introduce un número entre 1 y 3.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Entrada no válida. Por favor ingresa un número.");
                        }
                    }
                }
                else
                {
                    // Turno jugador 2
                    bool controlador = true;
                    while (controlador)
                    {
                        try
                        {
                            Console.WriteLine("Turno Jugador 2");
                            Console.WriteLine("Introduce la Fila (1-3):");
                            int fila = Convert.ToInt32(Console.ReadLine()) - 1;
                            Console.WriteLine("Introduce la Columna (1-3):");
                            int columna = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (fila >= 0 && fila < 3 && columna >= 0 && columna < 3)
                            {
                                if (arr[fila, columna] == ' ')
                                {
                                    arr[fila, columna] = jugador2Eleccion;
                                    controlador = false;
                                }
                                else
                                {
                                    Console.WriteLine("¡Casilla ocupada, prueba otra!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("¡Posición fuera de rango! Introduce un número entre 1 y 3.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Entrada no válida. Por favor ingresa un número.");
                        }
                    }
                }

                // Verifica si hay un ganador o empate después de cada turno
                resultado = VerificarVictoria(arr);
                if (resultado != "")
                {
                    Console.WriteLine(resultado);  // Muestra el resultado (ganador o empate)
                    break; // Termina el juego
                }
            }

            Console.ReadLine();
        }

        // Esta función crea y devuelve el tablero de juego como un string
        public static string Tablero(char[,] x)
        {
            string tableroHecho = "";
            tableroHecho += " _____Tic_Tac_Toe_C#_Version_1.0_____\n";
            tableroHecho += "\n";
            tableroHecho += " __Player1_==_'O'__&__Player2_=_'X'__\n";
            tableroHecho += "┌───────────┬───────────┬───────────┐\n";
            tableroHecho += "│           │           │           │\n";
            tableroHecho += $"│     {x[0,0]}     │     {x[0,1]}     │     {x[0,2]}     │\n";
            tableroHecho += "│           │           │           │\n";
            tableroHecho += "├───────────┼───────────┼───────────┤\n";
            tableroHecho += "│           │           │           │\n";
            tableroHecho += $"│     {x[1,0]}     │     {x[1,1]}     │     {x[1,2]}     │\n";
            tableroHecho += "│           │           │           │\n";
            tableroHecho += "├───────────┼───────────┼───────────┤\n";
            tableroHecho += "│           │           │           │\n";
            tableroHecho += $"│     {x[2,0]}     │     {x[2,1]}     │     {x[2,2]}     │\n";
            tableroHecho += "│           │           │           │\n";
            tableroHecho += "└───────────┴───────────┴───────────┘\n";

            return tableroHecho;
        }

        // Función que verifica si hay un ganador o empate
        public static string VerificarVictoria(char[,] x)
        {
            // Revisa filas, columnas y diagonales
            for (int i = 0; i < 3; i++)
            {
                // Verificar filas
                if (x[i, 0] == x[i, 1] && x[i, 1] == x[i, 2] && x[i, 0] != ' ')
                    return $"Jugador {(x[i, 0] == 'X' ? 2 : 1)} Ha Ganado!";
                // Verificar columnas
                if (x[0, i] == x[1, i] && x[1, i] == x[2, i] && x[0, i] != ' ')
                    return $"Jugador {(x[0, i] == 'X' ? 2 : 1)} Ha Ganado!";
            }

            // Verificar diagonales
            if (x[0, 0] == x[1, 1] && x[1, 1] == x[2, 2] && x[0, 0] != ' ')
                return $"Jugador {(x[0, 0] == 'X' ? 2 : 1)} Ha Ganado!";
            if (x[2, 0] == x[1, 1] && x[1, 1] == x[0, 2] && x[2, 0] != ' ')
                return $"Jugador {(x[2, 0] == 'X' ? 2 : 1)} Ha Ganado!";

            // Verificar empate
            bool empate = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (x[i, j] == ' ') empate = false;

            if (empate) return "Han Empatado";

            return "";  // No hay ganador ni empate
        }
    }
}
