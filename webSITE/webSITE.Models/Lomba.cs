using webSITE.Domain.Abstractions;
using webSITE.Domain.Enum;
using webSITE.Domain.Exceptions;
using webSITE.Domain.Exceptions.LombaExceptions;
using webSITE.Domain.Exceptions.PesertaLombaExceptions;
using webSITE.Domain.Exceptions.TimLombaExceptions;

namespace webSITE.Domain
{
    public class Lomba : Entity
    {
        private readonly List<PesertaLomba> _daftarPeserta = new();
        private readonly List<TimLomba> _daftarTim = new();

        public string Nama { get; set; }
        public JenisLomba Jenis { get; set; }
        public string Keterangan { get; set; }
        public int MaksKuotaPerAngkatan { get; set; }
        public int? MinAnggotaPerTim { get; set; }
        public int? MaksAnggotaPerTim { get; set; }
        public bool? PasanganBedaJenisKelamin { get; set; }

        public IReadOnlyList<PesertaLomba> DaftarPeserta { get => _daftarPeserta; }
        public IReadOnlyList<TimLomba> DaftarTim { get => _daftarTim; }

        private Lomba(
            string nama,
            JenisLomba jenis,
            string keterangan,
            int maksKuotaPerAngkatan,
            int? minAnggotaPerTim,
            int? maksAnggotaPerTim,
            bool? pasanganBedaJenisKelamin)
        {
            Nama = nama;
            Jenis = jenis;
            Keterangan = keterangan;
            MaksKuotaPerAngkatan = maksKuotaPerAngkatan;
            MinAnggotaPerTim = minAnggotaPerTim;
            MaksAnggotaPerTim = maksAnggotaPerTim;
            PasanganBedaJenisKelamin = pasanganBedaJenisKelamin;
        }

        public static Lomba Create(
            string nama,
            JenisLomba jenis,
            string keterangan,
            int maksKuotaPerAngkatan,
            int? minAnggotaPerTim,
            int? maksAnggotaPerTim,
            bool? pasanganBedaJenisKelamin)
        {
            switch (jenis)
            {
                case JenisLomba.Tim:
                    if (maksAnggotaPerTim is null || maksAnggotaPerTim.Value < 2)
                        throw new LombaJenisTimMaksAnggotaPerTimNullException();
                    break;
                case JenisLomba.Pasangan:
                    if (pasanganBedaJenisKelamin is null)
                        throw new LombaJenisPasanganPasanganBedaJenisKelaminNullException();
                    minAnggotaPerTim = 2;
                    maksAnggotaPerTim = 2;
                    break;
            }

            if (maksKuotaPerAngkatan == 0)
                throw new LombaKuotaPerAngkatanZeroException();

            return new Lomba(
                nama,
                jenis,
                keterangan,
                maksKuotaPerAngkatan,
                minAnggotaPerTim ?? 2,
                maksAnggotaPerTim,
                pasanganBedaJenisKelamin);
        }

        public void TambahPeserta(PesertaLomba peserta)
        {
            if (Jenis != JenisLomba.Solo)
                throw new LombaInvalidJenisLombaException(
                    $"Tidak bisa menambah peserta pada lomba dengan jenis bukan solo");

            if (IsKuotaPenuh(peserta.Angkatan))
                throw new LombaKuotaAngkatanFullException(
                    $"Kuota lomba {Nama} untuk angkatan {peserta.Angkatan} penuh");

            var duplikasi = _daftarPeserta.Any(p => p.Nim == peserta.Nim);

            if (duplikasi)
                throw new LombaDuplicatePesertaException(
                    $"Lomba {Nama} sudah memiliki peserta dengan NIM : {peserta.Nim}");

            _daftarPeserta.Add(peserta);
        }

        public void TambahPesertaRange(List<PesertaLomba> daftarPeserta)
        {
            if (Jenis != JenisLomba.Solo)
                throw new LombaInvalidJenisLombaException(
                    $"Tidak bisa menambah peserta pada lomba dengan jenis bukan solo");

            _daftarPeserta.Clear();

            foreach (var peserta in daftarPeserta)
            {
                TambahPeserta(peserta);
            }
        }

        public void HapusPeserta(PesertaLomba peserta)
        {
            if (Jenis != JenisLomba.Solo)
                throw new LombaInvalidJenisLombaException(
                    $"Tidak bisa menghapus peserta pada lomba dengan jenis bukan solo");

            var exists = _daftarPeserta.Any(p => p.Id == peserta.Id);

            if (!exists)
                throw new PesertaLombaNotFoundException(
                    $"Lomba {Nama} tidak memiliki peserta dengan NIM : {peserta.Nim}");

            _daftarPeserta.Remove(peserta);
        }

