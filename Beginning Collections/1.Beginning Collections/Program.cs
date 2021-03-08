using System;
using System.Collections.Generic;

namespace Beginning_Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            String filePath = @"C:\Users\david.hernandez\source\repos\Beginning Collections\Beginning Collections\Pop by Largest Final.csv";

            CvsLeer leer = new CvsLeer(filePath);

            List<Pais> paises = leer.LeerTodosPaises();

            leer.RemoverComas(paises);

            //agregar un pais en medio

            Pais liliput = new Pais("Liliput", "LIL", "SomeWhere", 2000000);
            int Ililiput; //I de indice

            // Buscando el indice
            Ililiput = paises.FindIndex(pais => pais.Poblacion < 2000000);

            //metodo para insertar requiere la posicion y el elemento
            paises.Insert(Ililiput, liliput);

            //Eliminar un dato solo requiere el objeto  
            paises.Remove(liliput);

            /*int count = 1;
            foreach (var item in paises)
            {
                Console.WriteLine($"{count++} Nombre: {item.Nombre} Code: {item.Code} Continente: {item.Region} Poblacion: {item.Poblacion:N}");
            }

                Console.WriteLine($"El total de elementos es de {paises.Count}");*/

            Console.WriteLine("Digite el numero de paises que quiere ver");

            
            bool valido = int.TryParse(Console.ReadLine(), out int userInput);


            

            if (!valido && userInput <= 0)
            {
                Console.WriteLine("Se debe digtar un numero sin decimales.");
                return;
            }

            //si el usuario pone mas de los que hay
            //int maxDisplay = Math.Min(userInput, paises.Count);

            for (int i = 0; i < paises.Count; i++)
            {
                if (i > 0 && i % userInput == 0)
                {
                    Console.WriteLine("Si quiere mostrar otros diez pais deje en blanco");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }

                var pais = paises[i];
                Console.WriteLine($"{1 + i} Nombre: {pais.Nombre} Code: {pais.Code} Continente: {pais.Region} Poblacion: {pais.Poblacion:N}");
            }

            /*for (int i = paises.Count-1; i >= 0 ; i--)
            {
                int displayIndex = paises.Count - 1 - i;

                if (displayIndex > 0 && displayIndex % userInput == 0)
                {
                    Console.WriteLine("Si quiere mostrar otros diez pais deje en blanco");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }

                var pais = paises[i];
                Console.WriteLine($"{displayIndex + 1} Nombre: {pais.Nombre} Code: {pais.Code} Continente: {pais.Region} Poblacion: {pais.Poblacion:N}");
            }*/


            //int[] ints = { 1, 2, 3, 4 };
            /*        string[] DaysOfWeek =
                    {
                        "Lunes",
                        "Martes",
                        "Miercoles",
                        "Jueves",
                        "Viernes",
                        "Sabado",
                        "Domingo"
                    };*/

            //sobrescribir
            //DaysOfWeek[0] = "lunes";

            /*  foreach (var item in DaysOfWeek)
              {
                  Console.WriteLine(item);
              }*/


            /*Console.WriteLine("Seleccione un numero del 1 - 7");
            int iDay = int.Parse(Console.ReadLine());
            Console.WriteLine($"Este dia es {DaysOfWeek[iDay-1]}");*/

            /*   
             *   LISTA COLECCION
             *   List<String> DayOfWeek = new List<string>();

               DayOfWeek.Add("Lunes");
               DayOfWeek.Add("Martes");
               DayOfWeek.Add("Miercoles");
               DayOfWeek.Add("Jueves");
               DayOfWeek.Add("Viernes");


               List<String> DaysOfWeek = new List<string>()
               {
                   "Lunes",
                   "Martes",
                   "Miercoles",
                   "Jueves",
                   "Viernes",
                   "Sabado",
                   "Domingo"
               };*/



        }
    }
}
