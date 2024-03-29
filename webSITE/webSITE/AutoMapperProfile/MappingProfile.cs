﻿using AutoMapper;
using webSITE.Areas.Dashboard.Models.KegiatanController;
using webSITE.Areas.Dashboard.Models.MahasiswaController;
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
            CreateMap<Foto, Models.FotoController.TambahFotoVM>().ReverseMap();
            CreateMap<Mahasiswa, AccountIndexVM>().ReverseMap();
            CreateMap<Mahasiswa, AccountFotoVM>().ReverseMap();

            CreateMap<Mahasiswa, Mahasiswa>().ReverseMap();

            CreateMap<Kegiatan, TambahKegiatanVM>().ReverseMap();
        }
    }
}
