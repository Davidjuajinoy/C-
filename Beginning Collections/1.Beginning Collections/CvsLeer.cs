using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Beginning_Collections
{
    class CvsLeer
    {
        private string _csvRutaArchivo;
        public CvsLeer(string RutaArchivo)
        {
            this._csvRutaArchivo= RutaArchivo;
        }


        /// <summary>
        /// crea el Array y lo retorna
        /// </summary>
        /// <param name="nPaises">tamaño del array</param>
/*        public Pais[] LeerNPaises(int nPaises)
        {
            Pais[] paisesArray = new Pais[nPaises];

            using(StreamReader sr = new StreamReader(_csvRutaArchivo))
            {
                sr.ReadLine();

                for (int i = 0; i < nPaises; i++)
                {
                    string csvLine = sr.ReadLine();
                    paisesArray[i] = GuardarPaisCsv(csvLine);
                }

            }

            return paisesArray;
        }*/

        public List<Pais> LeerTodosPaises()
        {
            List<Pais> paisesLista = new List<Pais>();

            using (StreamReader sr = new StreamReader(_csvRutaArchivo))
            {
                sr.ReadLine();
                string csvLine;
                while( (csvLine = sr.ReadLine()) != null)
                {
                    paisesLista.Add(GuardarPaisCsv(csvLine));
                }

            }

            return paisesLista;
        }

        /*public Pais GuardarPaisCsv(string csvLine)
        {
            //string[] separar = csvLine.Split(",");
            //para decirle que separe solo una
            string[] separar = csvLine.Split(new char[] { ',' });

            string nombre = separar[0];
            string codigo = separar[1];
            string region = separar[2];
            int poblacion = int.Parse(separar[3]);

            return new Pais(nombre, codigo, region, poblacion);
        }*/

        public Pais GuardarPaisCsv(String csvLine)
        {
            //string[] separar = csvLine.Split(",");
            //para decirle que separe solo una
            string[] separar = csvLine.Split( ',');

            string nombre;
            string codigo;
            string region;
            string poblacion;


            switch (separar.Length)
            {
                case 4:
                    {
                        nombre = separar[0];                    
                        codigo = separar[1];
                        region = separar[2];
                        poblacion = separar[3];
                        break;
                    }

                case 5:
                    nombre = separar[0] + ", " + separar[1];
                    nombre = nombre.Replace("\"", null).Trim();
                    codigo = separar[2];
                    region = separar[3];
                    poblacion = separar[4];
                    break;

                default:
                    throw new Exception($"Error de parse en csvLine {csvLine} ");
            }

            int.TryParse(poblacion, out int poblaciones);
            return new Pais(nombre, codigo, region, poblaciones);





        }

        /// <summary>
        /// recordar
        /// </summary>
        /// <param name="paises"></param>
        public void RemoverComas(List<Pais> paises)
        {
            //se recorre negativamente ya que asi evalua todos y no mueve espacios hacia abajo a diferencia del ciclo normal
            //for (int i = paises.Count-1 ; i >=0 ; i--)
            //{
            //    if(paises[i].Nombre.Contains(","))
            //    {
            //        paises.RemoveAt(i);
            //    }   
            //}

            paises.RemoveAll(pais => pais.Nombre.Contains(","));
        }
    }
}
