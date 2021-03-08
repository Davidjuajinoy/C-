using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string nameBook) : base(nameBook)
        {
        }

        public override event DelegateEvento EventoAddGrade;

        public override void AddGrade(double grade)
        {
            //si se pone using en datos ejecutara el metodo Dispose el cual borra lo creado (es como un recolector de basura)
            using (var archivo = File.AppendText($"{nameBook}.txt") ) {

                archivo.WriteLine(grade);
                if (EventoAddGrade != null)
                {
                    EventoAddGrade(this, new EventArgs());
                }

                //archivo.Dispose();
            }


        }

        public override Statistics GetStatistic()
        {

            var resultado = new Statistics();

            List<Double> arrayGrade = new List<double>();

            using (var archivo = File.OpenText($"{nameBook}.txt"))
            {
                var line = archivo.ReadLine();
                while (line != null)
                {
                    if(double.Parse(line) <= 100 && double.Parse(line) >= 0)
                    {
                        arrayGrade.Add(double.Parse(line));
                    }
                    
                    line = archivo.ReadLine();
                }
            }

            resultado.Asignar(arrayGrade);
            return resultado;

        }
    }
}
