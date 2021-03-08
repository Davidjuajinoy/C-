using System;
using System.Collections.Generic;
using System.Linq;

namespace Beginning_Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            String filePath = @"C:\Users\david.hernandez\source\repos\Beginning Collections\3.Beginning Collections LINQ\Pop by Largest Final.csv";

            CvsLeer leer = new CvsLeer(filePath);

            List<Pais> paises = leer.LeerTodosPaises();


            // se requiere el using using System.Linq;
            //foreach (var item in paises.OrderBy(pais => pais.Nombre).Take(20) ) 
            //{
            //    Console.WriteLine($"{ item.Nombre }");
            //}

            // linq se usa para consultar datos y no modificarlos por eso se dice que es Readonly

            var filtro1 = paises.OrderBy(pais => pais.Nombre).Where(x => !x.Nombre.Contains(","));

            var filtro2 = from pais in paises
                          where !pais.Nombre.Contains(",")
                          select pais;

            foreach (var item in filtro2)
            {
                Console.WriteLine($"{ item.Nombre }");
            }


            Console.WriteLine("Digite el numero de paises que quiere ver");


            bool valido = int.TryParse(Console.ReadLine(), out int userInput);




            if (!valido && userInput <= 0)
            {
                Console.WriteLine("Se debe digtar un numero sin decimales.");
                return;
            }

            //si el usuario pone mas de los que hay
            //int maxDisplay = Math.Min(userInput, paises.Count);
        }
    }
}
