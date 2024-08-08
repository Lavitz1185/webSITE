using Microsoft.AspNetCore.Identity;
using webSITE.Domain.Enum;

namespace webSITE.Domain;

public class Mahasiswa : IdentityUser
{
    public const int MaxBioLength = 60;

    public string Nim { get; set; } = string.Empty;
    public string NamaLengkap { get; set; } = string.Empty;
    public string NamaPanggilan { get; set; } = string.Empty;
    public DateTime TanggalLahir { get; set; }
    public JenisKelamin JenisKelamin { get; set; }
    public byte[] FotoProfil { get; set; } = Array.Empty<byte>(); 
    public string Bio { get; set; } = string.Empty;

    [ProtectedPersonalData]
    public Uri? FacebookProfileLink { get; set; }

    [ProtectedPersonalData]
    public Uri? InstagramProfileLink { get; set; }

    [ProtectedPersonalData]
    public Uri? TikTokProfileLink { get; set; }

    public string StrJenisKelamin => JenisKelaminExtension.ToString(JenisKelamin);

    public List<Kegiatan> DaftarKegiatan { get; set; } = new();
    public List<Foto> DaftarFoto { get; set; } = new();
}
