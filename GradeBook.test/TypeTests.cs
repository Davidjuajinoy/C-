using System;
using Xunit;

namespace GradeBook.test
{

    //delegado describe y crea un nuevo tipo para .net 
    //sirve para hacer que una variable apunte o invoque diferentes metodos pero siempre tiene que retornar el mismo tipo (String,int,etc)
    public delegate String WriteLogDelegate(String logMessage);



    public class TypeTests
    {
        int count = 0;
        /// <summary>
        /// metodo para probar el delegate
        /// </summary>
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessageCount;

            //log = ReturnMessage;

            var result = log("Hola");
            //ejecutta todos los metodos agregados al delegado de una sola vez por eso retorna 2 el count
            Assert.Equal(2,count );
        }
        String ReturnMessageCount(String message)
        {
            count++;
            return message;
        }
        /// <summary>
        /// METODO QUE RETORNA UN MSG ES PRUBA DE DELEGADO
        /// </summary>
        String ReturnMessage(String message)
        {
            count++;
            return message;
        }



        [Fact]
        public void StringReferencia()
        {
            var cadena ="david";
            MakeUpperCase(cadena);
            var upper = MakeUpperCase(cadena);
            //cambia porque se guarda en una variable 

            Assert.Equal("david", cadena); 
            Assert.Equal("DAVID", upper);
        }

        String MakeUpperCase(string cadena)
        {
            return cadena.ToUpper();
        }

        [Fact]
        public void ObtenerInt()
        {
            var x =Getint();
            SetInt(ref x);
            Assert.Equal(10, x);

        }

        private void SetInt(ref int x)
        {
            x = 10;
        }

        int Getint()
        {
            return 20;
        }

        [Fact]
        public void SePuedeRenombrarSiSeCreaNuevaInstancia()
        {
            var obj1 = GetBook("book1");
            CanGetBookSetName(ref obj1, "libro1");
            //La diferencia con out es que exige que se mande en el metodo una instancia 
            Assert.Equal("libro1", obj1.nameBook);

        }


        /// <summary>
        /// se le agrega la palabra reservada ref | out en el parametro enviado para poder pasar por referencia y no por valor
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        void CanGetBookSetName(ref BookInMemory obj, string name)
        {
            //crea un objeto llamado obj en este metodo pero no es el mismo que el obj1 de arriba 
            obj = new BookInMemory(name);
        }

        [Fact]
        public void NoSePuedeRenombrarSiSeCreaNuevaInstancia()
        {
            var obj1 = GetBook("book1");
            GetBookSetName(obj1,"libro1");
            Assert.Equal("book1", obj1.nameBook);

        }

        void GetBookSetName( BookInMemory obj ,string name)
        {
            //crea un objeto llamado obj en este metodo pero no es el mismo que el obj1 de arriba 
            obj= new BookInMemory(name);
        }

        [Fact]
        public void CambiarNombreDeObjeto()
        {
            var obj1 = GetBook("book1");
            SetName(obj1, "Libro1");

            Assert.Equal("Libro1", obj1.nameBook);
           
        }

        void SetName(BookInMemory obj1, string name)
        {
            obj1.nameBook = name;
        }

        [Fact]
        public void RetornarDiferentesObjeto()
        {
            var obj1 = GetBook("book1");
            var obj2 = GetBook("book2");

            Assert.Equal("book1", obj1.nameBook);
            Assert.Equal("book2", obj2.nameBook);
            Assert.NotSame(obj1, obj2);
        }


        [Fact]
        public void DosVarPuedenTenerMismoObjeto()
        {
            var obj1 = GetBook("book1");
            var obj2 = obj1;


            Assert.Same(obj1,obj2);
            Assert.True(Object.ReferenceEquals(obj1, obj2));

        }

        BookInMemory GetBook(string name)
        {
            return new BookInMemory(name);
        }
    }
}
