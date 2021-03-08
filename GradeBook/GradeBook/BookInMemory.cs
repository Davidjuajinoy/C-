using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public delegate void DelegateEvento(Object sender , EventArgs args);


    //public class BookInMemory : Book , IBook
    /// <summary>
    /// Clase de Libro En memoria heredando Book
    /// </summary>
    public class BookInMemory : Book 
    {

        //evento
        public override event DelegateEvento EventoAddGrade;

        private List<Double> arrayGrade;
        //private String nameBook;

        //este atributo solo se puede definir asi o en un constructor
        readonly String soloLectura = "david";

        public const String CATEGORIA = "es una constante";

        /// <summary>
        /// es un ejemplo de darle a un atributo propiedades.
        /// </summary>
        /*public String nameBook
        {
            get;
            //private set;
            set;
        }*/

        public BookInMemory(String nameBook) : base(nameBook)
        {
            //this.nameBook = nameBook;
            this.arrayGrade = new List<double>();
        }
    
        public override void AddGrade(Double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.arrayGrade.Add(grade);

                //evento delegado
                if (EventoAddGrade != null)
                {
                    EventoAddGrade(this,new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"El valor asignado no es valido {nameof(grade)}");
                //Console.WriteLine("El valor asignado no es valido");
            }
        }

        public void ShowGrade()
        {
            Console.WriteLine("Las notas son: ");
            foreach (var item in arrayGrade)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowHighGrade()
        {
            Console.WriteLine("La nota mas alta es: ");
            var HighGrade = arrayGrade[0];
            foreach (var item in arrayGrade)
            {
                HighGrade = Math.Max(item, HighGrade);
            }

            Console.WriteLine(HighGrade);
        }

        public void ShowLowGrade()
        {
            Console.WriteLine("La nota mas alta es: ");
            var HighGrade = arrayGrade[0];
            foreach (var item in arrayGrade)
            {
                HighGrade = Math.Min(item, HighGrade);
            }

            Console.WriteLine(HighGrade);
        }


        public void ShowPromedio()
        {
            Console.WriteLine("La nota mas Promedio es: ");
            Double Promedio = 0;
            foreach (var item in arrayGrade)
            {
                Promedio += item;
            }

            Promedio /= arrayGrade.Count;

            Console.WriteLine(Promedio);
        }


        public override Statistics GetStatistic()
        {
            Statistics resultado = new Statistics();

            resultado.Asignar(arrayGrade);

            return resultado;

            //for (int i = 0; i < arrayGrade.Count; i++)
            //{
            //    resultado.average += arrayGrade[i];
            //    resultado.highGrade = Math.Max(arrayGrade[i], resultado.highGrade);
            //    resultado.lowGrade = Math.Min(arrayGrade[i], resultado.lowGrade);
            //}


            /*     int i = 0;
                 do
                 {
                     resultado.average += arrayGrade[i];
                     resultado.highGrade = Math.Max(arrayGrade[i], resultado.highGrade);
                     resultado.lowGrade = Math.Min(arrayGrade[i], resultado.lowGrade);
                     i++;

                 } while (i < arrayGrade.Count);*/

            /*   foreach (var item in arrayGrade)
               {
                   resultado.average +=item ;
                   resultado.highGrade = Math.Max(item,resultado.highGrade);
                   resultado.lowGrade = Math.Min(item, resultado.lowGrade);
               }*/

/*            resultado.average /= arrayGrade.Count;

            switch (resultado.average)
            {
                case var d when d >= 90.0:
                    resultado.letter = 'A';
                    break;

                case var d when d >= 80.0:
                    resultado.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    resultado.letter = 'C';
                    break;

                case var d when d >= 60.0:
                    resultado.letter = 'D';
                    break;

                default:
                    resultado.letter = 'F';
                    break;
            }*/

            //return resultado;

        }


    }
}
