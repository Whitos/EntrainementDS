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
                .ReverseMap()
                .ForMember(dest => dest.Commandes, opt => opt.Ignore()); // Ignorer la liste des commandes lors du mapping inverse

            CreateMap<Commande, CommandeDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Utilisateur, opt => opt.Ignore()); // Ignorer l'utilisateur lors du mapping inverse
        }
    }
}