        public void TambahTim(TimLomba tim)
        {
            if (Jenis != JenisLomba.Pasangan || Jenis != JenisLomba.Tim)
                throw new LombaInvalidJenisLombaException(
                    $"Tidak bisa menambah tim pada lomba dengan jenis bukan tim atau pasangan");

            switch (Jenis)
            {
                case JenisLomba.Pasangan:
                    if(tim.AnggotaTim.Count != 2)
                        throw new LombaTimLombaInvalidAnggotaCountException(
                            $"Untuk lomba jenis pasangan jumlah anggota tim harus 2");

                    if(PasanganBedaJenisKelamin!.Value)
                    {
                        if (tim.AnggotaTim.DistinctBy(p => p.JenisKelamin).Count() <= 1)
                            throw new LombaTimLombaInvalidAnggotaException(
                                $"Untuk lomba {Nama} tim pasangan wajib berbeda jenis kelamin");
                    }

                    break;
                case JenisLomba.Tim:
                    if (tim.AnggotaTim.Count < MinAnggotaPerTim)
                        throw new LombaTimLombaInvalidAnggotaCountException(
                            $"Jumlah anggota tim kurang dari minimal anggota per tim yaitu {MinAnggotaPerTim}");
                    if (tim.AnggotaTim.Count > MaksAnggotaPerTim)
                        throw new LombaTimLombaInvalidAnggotaCountException(
                            $"Jumlah anggota tim melebihi maksimal anggota per tim yaitu {MaksAnggotaPerTim}");
                    break;
            }

            if (!tim.AnggotaTim.All(p => p.Angkatan == tim.Angkatan))
                throw new LombaTimLombaInvalidAnggotaException(
                    $"Terdapat anggota tim yang bukan angkatan {tim.Angkatan}");

            if (IsKuotaPenuh(tim.Angkatan))
                throw new LombaKuotaAngkatanFullException(
                    $"Kuota lomba {Nama} untuk angkatan {tim.Angkatan} penuh");

            var duplikasi = _daftarTim.Any(t => t.NamaTim.ToUpper() == tim.NamaTim.ToUpper());

            if (duplikasi)
                throw new LombaTimLombaDuplicateException(
                    $"Lomba {Nama} sudah memiliki tim dengan Nama : {tim.NamaTim}");

            var duplikasiAnggota = _daftarTim.SelectMany(t => t.AnggotaTim)
                .Any(p => tim.AnggotaTim.Any(at => at.Nim == p.Nim));

            if (duplikasiAnggota)
                throw new LombaTimLombaInvalidAnggotaException(
                    $"Terdapat anggota tim yang sudah pernah mendaftar dengan tim berbeda");

            _daftarTim.Add(tim);
        }

        public void TambahTimRange(List<TimLomba> daftarTimLomba)
        {
            if (Jenis != JenisLomba.Pasangan || Jenis != JenisLomba.Tim)
                throw new LombaInvalidJenisLombaException(
                    $"Tidak bisa menambah tim pada lomba dengan jenis bukan tim atau pasangan");

            _daftarTim.Clear();

            foreach (var tim in daftarTimLomba)
            {
                TambahTim(tim);
            }
        }

        public void HapusTim(TimLomba tim)
        {
            if (Jenis != JenisLomba.Pasangan || Jenis != JenisLomba.Tim)
                throw new LombaInvalidJenisLombaException(
                    $"Tidak bisa menghapus tim pada lomba dengan jenis bukan tim atau pasangan");

            var exists = _daftarPeserta.Any(t => t.Id == tim.Id);

            if (!exists)
                throw new TimLombaNotFoundException(
                    $"Lomba {Nama} tidak memiliki tim dengan nama : {tim.NamaTim}");

            _daftarTim.Remove(tim);
        }

        private bool IsKuotaPenuh(Angkatan angkatan)
        {
            var kuotaAngkatan = 0;

            switch (Jenis)
            {
                case JenisLomba.Solo:
                    kuotaAngkatan = _daftarPeserta.Where(p => p.Angkatan == angkatan).Count();
                    break;
                case JenisLomba.Tim:
                case JenisLomba.Pasangan:
                    kuotaAngkatan = _daftarTim.Where(p => p.Angkatan == angkatan).Count();
                    break;
            }

            return MaksKuotaPerAngkatan == kuotaAngkatan;
        }
    }
}
