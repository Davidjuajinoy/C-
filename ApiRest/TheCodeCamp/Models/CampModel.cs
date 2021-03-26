using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCodeCamp.Models
{
    /// <summary>
    /// Sirve para mostrar los datos que la api va a ver y no mostrar los datos con los mismo nombres que los de la db
    /// para esto se requiere usar un automapper 
    /// </summary>
    public class CampModel
    {   
        [Required]
        public string Name { get; set; }
        [Required]
        public string Moniker { get; set; }

        public DateTime EventDate { get; set; } = DateTime.MinValue;
        [Required]
        [Range(3,100)]
        public int Length { get; set; } = 1;

        /*Talk*/
        public ICollection<TalkModel> Talks { get; set; }

        /*End Talk*/

        /*Relacionar Location con estos valores*/

        //Esta se hizo desde CampMappingProfile
        public string Venue { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationCityTown { get; set; }
        public string LocationStateProvince { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationCountry { get; set; }



    }
}
