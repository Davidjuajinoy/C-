using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            //Console.WriteLine("Ingrese su nombre");
                        //String nombre = Console.ReadLine();
                        //Console.WriteLine($"Hello {nombre}!");
                        double a= 10.4;
                        double b = 20.4;
                        double res = a + b;
                        Console.WriteLine($"Respuesta es {res}");
                        float xd = 10.1f;
                        Double[] numbers = new Double[3];
                        //Double[] numbers1= new Double[2] { 1.3,2.5 };
                        Double[] numbers2 = new Double[] { 1,2,3,4,5,6};
                        Double[] numbers3 = new[] { 1.5, 2.3, 3.5, 44.2, 50.2, 6 };

                        foreach (var item in numbers3)
                        {
                            res += item;
                            Console.WriteLine(res);
                        }
                        numbers[0] = 10.2;
                        numbers[1] = b;
                        numbers[2] = res;
                        Console.WriteLine(xd);

                        List<Double> numeros = new List<double>();
                        List<Double> numeros1 = new List<double>() { 1.2,4.5 };

                        numeros.Add(10.344);
                        numeros.Add(20.421);

                        foreach (var item in numeros)
                        {
                            Console.WriteLine($"{item:N1}");
                        }


                        Console.WriteLine(numeros1.Count);*/

            Console.WriteLine("Escriba un nombre para su libro de notas");

            String name = Console.ReadLine();

            IBook libro = new DiskBook(name);
            libro.EventoAddGrade += EventOnAddGrade;
            libro.EventoAddGrade += EventOnAddGrade;
            libro.EventoAddGrade += EventOnAddGrade;
      
            EjecutarCiclo(libro);

            var stat = libro.GetStatistic();
            Console.WriteLine($"The high grade is {stat.highGrade}");
            Console.WriteLine($"The low grade is {stat.lowGrade}");
            Console.WriteLine($"The average grade is {stat.average}");
            Console.WriteLine($"The letter grade is {stat.letter}");
            



            //BookInMemory david = new BookInMemory(name);

            //david.AddGrade(29.5);
            //david.AddGrade(30.5);
            //david.AddGrade(90.9);
            //david.AddGrade(10.3);
            //david.AddGrade(5);
            //david.ShowHighGrade();
            //david.ShowLowGrade();
            //david.ShowPromedio();

            /*david.EventoAddGrade += EventOnAddGrade;
            david.EventoAddGrade += EventOnAddGrade;
            david.EventoAddGrade -= EventOnAddGrade;
            david.EventoAddGrade += EventOnAddGrade;


            Console.WriteLine("Digite notas mayores que 0 | < 100 ");
            EjecutarCiclo(david);

            Console.WriteLine(david.nameBook);
            //david.nameBook = "xd";
            Statistics stats = david.GetStatistic();
            Console.WriteLine($"The high grade is {stats.highGrade}");
            Console.WriteLine($"The low grade is {stats.lowGrade}");
            Console.WriteLine($"The average grade is {stats.average}");
            Console.WriteLine($"The letter grade is {stats.letter}");
*/


        }

        private static void EjecutarCiclo(IBook david)
        {
            Boolean terminar = false;
            do
            {
                Console.WriteLine("Digite una nota o q para salir");

                var output = Console.ReadLine();

                if (output == "q")
                {
                    terminar = true;

                }
                else if (output == "")
                {
                    Console.WriteLine("Ingrese un valor valido");

                }
                else if (output != "")
                {
                    try
                    {
                        david.AddGrade(Double.Parse(output));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }



            } while (!terminar);
        }

        static void EventOnAddGrade(Object sender,EventArgs args)
        {
            Console.WriteLine("Se agrego una nota");
        }
    }

}
