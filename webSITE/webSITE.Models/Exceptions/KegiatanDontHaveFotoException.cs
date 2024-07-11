﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Exceptions.Abstraction;

namespace webSITE.Domain.Exceptions
{
    public class KegiatanDontHaveFotoException : DomainException
    {
        public KegiatanDontHaveFotoException(int idKegiatan, int idFoto) 
            : base($"Kegiatan dengan Id : {idKegiatan} tidak punya Foto dengan Id : {idFoto}")
        {
        }
    }
}