using System;
using System.Collections.Generic;
using System.Text;

namespace Beginning_Collections
{
    class Pais
    {
        public string Nombre;
        public string Code;
        public string Region;
        public int Poblacion;

        public Pais(string nombre, string code, string region, int poblacion)
        {
            Nombre = nombre;
            Code = code;
            Region = region;
            Poblacion = poblacion;
        }
    }
}
