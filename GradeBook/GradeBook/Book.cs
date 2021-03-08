using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    /// <summary>
    /// sirve para hacer una implementacion del metodo AddGrade abstracto y se sobrescribe en la clase Book 
    /// con la palabra reservada override
    /// la diferencia entre clase abstracta y interfaz es que la clase abs deja instanciar y definir metodos 
    /// </summary>
    public abstract class Book : NameObject, IBook
    {
        protected Book(string nameBook) : base(nameBook)
        {
        }

        //La palabra reservada virtual sirve para decir que esos metodos pueden ser sobrescritos por una clase hijo o mas baja esos metodos son de IBook
        string IBook.nameBook => throw new NotImplementedException();

        public  abstract event DelegateEvento EventoAddGrade;


        //public virtual event DelegateEvento EventoAddGrade;

        public abstract void AddGrade(Double grade);

        public abstract Statistics GetStatistic();

        /*public virtual Statistics GetStatistic()
        {
            throw new NotImplementedException();
        }*/


    }
}
