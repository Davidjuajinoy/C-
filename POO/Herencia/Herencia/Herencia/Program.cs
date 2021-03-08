using System;

namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var persona = new Persona();
            persona.Id = 2;

            var tobias = new Perro("Tobias");
            //tobias.HacerRuido();

            //var micha = new Gato();
            //micha.HacerRuido();
        }

        public class Entidad
        {
            public int Id { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaModificacion { get; set; }

        }

        public class Persona: Entidad
        {
            public String Nombre { get; set; }

        }

        interface IAnimal
        {
            void Xd()
            {
                Console.WriteLine("Xd");
            }
        }


        public abstract class Animal
        {
            protected Animal()
            {
                Console.WriteLine("Constructor de clase animal");
            }

            protected Animal(string param)
            {
                Console.WriteLine($"Constructor de clase {param}");
            }
            //public abstract void HacerRuido();
            public virtual void HacerRuido()
            {
                Console.WriteLine("LALALAL");
            }
        }

        class Perro : Animal
        {
            public Perro()
            {
                Console.WriteLine("Constructor clase Perro");
            }

            public Perro(string param) : base(param)
            {
                Console.WriteLine("Constructor clase Perro Con parametro");

            }

            public override void HacerRuido()
            {
                Console.WriteLine("GUA GUA");
            }
        }

        class Gato : Animal
        {
            public override void HacerRuido()
            {
                Console.WriteLine("MIU MIU");
            }
        }
    }
}
