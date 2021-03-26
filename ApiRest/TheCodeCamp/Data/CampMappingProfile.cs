using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCodeCamp.Models;

namespace TheCodeCamp.Data
{
    /// <summary>
    /// Se configura el automapper y se tiene que configurar la inyeccion de dependencias
    /// </summary>
    public class CampMappingProfile : Profile
    {
        public CampMappingProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(c => c.Venue , opt => opt.MapFrom(m => m.Location.VenueName))
                .ReverseMap() //para que se pueda mapear alreves
                ;
            CreateMap<Talk, TalkModel>();
            CreateMap<Speaker, SpeakerModel>();
        }

    }
}
