using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaro un array para crear el tablero
            char[,] arr = { { ' ', ' ', ' ' }, { ' ', ' ', ' '}, { ' ', ' ', ' '} };
            char jugador1Eleccion = ' ';
            char jugador2Eleccion = ' ';

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



            for (int i=0; i < 9; i++)
            {
                Console.WriteLine(Tablero(arr));
                
                if(i % 2 == 0)
                {
                    bool controlador = true;
                    while(controlador)
                    {
                        //try para ver el formato
                        try
                        {
                            Console.WriteLine(" Turno jugador 1");
                            //introduce la fila el jugador 1
                            Console.WriteLine(" Introduce la Fila:");
                            jugador1Fila = Convert.ToInt32(Console.ReadLine()) - 1;

                            // introduce la columna el jugador 1
                            Console.WriteLine(" Introduce la Columna:");
                            jugador1Columna = Convert.ToInt32(Console.ReadLine()) - 1;

                            //verificar que no se valla del rango de la matriz
                            if (jugador1Fila < 3 && jugador1Columna < 3)
                            {
                                //verificar que el lugar que valla a ocupar este vacio
                                if (arr[jugador1Fila, jugador1Columna] == ' ')
                                {
                                    // verificar que el caracter introducido sea igual a la eleccion hecha( osea que no pueda tener otro  caracter que no sea 'x' o 'o'
                                    if (arr[jugador1Fila, jugador1Columna] == jugador1Eleccion)
                                    {
                                        arr[jugador1Fila, jugador1Columna] = jugador1Eleccion;
                                        controlador = false;
                                    }
                                    else
                                        Console.WriteLine("caracter erroneo");
                                }
                                else
                                    Console.WriteLine(" La casilla esta ocupada");
                            }
                            else
                            {
                                Console.WriteLine(" Eleccion Fuera del rango");
                            }
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("marc segui probando guanaco");
                        }
                        
                    }
                    VerificarVictoria(arr);
                    



                }
                else
                {
                    bool controlador = true;
                    while (controlador)
                        
                    {
                        try
                        {
                            //turno jugador dos
                            Console.WriteLine(" Turno jugador 2");
                            Console.WriteLine(" Introduce la Fila:");
                            //introduce la fila el jugador 2
                            jugador2Fila = Convert.ToInt32(Console.ReadLine()) - 1;
                            // introduce la columna el jugador 2
                            Console.WriteLine(" Introduce la Columna:");
                            jugador2Columna = Convert.ToInt32(Console.ReadLine()) - 1;
                            //verificar que no se valla del rango de la matriz
                            if (jugador2Fila < 3 && jugador2Columna < 3)
                            {
                                //verificar que el lugar que valla a ocupar este vacio
                                if (arr[jugador2Fila, jugador2Columna] == ' ')

                                {
                                    // verificar que el caracter introducido sea igual a la eleccion hecha( osea que no pueda tener otro  caracter que no se 'x' o 'o'
                                    if (arr[jugador2Fila, jugador2Columna] == jugador2Eleccion)
                                    {
                                        arr[jugador2Fila, jugador2Columna] = jugador2Eleccion;
                                        controlador = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("caracter erroneo");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine(" La casilla esta ocupada");
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Eleccion Fuera del rango");
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Marc segui probando guanaco");
                        }


                    }
                    
                }
                VerificarVictoria(arr);

            }
            
            Console.ReadLine();
        }
        //funcion hecha para que me devuelva un tablero de juego
        public static string Tablero(char[,] x)
        {
            //declaro una string la cual va a contener el tablero y las posiciones en las cuales van los elementos del array
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
            public static string VerificarVictoria(char[,] x)
        {
            
            string ganador = ""; 
                
            //chequeo si la primera columan tiene los mismos valores
            if(x[0,0] == x [0,1] && x [0,1] == x[0, 2])
            {
                ganador = " Has Ganado";
            }
            //chequeo si la segunda columan tiene los mismos valores
            else if (x[1, 0] == x[1, 1] && x[1, 1] == x[1, 2])
            {
                ganador = " Has Ganado";
            }
            //chequeo si la tercera columan tiene los mismos valores
            else if (x[2, 0] == x[2, 1] && x[2, 1] == x[2, 2])
            {
                ganador = " Has Ganado";
            }
            //chequeo si la diagonal decendente desde el origen tiene los mismos valores
            else if (x[0, 0] == x[1, 1] && x[1, 1] == x[2, 2])
            {
                ganador = " Has Ganado";
            }
            //chequeo si la diagonal ascendente desde el final tiene los mismos valores
            else if (x[2, 0] == x[1, 1] && x[1, 1] == x[0, 2])
            {
                ganador = " Has Ganado";
            }
            //chequeo si primera columna tiene los mismos valores
            if (x[0, 0] == x[1,0] && x[1, 0] == x[2, 0])
            {
                ganador = " Has Ganado";
            }
            //chequeo si segunda columna tiene los mismos valores
            else if (x[0, 1] == x[1, 1] && x[1, 1] == x[2, 1])
            {
                ganador = " Has Ganado";
            }
            //chequeo si tercera columna tiene los mismos valores
            else if (x[0, 2] == x[1, 2] && x[1, 2] == x[2, 2])
            {
                ganador = " Has Ganado";
            }
            //empate
            else
            {
                ganador = " Han Empatado";
            }
            

            return ganador;

        }


    }
}
