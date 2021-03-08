using System;
using System.Collections.Generic;

namespace Prueba
{
    class Program
    {

        static void Main(string[] args)
        {
            //cw Console.WriteLine("");
            // System.Console.WriteLine("Xd"); // alternativa para  no usar el namespace System.
            //Console.WriteLine("Hola mundo"); // mostrar datos en consola
            //Console.Read(); // para pausar la ejecucion y que se presione enter y siga.

            // declaracion de variable

            /*

            String das;
            string xd = "soy makia2";
            int mes = 18;
            Double nume = 2.4;
            DateTime fecha;
            bool xds =true;
            Boolean omg;

            das = "soy makia";

            Console.WriteLine(das);


            //llamar metodo
            escribeHolaMundo();
            escribeString("david");

            int numeroSumado = suma(2, 5);
            Console.WriteLine(numeroSumado);

            Console.Read();

            */


            //preguntaNombreEdad();


            //Es un ejemplo de clase

            Persona persona = new Persona();
            persona.nombre = "David";
            persona.apellido = "H";
            persona.direccion = "xdsads";
            persona.edad = 19;

            persona.mostrarDatos();
            //VAR SOLO SIRVE CUANDO SE LE ASIGNA UN VALOR SI NO SE LE ASIGNA NO SE PUEDE USAR
            //var nombre ; da error 
            var persona2 = new Persona();
            persona.nombre = "David2";
            persona.apellido = "H2";
            persona.direccion = "xdsads2";
            persona.edad = 19;


            List<String> nombres1 = new List<string>() { "felipe", "david", "leonardo" };

            int i = 0;
            while (i < nombres1.Count)
            {
                Console.WriteLine(nombres1[i].ToUpper());
                i++;

            }

                int a = 1;
                int b = 0;

                Console.WriteLine(a + " ajajaj " + b);

                String david = "yo me llamo david";

                String output = String.Format("soy un string formar {0}", david);
            try
            {
                int c = a / b;

            }
            catch (Exception e)
            {

                Console.WriteLine("Ha habido un error xD", e);
            }

            Console.Read();


            Console.WriteLine(output);

          

        }

        /// <summary>
        /// En una clase de ejemplo
        /// </summary>
        class Persona
        {

            public String nombre;
            public String apellido;
            public string direccion;
            public int edad;

            public void mostrarDatos()
            {
                String output = "nombre: {0} , apellido: {1}, direccion: {2}, edad: {3}";
                output = String.Format(output, nombre, apellido, direccion, edad);

                Console.WriteLine(output);
            }

        }



        /// <summary>
        /// Enums y numeros magicos
        /// </summary>
        enum estatusOperacion
        {
            Exitoso = 1,
            ClienteNoEncontrado = 2,
            ErrorDeSistema = 5
        }
        static void enumsyNumerosMagicos()
        {
            //Sirve para hacer un objeto de numeros que sirven para definir cosas
            int estatusDeOperacion = 5;

            if (estatusDeOperacion == (int)estatusOperacion.Exitoso)
            {
                Console.WriteLine("Estado Exitoso");
            }
            else if (estatusDeOperacion == (int)estatusOperacion.ClienteNoEncontrado)
            {
                Console.WriteLine("Estado Cliente No Encontrado");
            }
            else if (estatusDeOperacion == (int)estatusOperacion.ErrorDeSistema)
            {
                Console.WriteLine("Estado Error de Sistema");

            }

        }



        /// <summary>
        /// Funciones de Tipo String y for/foreach
        /// </summary>
        static void funcionesString()
        {

            String cadena = "David Andres Hernandez";

            //metodos

            //length
            Console.WriteLine(cadena.Length);

            //SubString
            //corta la cadena desde donde empiece o termine dependiendo si le envia 1 o 2 parametros
            Console.WriteLine(cadena.Substring(2));
            //vid Andres Hernandez

            //cadena.StartsWith
            //true o false si lo que se le pase empieza por esa palabra
            Console.WriteLine(cadena.StartsWith("David"));

            //cadena.EndsWith
            //true o false si lo que se le pase termina por esa palabra
            Console.WriteLine(cadena.EndsWith("Hernandez"));

            //cadena.Contains()
            //true o false si contiene la palabra
            Console.WriteLine(cadena.Contains("David"));


            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }

            List<String> nombres = new List<string>() { "felipe", "david", "leonardo" };

            for (int i = 0; i < nombres.Count; i++)
            {
                Console.WriteLine(nombres[i]);
            }

            Console.WriteLine("------Foreach");
            Console.WriteLine("");
            foreach (String item in nombres)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// El tipo DateTime y algunas funciones
        /// </summary>
        static void fechaFunciones()
        {
            //Operadores_Ejemplos();

            DateTime fecha = new DateTime(2019, 7, 30);
            DateTime fechaHoras = new DateTime(2020, 7, 12, 14, 44, 10);
            Console.WriteLine("fecha: " + fecha.ToString());
            Console.WriteLine("fecha: " + fecha.ToString("MM/dd/yyyy"));
            Console.WriteLine("fecha: " + fecha.ToString("dd/MM/yyyy"));
            Console.WriteLine("fecha: " + fechaHoras.ToString("hh:mm:ss"));

            Console.WriteLine("fechaHoras:" + fechaHoras.ToString());

            Console.WriteLine(fecha.Day);
            Console.WriteLine(fechaHoras.AddDays(2).ToString());
            Console.WriteLine(fechaHoras.DayOfWeek);
            Console.WriteLine(fechaHoras.Month);

            //Console.WriteLine(fecha.CompareTo(fechaHoras));
            Console.WriteLine(fechaHoras.Subtract(fecha).Days);

        }

