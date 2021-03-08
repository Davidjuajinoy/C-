using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    /// <summary>
    /// Sirve como plantilla de metodos para una clase y no se puede instancias ni definir el codigo de los metodos
    /// </summary>
    public interface IBook
    {
        void AddGrade(Double grade);
        Statistics GetStatistic();
        String nameBook { get; }
        event DelegateEvento EventoAddGrade;

    }
}
