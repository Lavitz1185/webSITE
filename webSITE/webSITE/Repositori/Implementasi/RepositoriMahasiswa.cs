using webSITE.Models;
using webSITE.Repositori.Interface;

namespace webSITE.Repositori.Implementasi
{
    public class RepositoriMahasiswa : IRepositoriMahasiswa
    {
        static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>()
        {
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            },
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            },
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            },
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            },
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            },
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            },
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            },
            new Mahasiswa
            {
                Nim = "2206080051",
                NamaLengkap = "Adi Juanito Taklal",
                NamaPanggilan = "Adi",
                TanggalLahir = new DateTime(2004, 2, 29),
                JenisKelamin = JenisKelamin.LakiLaki,
                Email = "aditaklal@gmail.com",
                Password = "adiairnona",
                PhotoPath = "/img/contoh.jpeg"
            }
        };

        public async Task<Mahasiswa> Create(Mahasiswa entity)
        {
            var mahasiswa = mahasiswaList.FirstOrDefault(m => m.Nim == entity.Nim);
            if(mahasiswa == null)
                mahasiswaList.Add(entity);

            return mahasiswa;
        }

        public async Task<Mahasiswa> Delete(string id)
        {
            var mahasiswa = mahasiswaList.FirstOrDefault(m => m.Nim == id);
            if(mahasiswa != null)
                mahasiswaList.Remove(mahasiswa);
            return mahasiswa;
        }

        public async Task<Mahasiswa> Get(string id)
        {
            var mahasiswa = mahasiswaList.FirstOrDefault(m => m.Nim == id);
            return mahasiswa;
        }

        public async Task<IEnumerable<Mahasiswa>> GetAll()
        {
            var list = mahasiswaList.AsEnumerable();
            return list;
        }

        public async Task<Mahasiswa> Update(Mahasiswa entity)
        {
            var mahasiswa = await Get(entity.Nim);
            if(mahasiswa != null )
            {
                mahasiswa.NamaLengkap = entity.NamaLengkap;
                mahasiswa.NamaPanggilan =  entity.NamaPanggilan;
                mahasiswa.TanggalLahir = entity.TanggalLahir;
                mahasiswa.JenisKelamin = entity.JenisKelamin;
                mahasiswa.Email = entity.Email;
                mahasiswa.Password = entity.Password;
                mahasiswa.PhotoPath = entity.PhotoPath;
            }

            return mahasiswa;
        }
    }
}
