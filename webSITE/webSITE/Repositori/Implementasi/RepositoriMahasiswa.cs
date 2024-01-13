﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using webSITE.Models;
using webSITE.Repositori.Data;
using webSITE.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriMahasiswa : IRepositoriMahasiswa
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;

        public RepositoriMahasiswa(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Mahasiswa> Create(Mahasiswa entity)
        {
            var mahasiswa = await dbContext.TblMahasiswa.FirstOrDefaultAsync(m => m.Nim == entity.Nim);
            if(mahasiswa == null)
                await dbContext.AddAsync(entity);

            return mahasiswa;
        }

        public async Task<Mahasiswa> Delete(string id)
        {
            var mahasiswa = await Get(id);

            if (mahasiswa == null)
                return null;

            dbContext.TblMahasiswa.Remove(mahasiswa);
            await dbContext.SaveChangesAsync();

            return mahasiswa;
        }

        public async Task<Mahasiswa> GetByNim(string nim)
        {
            var mahasiswa = await dbContext.TblMahasiswa
                .Include(m => m.DaftarKegiatan)
                .Include(m => m.DaftarFoto)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Nim == nim);
            return mahasiswa;
        }

        public async Task<Mahasiswa> Get(string id)
        {
            return await dbContext.TblMahasiswa
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Mahasiswa>> GetAll()
        {
            var list = await dbContext.TblMahasiswa
                .AsNoTracking()
                .ToListAsync();
            return list;
        }

        public async Task<Mahasiswa> Update(Mahasiswa entity)
        {
            var mahasiswa = await dbContext.TblMahasiswa.FirstOrDefaultAsync(m => m.Id == entity.Id);

            if(mahasiswa != null )
            {
                dbContext.TblMahasiswa.Update(mahasiswa);
                mahasiswa.Nim = entity.Nim;
                mahasiswa.NamaLengkap = entity.NamaLengkap;
                mahasiswa.NamaPanggilan = entity.NamaPanggilan;
                mahasiswa.TanggalLahir = entity.TanggalLahir;
                mahasiswa.JenisKelamin = entity.JenisKelamin;
            }

            await dbContext.SaveChangesAsync();

            mahasiswa = await Get(entity.Id);

            return mahasiswa;
        }

        public async Task<Mahasiswa> SetProfilePicture(string id, byte[] photoData)
        {
            var mahasiswa = await dbContext.TblMahasiswa.FirstOrDefaultAsync(m => m.Id == id);

            if (mahasiswa == null)
                return null;

            dbContext.Update(mahasiswa);
            mahasiswa.FotoProfil = photoData;

            await dbContext.SaveChangesAsync();

            return mahasiswa;
        }

        public async Task<Mahasiswa> AddToFoto(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idMahasiswa, idFoto);

            if (mahasiswaFoto != null)
                return null;

            mahasiswaFoto = new MahasiswaFoto
            {
                IdMahasiswa = idMahasiswa,
                IdFoto = idFoto
            };

            dbContext.TblMahasiswaFoto.Add(mahasiswaFoto);

            await dbContext.SaveChangesAsync();

            return await Get(idMahasiswa);
        }

        public async Task<Mahasiswa> RemoveFromFoto(string idMahasiswa, int idFoto)
        {
            var mahasiswaFoto = await dbContext.TblMahasiswaFoto.FindAsync(idMahasiswa, idFoto);

            if (mahasiswaFoto == null)
                return null;

            dbContext.TblMahasiswaFoto.Remove(mahasiswaFoto);

            await dbContext.SaveChangesAsync();

            return await Get(idMahasiswa);
        }

        public async Task<Mahasiswa> AddToKegiatan(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan.FindAsync(idMahasiswa, idKegiatan);

            if (pesertaKegiatan != null)
                return null;

            pesertaKegiatan = new PesertaKegiatan
            {
                IdMahasiswa = idMahasiswa,
                IdKegiatan = idKegiatan
            };

            dbContext.TblPesertaKegiatan.Add(pesertaKegiatan);

            await dbContext.SaveChangesAsync();

            return await Get(idMahasiswa);
        }

        public async Task<Mahasiswa> RemoveFromKegiatan(string idMahasiswa, int idKegiatan)
        {
            var pesertaKegiatan = await dbContext.TblPesertaKegiatan.FindAsync(idMahasiswa, idKegiatan);

            if (pesertaKegiatan == null)
                return null;

            dbContext.TblPesertaKegiatan.Remove(pesertaKegiatan);

            await dbContext.SaveChangesAsync();

            return await Get(idMahasiswa);
        }

        public async Task<Mahasiswa> GetWithDetail(string id)
        {
            return await dbContext.TblMahasiswa
                .Include(m => m.DaftarFoto)
                .Include(m => m.DaftarKegiatan)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Mahasiswa>> GetAllWithDetail()
        {
            return await dbContext.TblMahasiswa
                .Include(m => m.DaftarFoto)
                .Include(m => m.DaftarKegiatan)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
