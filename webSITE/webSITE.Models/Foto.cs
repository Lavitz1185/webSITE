using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.FotoExceptions;

namespace webSITE.Domain;

public class Foto : Entity, IAuditableEntity
{
    private readonly List<Mahasiswa> _daftarMahasiswa = new();
    private readonly List<Kegiatan> _daftarKegiatan = new();

    public string Path { get; set; } = string.Empty;
    public string Small { get; set; } = string.Empty;
    public string Medium { get; set; } = string.Empty;
    public string Large { get; set; } = string.Empty;

    public DateTime AddedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public IReadOnlyList<Kegiatan> DaftarKegiatan { get => _daftarKegiatan; }
    public IReadOnlyList<Mahasiswa> DaftarMahasiswa { get => _daftarMahasiswa; }
    public Mahasiswa? Creator { get; set; }

    public void AddMahasiswa(Mahasiswa mahasiswa)
    {
        var duplikasi = DaftarMahasiswa.Any(m => m.Id == mahasiswa.Id);

        if (duplikasi) throw new FotoAlreadyHaveMahasiswaException(mahasiswa.Nim);

        _daftarMahasiswa.Add(mahasiswa);
    }

    public void DeleteMahasiswa(Mahasiswa mahasiswa)
    {
        var exists = DaftarMahasiswa.Any(m => m.Id == mahasiswa.Id);

        if (!exists) throw new FotoDontHaveMahasiswaException(mahasiswa.Nim);

        _daftarMahasiswa.Add(mahasiswa);
    }
}