        /// <summary>
        ///  Hacer un programa que le pregunte al usuario su nombre edad posterior a eso debe mostrar un mensaje en pantalla con el nombre de usuario y su edad.
        /// </summary>
        static void preguntaNombreEdad()
        {

            String nombre;
            int edad;
            Console.Write("Ingrese su nombre: ");

            nombre = Console.ReadLine();

            Console.Write("Ingrese su edad: ");

            edad = int.Parse(Console.ReadLine());

            //Console.WriteLine("Su nombre es "+nombre +" y su edad es "+edad);

            String output = String.Format("Su nombre es {0} y su edad es {1}", nombre, edad);

            Console.WriteLine(output);
            Console.Read();

        }

        /// <summary>
        /// Varios ejemplos de algunos de los operadores de C#.
        /// </summary>
        static void Operadores_Ejemplos()
        {
            // asignación
            var a = 1;
            var b = 2;
            var c = 8;
            var d = 9;
            string templateEncabezado = "\n--- {0} ---\n";

            Console.WriteLine(templateEncabezado, "Operaciones aritméticas");
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            Console.WriteLine("{0} - {1} = {2}", c, a, c - a);
            Console.WriteLine("{0} * {1} = {2}", b, c, b * c);
            Console.WriteLine("{0} / {1} = {2}", c, b, c / b);

            //Como 1 y 2 son enteros, al dividirlos nos devuelve un entero y no un double
            Console.WriteLine("{0} / {1} = {2}", a, b, a / b);

            // Si escribimos 1.0 entonces el resultado de la división es de tipo double, pues 1.0 es double
            Console.WriteLine("{0} / {1} = {2}", "1.0", b, 1.0 / b);

            // Incremento en 1 el valor de a
            a++;
            Console.WriteLine("El incremento de {0} es {1} pues x++ = x + 1", a - 1, a);

            // Disminuyo en 1 el valor de a
            a--;
            Console.WriteLine("El decremento de {0} es {1} pues x-- = x - 1", a + 1, a);


            // Operaciones de relacion
            Console.WriteLine(templateEncabezado, "operaciones de relación");
            Console.WriteLine("{0} < {1} es {2}", a, b, a < b);
            Console.WriteLine("{0} < {1} es {2}", c, a, c < a);

            Console.WriteLine("{0} > {1} es {2}", a, b, a > b);
            Console.WriteLine("{0} > {1} es {2}", d, b, d > b);

            Console.WriteLine("{0} <= {1} es {2}", c, d, c <= d);
            Console.WriteLine("{0} <= {0} es {1}", b, b <= b);

            Console.WriteLine("{0} >= {1} es {2}", c, d, c >= d);
            Console.WriteLine("{0} >= {0} es {1}", a, a >= a);

            Console.WriteLine("{0} is int = {1}", a, a is int);
            Console.WriteLine("{0} is string = {1}", a, a is string);

            Console.WriteLine("{0} == {1} = {2}", a, b, a == b);
            Console.WriteLine("{0} == {0} = {1}", a, a == a);

            Console.WriteLine("{0} != {1} = {2}", c, d, c != d);
            Console.WriteLine("{0} != {0} = {1}", b, b != b);



            // operaciones logicas
            Console.WriteLine(templateEncabezado, "operaciones lógicas");
            var booleano = true;
            Console.WriteLine("Operación negación: !{0} = {1} ", booleano, !booleano);

            Console.WriteLine("Conjuncion");
            Console.WriteLine("");
            Console.WriteLine("{0} & {0} = {1}", true, true & true);
            Console.WriteLine("{0} & {0} = {1}", false, false & false);
            Console.WriteLine("{0} & {1} = {2}", true, false, true & false);

            Console.WriteLine("disyuncion exclusiva");
            Console.WriteLine("");
            Console.WriteLine("{0} ^ {0} = {1}", true, true ^ true);
            Console.WriteLine("{0} ^ {0} = {1}", false, false ^ false);
            Console.WriteLine("{0} ^ {1} = {2}", true, false, true ^ false);

            Console.WriteLine("disyuncion inclusiva");
            Console.WriteLine("");
            Console.WriteLine("{0} | {0} = {1}", true, true | true);
            Console.WriteLine("{0} | {1} = {2}", true, false, true | false);
            Console.WriteLine("{0} | {1} = {2}", false, false, false | false);

            /*            int? enteroNulo = null;
                        int? enteroNoNulo = 7;
                        Console.WriteLine("{0} ?? {1} = {2}", enteroNoNulo, a, enteroNoNulo ?? a);
                        Console.WriteLine("null ?? {0} = {1}", a, enteroNulo ?? a);

                        Console.WriteLine("{0} ? {1} : {2} = {3}", true, a, b, true ? a : b);
                        Console.WriteLine("{0} ? {1} : {2} = {3}", false, a, b, false ? a : b);*/
        }

        static int suma(int num1, int num2)
        {
            return num1 + num2;
        }

        static void escribeHolaMundo()
        {
            Console.WriteLine("Hola mundo");
        }

        static void escribeString(String cadena)
        {
            Console.WriteLine(cadena);
        }

        static void identificadorDeMetodo(String parametro1, String parametro2, int etc)
        {
            Console.WriteLine();
        }

    }
}
