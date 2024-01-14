using AutoMapper;
using webSITE.Areas.Dashboard.Models;
using webSITE.Domain;
using webSITE.Models.Account;
using webSITE.Models.FotoController;

namespace webSITE.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Mahasiswa, EditMahasiswaVM>().ReverseMap();
            CreateMap<Foto, TambahFotoVM>().ReverseMap();
            CreateMap<Mahasiswa, AccountIndexVM>().ReverseMap();
            CreateMap<Mahasiswa, AccountFotoVM>().ReverseMap();

            CreateMap<Mahasiswa, Mahasiswa>().ReverseMap();
        }
    }
}
