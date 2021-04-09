using System;
using System.Collections.Generic;

namespace Ejercicios
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ejercicio6();

            //Ejercicio12();
            //Ejercicio13();
            //Ejercicio14();
            //Ejercicio15();
            //Ejercicio16();
            Ejercicio18();
        }


        /// <summary>
        /// Permitir al usuario escribir 2 numeros y mostrar en pantalla cual de los dos es el mas grande, si son iguales mostrar los dos
        /// </summary>
        static public void Ejercicio1()
        {
            Console.WriteLine("Digite 2 numeros ");

            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());

            /*
             */
            if (num1 > num2)
            {
                Console.WriteLine($"El numero mayor es el numero {num1}");
            }
            else if (num1 == num2)
            {
                Console.WriteLine($"Son iguales los numeros {num1} y {num2} ");
            }
            else
            {
                Console.WriteLine($"El numero mayor es el numero {num2}");
            }
        }

        /// <summary>
        /// Escribir un metodo que acepte un numero y devuelva true si el numero es par o false si es impar.
        /// </summary>
        static void Ejercicio2()
        {
            Console.WriteLine("Ingrese un numero");

            var num1 = int.Parse(Console.ReadLine());

            if (num1 % 2 == 0)
            {
                Console.WriteLine("Es par ");
            }
            else
            {
                Console.WriteLine("Es impar");
            }
        }

        /// <summary>
        /// Escribir un metodo que acepte 2 string y devuelva el string con mas caracteres
        /// </summary>
        static void Ejercicio3()
        {
            Console.WriteLine("Digite 2 strings");

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            if (str1.Length > str2.Length)
            {
                Console.WriteLine($"El string con mas caracteres es {str1}");
            }
            else if (str1.Length == str2.Length)
            {
                Console.WriteLine("Los strings tienen el mismo numero de caracteres");
            }
            else
            {
                Console.WriteLine($"El string con mas caracteres es {str2}");
            }
        }


        /// <summary>
        /// Metodo que reciba 2 catetos y hallar la hipotenusa(math)
        /// </summary>
        static void Ejercicio4()
        {
            Console.WriteLine("Ingrese 2 catetos");
            int cateto1 = int.Parse(Console.ReadLine());
            int cateto2 = int.Parse(Console.ReadLine());

            var result = Math.Sqrt(Math.Pow(cateto1, 2) + Math.Pow(cateto2, 2)); 
            Console.WriteLine(result);
        }
        /// <summary>
        /// Mostrar numeros del 1 al 100 de 2 en 2
        /// </summary>
        static void Ejercicio5()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        /// <summary>
        /// Metodo que acepte un double que represente grados celcios y lo transforme a grados fahrenheit.
        /// </summary>
        static void Ejercicio6()
        {
            Console.WriteLine("Ingrese un numero en grado celcios");

            bool celcio = double.TryParse(Console.ReadLine(), out double celcios);

            if (celcio && celcios >1)
            {
                // °f = (9/5 * °c) + 32
                var fahrenheit = ((celcios / 5) * (9)) + 32;
                Console.WriteLine($"Los grados celcios {celcios} °C a fehrenheit {fahrenheit} °F");
            }
        }

        /// <summary>
        /// Metodo que acepte una lista de numeros y devuelva el producto de dichos numeros
        /// </summary>
        static void Ejercicio7()
        {
            Console.WriteLine("Digite los numeros ");
            bool stop = false;
            var lista = new List<int>();
            int producto= 1;
            do
            {
                Console.WriteLine("Digite un numero");
                bool numero = int.TryParse(Console.ReadLine(), out int num);
                if ( numero & num > 1)
                {
                    lista.Add(num);
                }
                else if(Console.ReadLine() == "q")
                {
                    stop = true;
                }
            } while (!stop);

            //PRODUCTO
            for (int i = 0; i < lista.Count; i++)
            {
                producto *= lista[i];
            }
            Console.WriteLine($"El producto es {producto}");

        }
        /// <summary>
        /// Factorial de numero ingresado
        /// </summary>
        static void Ejercicio8()
        {
            Console.WriteLine("Digite un numero mayor a 0");

            bool num = int.TryParse(Console.ReadLine(), out int numero);
            if (num && numero >0)
            {
                var lista = new List<int>();
                int resultadofactorial =numero;
          
                for (int i = numero; i >= 1; i--)
                {
                    lista.Add(i);
                }


                for (int i = 1; i < lista.Count; i++)
                {
                    resultadofactorial *= lista[i];
                }
                Console.Write("El factorial es :");
                foreach (var item in lista)
                {
                    Console.Write(item+"*");
                }

                Console.WriteLine($" y El resultado factorial del numero {numero} es {resultadofactorial}");


            }
        }
        /// <summary>
        /// Lista de numeros y calcule promedio
        /// </summary>
        static void Ejercicio9()
        {
            Console.WriteLine("Digite los numeros ");
            bool stop = false;
            var lista = new List<int>();
            int promedio = 0;
            do
            {
                Console.WriteLine("Digite un numero");
                bool numero = int.TryParse(Console.ReadLine(), out int num);
                if (numero & num > 0)
                {
                    lista.Add(num);
                }
                else if (Console.ReadLine() == "q")
                {
                    stop = true;
                }
            } while (!stop);

            
            for (int i = 0; i < lista.Count; i++)
            {
                promedio += lista[i];
            }

            promedio /= lista.Count;

            Console.WriteLine($"El promedio es {promedio}");
        }
        /// <summary>
        ///Escribir un metodo que acepte una lista y devuelva el numero mayor
        /// </summary>
        static void Ejercicio10()
        {
            Console.WriteLine("Digite varios numeros");

            var listaNumeros = new List<int>();
            bool stop = false;
            do
            {
                Console.WriteLine("Digite un numero o para salir la tecla q");

                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    listaNumeros.Add(numero);
                }
                else if(Console.ReadLine()=="q")
                {
                    stop = true;
                }


            } while (!stop);

            var numero2 = listaNumeros[0];
            int posicion= 0;

            for (int i = 0; i < listaNumeros.Count; i++)
            {
                if (numero2 < listaNumeros[i])
                {
                    numero2 = listaNumeros[i];
                    posicion = i;
                }
            }
            Console.WriteLine($"Numero Mayor es  {numero2} en la posicion { posicion + 1}");
        }

        /// <summary>
        /// Metodo que acepte una fecha y retorne la edad que tiene hasa el dia de hoy
        /// </summary>
        static void Ejercicio11()
        {
            Console.WriteLine("Inserte la fecha de su nacimiento (2001,09,22)");
            var fecha = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(fecha.ToString());

            var fechac = DateTime.Today.Year -fecha.Year;

            Console.WriteLine(fechac);
            //Console.WriteLine(fecha.CompareTo(DateTime.Today));
        
        }

        /// <summary>
        /// Escribir un fizzbuzz 
        /// iterar los numeros del 1-100 cuando sea un numero multiplo
        /// de 3 (el 6 por ejemplo ) , escribir "Fizz"
        /// de 5 (el 20 por ejemplo ), escribir "Buzz"
        /// 3 y 5 (el 30 por ejemplo ), escribir "FizzBuzz"
        /// </summary>
        static void Ejercicio12()
        {
            for (int i = 1; i <= 100 ; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("Buzz");
                }      
            }
        }

        /// <summary>
        /// Escribir un metodo que acepte una lista y la devuelta en orden invertido
        /// </summary>
        static void Ejercicio13()
        {
            Console.WriteLine("Lista de numeros");
            var stop = false;
            var lista = new List<int>();
            do
            {
                Console.WriteLine("Ingrese un numero");
                bool validar = int.TryParse(Console.ReadLine(), out int numero);
                if (validar && numero > 0)
                {
                    lista.Add(numero);
                }
                else if(Console.ReadLine() == "q")
                {
                    stop = true;
                }
                else
                {
                    Console.WriteLine("Numero invalido");
                }


            } while (!stop);

            //lista.Reverse();

            //foreach (var item in lista)
            //{
            //Console.WriteLine(item);
            //}


            //mostrar en order inverso
            /*   for (int i = lista.Count-1; i > 0; i--)
               {
                   Console.WriteLine(lista[i]);
               }*/

            //pero si se quiere guardar la lista en orden inverso
            //var listaInvera = new List<int>();

            //for (int i = lista.Count - 1; i > 0; i--)
            //{
            //        listaInvera.Add(lista[i]);


            //}

            int aux;

            for (int i = 0; i < lista.Count/2; i++)
            {
                aux = lista[i];
                lista[i] = lista[lista.Count-1-i];
                lista[lista.Count-1-i] = aux;

            }

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

        }


        /// <summary>
        /// Escribir un metodo que acepte un lista de numeros y los ordene de menor a mayor 
        /// </summary>
        static void Ejercicio14()
        {
            var numeros = new List<int>() { 1,3,4,5,2,6,8,7,9,11,10};

            /*Forma facil*/

            //numeros.Sort();


            /*Forma algoritmo*/
            int mayor;
            for (int i = 0; i < numeros.Count; i++)
            {
                for (int j = 0; j < numeros.Count-1; j++)
                {
                    if (numeros[j + 1] < numeros[j])
                    {
                        mayor = numeros[j + 1];
                        numeros[j + 1] = numeros[j];
                        numeros[j] = mayor;
                    }
                }
            }

            foreach (var item in numeros)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Escribir un metodo que acepte un lista de numeros y los ordene de menor a mayor 
        /// </summary>
        static void Ejercicio15()
        {
            var listaN = new List<int>() {2,5,4,8,1,23,6,9 };

            /*Forma facil*/
            //listaN.Sort(); //ordena de mayor a menor 
            //listaN.Reverse(); //los gira menor-mayor

            for (int i = 0; i < listaN.Count; i++)
            {
                int mayor;
                for (int j = 0; j < listaN.Count-1; j++)
                {
                    if (listaN[j] < listaN[j+1])
                    {
                        mayor = listaN[j];
                        listaN[j] = listaN[j + 1];
                        listaN[j + 1] = mayor;
                    }
                }
            }


            foreach (var item in listaN)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Escribir un metodo que acepte una lista de string y escriba  en la consola el primer caracter de cada uno de los strings
        /// </summary>
        static void Ejercicio16()
        {
            var listaStrings = new List<string>() { "david","andres","hernandez", "Juajinoy" };

            for (int i = 0; i < listaStrings.Count; i++)
            {
                Console.WriteLine(listaStrings[i][1]);
            }        
        }

        /// <summary>
        /// Escribir un metodo que acepte una lista de string y escriba  en la consola el ultimo caracter de cada uno de los strings
        /// </summary>
        static void Ejercicio17()
        {
            var listaStrings = new List<string>() { "david", "andres", "hernandez", "Juajinoy" };

            for (int i = 0; i < listaStrings.Count; i++)
            {
                Console.WriteLine(listaStrings[i][listaStrings[i].Length - 1]);
            }
        }

        /// <summary>
        /// Escribir metodo que acepte string y devuelva true si el string es palindrommo, si no lo es devuelva false.
        /// (Palindromo es una palabra que alreves dice lo mismo (ana) )
        /// </summary>
        static void Ejercicio18()
        {
            var @string ="arenera";
            bool palindromo = false;
            for (int i = 0; i < @string.Length; i++)
            {
                if (@string[@string.Length-1 - i] == @string[i] )
                {
                    palindromo = true;
                }
            }
            var retornar = (palindromo) ? $"{@string} es palindromo": $"{@string} No es palindromo";

            Console.WriteLine(retornar);



        }

    }
}
