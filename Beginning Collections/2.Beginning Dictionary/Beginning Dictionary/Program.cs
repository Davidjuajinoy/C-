using System;
using System.Collections.Generic;

namespace Beginning_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            String filePath = @"C:\Users\david.hernandez\source\repos\Beginning Collections\Beginning Collections\Pop by Largest Final.csv";

            CvsLeer archivo = new CvsLeer(filePath);

            var paises = archivo.LeerTodosPaises();


            Console.WriteLine("Digite el Code Del Pais que desea ver");
            var usuarioInput = Console.ReadLine();

            var existe = paises.TryGetValue(usuarioInput, out Pais existePais);

            if (!existe)
            {
                Console.WriteLine($"No se ecuentra el pais con el code {usuarioInput}");
            }
            else
            {
                Console.WriteLine($"{existePais.Nombre} y es de {existePais.Region}");
            }
            


/*            var count = 1;
            foreach (var item in paises.Values)
            {
                Console.WriteLine($"{count++} Nombre: {item.Nombre} Code: {item.Code} Continente: {item.Region} Poblacion: {item.Poblacion:N}");
            }*/


            //Pais norway = new Pais("Norway", "NOR", "Europe", 5282223);
            //Pais finland = new Pais("Finland", "FIN", "Europe", 5511303);

            /*Dictionary<string, Pais> paises = new Dictionary<string, Pais>
                        {
                            { norway.Code, norway },
                            { finland.Code, finland }
                        };
            */

            //Dictionary<string, Pais> paises = new Dictionary<string, Pais>();
            //las Keys son unicas
            // key , element
            //paises.Add(norway.Code, norway);
            //paises.Add(finland.Code, finland);


            /*Pais paisSeleccionado = paises["NOR"];

            Console.WriteLine($"El pais seleccionado es {paisSeleccionado.Nombre} de  {paisSeleccionado.Region}");
*/

            //para hacer un ciclo foreach con un diccionario seria asi
            /*foreach (var item in paises.Values )
            {
                Console.WriteLine(item.Nombre);
            }*/



            // para buscar si el valor existe se usa un metodo

            /*bool existe = paises.TryGetValue("MUS", out var pais);

            if (existe)
            {
                Console.WriteLine($"{pais.Nombre}");
            }
            else
            {
                Console.WriteLine("No existe una llave con ese nombre");
            }*/

            //Eliminar se pone de parametro la llave
            //paises.Remove("FIN");







        }
    }
}
