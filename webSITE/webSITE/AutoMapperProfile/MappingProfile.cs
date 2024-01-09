using AutoMapper;
using webSITE.Areas.Dashboard.Models;
using webSITE.Models;

namespace webSITE.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Mahasiswa, EditMahasiswaVM>().ReverseMap();
        }
    }
}
