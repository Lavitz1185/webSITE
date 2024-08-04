using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.KegiatanExceptions;

namespace webSITE.Domain
{
    public class Kegiatan : Entity
    {
        private readonly List<Foto> _daftarFoto = new();
        private readonly List<Mahasiswa> _daftarMahasiswa = new();

        public string NamaKegiatan { get; set; } = string.Empty;
        public DateTime Tanggal { get; set; }
        public int JumlahHari { get; set; }
        public string TempatKegiatan { get; set; } = string.Empty;
        public string Keterangan { get; set; } = string.Empty;
        public IReadOnlyList<Foto> DaftarFoto { get => _daftarFoto; }
        public IReadOnlyList<Mahasiswa> DaftarMahasiswa { get => _daftarMahasiswa; }

        public void AddFoto(Foto foto)
        {
            var duplikasi = DaftarFoto.Any(f => f.Id == foto.Id);

            if (duplikasi) throw new KegiatanAlreadyHaveFotoException(foto.Id);

            _daftarFoto.Add(foto);
        }

        public void AddDaftarFoto(List<Foto> daftarFoto)
        {
            _daftarFoto.Clear();

            foreach (var foto in daftarFoto)
            {
                AddFoto(foto);
            }
        }

        public void DeleteFoto(Foto foto)
        {
            var exists = DaftarFoto.Any(f => f.Id == foto.Id);

            if (!exists) throw new KegiatanDontHaveFotoException(NamaKegiatan, foto.Id);

            _daftarFoto.Remove(foto);
        }

        public void TambahPeserta(Mahasiswa mahasiswa)
        {
            var duplikasi = DaftarMahasiswa.Any(m => m.Id == mahasiswa.Id);

            if (duplikasi) throw new KegiatanAlreadyHaveMahasiswaException(mahasiswa.Nim);

            _daftarMahasiswa.Add(mahasiswa);
        }

        public void TambahDaftarPeserta(List<Mahasiswa> daftarMahasiswa)
        {
            _daftarMahasiswa.Clear();

            foreach (var mahasiswa in daftarMahasiswa)
            {
                TambahPeserta(mahasiswa);
            }
        }

        public void HapusPeserta(Mahasiswa mahasiswa)
        {
            var exists = DaftarMahasiswa.Any(m => m.Id == mahasiswa.Id);

            if (!exists) throw new PesertaKegiatanNotFoundException(mahasiswa.Nim);

            _daftarMahasiswa.Remove(mahasiswa);
        }
    }
}
