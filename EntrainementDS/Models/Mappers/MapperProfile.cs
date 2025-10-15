using AutoMapper;   
using EntrainementDS.Models.EntityFramework;
using EntrainementDS.Models.DTO;

namespace EntrainementDS.Models.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Utilisateur, UtilisateurDTO>()
                .ForMember(dest => dest.NbCommande, opt => opt.MapFrom(src => src.Commandes.Count))
                .ReverseMap();

            CreateMap<Commande, CommandeDTO>()
                .ReverseMap();
        }
    }
}
