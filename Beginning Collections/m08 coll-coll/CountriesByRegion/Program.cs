using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.ReadAllCountries
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Users\david.hernandez\source\repos\Beginning Collections\m08 coll-coll\CountriesByRegion\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			Dictionary<string, List<Country>> countries = reader.ReadAllCountries();

			Console.WriteLine("Which of the above regions do you want? ");

			int count = 1;
			var ListaKeys = new List<string>();

			foreach (string region in countries.Keys)
            {
				Console.WriteLine($" {count++} {region}");
				ListaKeys.Add(region);
            }	

			bool done = false;
            do
            {
                Console.WriteLine("Digite el numero de la region o si quiere salir q");

				string input = Console.ReadLine();
				bool regionCorrecta = int.TryParse(input, out int regionElegida);

                if (regionCorrecta && regionElegida <= 6 && regionElegida > 0)
                {
					regionElegida -= 1;
                    if (countries.ContainsKey(ListaKeys[regionElegida]))
                    {
							foreach (Country country in countries[ListaKeys[regionElegida]].Take(10))
								Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
							
                    }

                }
				else if(input == "q")
                {
					done = true;
					break;
                }
                else
                {
                    Console.WriteLine("El valor digitado no es valido");
                }

            } while (!done);


			//if (countries.ContainsKey(chosenRegion))
			//{
			//	// display 10 highest population countries in the selected region
			//	foreach (Country country in countries[chosenRegion].Take(10))
			//		Console.WriteLine($"{PopulationFormatter.FormatPopulation (country.Population).PadLeft(15)}: {country.Name}");
			//}
			//else
			//	Console.WriteLine("That is not a valid region");
		}
	}
}
