using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.Controllers;

public static class FotoSizes
{
    public const string Original = "original";
    public const string Small = "small";
    public const string Medium = "medium";
    public const string Large = "large";
}

public class FileController : Controller
{
    private readonly IRepositoriMahasiswa _repositoriMahasiswa;
    private readonly IRepositoriFoto _repositoriFoto;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileController(IRepositoriMahasiswa repositoriMahasiswa, 
        IRepositoriFoto repositoriFoto, 
        IWebHostEnvironment webHostEnvironment)
    {
        _repositoriMahasiswa = repositoriMahasiswa;
        _repositoriFoto = repositoriFoto;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> FotoProfil(string id)
    {
        var mahasiswa = await _repositoriMahasiswa.Get(id);

        if(mahasiswa == null)
            return NotFound();

        return File(mahasiswa.FotoProfil, "image/png");
    }

    public async Task<IActionResult> Foto(int id, string size = FotoSizes.Original)
    {
        var foto = await _repositoriFoto.Get(id);

        if(foto is null) return NotFound();

        var path = size switch
        {
            FotoSizes.Original => foto.Path,
            FotoSizes.Small => foto.Small,
            FotoSizes.Medium => foto.Medium,
            FotoSizes.Large => foto.Large,
            _ => string.Empty
        };

        if(!System.IO.File.Exists(path)) return NotFound();

        return PhysicalFile(path, $"image/{Path.GetExtension(path).Replace(".", "")}");
    }
}
