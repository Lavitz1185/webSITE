using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using webSITE.Configuration;
using webSITE.Domain.Shared;
using webSITE.Services.Contracts;

namespace webSITE.Services;

public class ImageCompressionService : IImageCompressionService
{
    private readonly PhotoFileSettingsOptions _photoFileSettingsOptions;
    private readonly ImageCompressionOptions _imageCompressionOptions;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILogger<ImageCompressionService> _logger;

    public ImageCompressionService(
        IOptionsSnapshot<PhotoFileSettingsOptions> photoFileSettingsOptions,
        IOptionsSnapshot<ImageCompressionOptions> imageCompressionOptions,
        IWebHostEnvironment webHostEnvironment,
        ILogger<ImageCompressionService> logger)
    {
        _photoFileSettingsOptions = photoFileSettingsOptions.Value;
        _imageCompressionOptions = imageCompressionOptions.Value;
        _webHostEnvironment = webHostEnvironment;
        _logger = logger;
    }

    public async Task<Result<CompressionResult>> Compress(string originalName, byte[] originalImage)
    {
        try
        {
            var encoder = new JpegEncoder { Quality = _imageCompressionOptions.CompressionQuality };
            var pathFile = $"{_webHostEnvironment.WebRootPath}/{_photoFileSettingsOptions.StoredFilesPath}";
            var compressResult = new CompressionResult
            {
                Small = $"{pathFile}{Path.GetFileNameWithoutExtension(originalName)}-small.jpeg",
                Medium = $"{pathFile}{Path.GetFileNameWithoutExtension(originalName)}-medium.jpeg",
                Large = $"{pathFile}{Path.GetFileNameWithoutExtension(originalName)}-large.jpeg",
            };

            await Compress(originalImage, _imageCompressionOptions.Small, compressResult.Small, encoder);
            await Compress(originalImage, _imageCompressionOptions.Medium, compressResult.Medium, encoder);
            await Compress(originalImage, _imageCompressionOptions.Large, compressResult.Large, encoder);

            return compressResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error when try to compress image. Message : {@message}. Timestamp : {@timeStamp}",
                ex.Message, DateTime.Now);

            return new Error("ImageCompress.Failed",
                "Terjadi error saat mencoba mengkompress gambar. Silahkan hubungi administrator");
        }
    }

    private static async Task Compress(
        byte[] data,
        System.Drawing.Size size,
        string outputPath,
        IImageEncoder encoder)
    {
        using var image = Image.Load(data);

        var newSize = GetNewSize(image.Size, size);


        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = newSize,
            Mode = ResizeMode.Stretch,
            Sampler = KnownResamplers.Bicubic
        }));

        await image.SaveAsync(outputPath, encoder);
    }

    private static Size GetNewSize(Size original, System.Drawing.Size limit)
    {
        if (original.Height <= limit.Height && original.Width <= limit.Width)
            return original;

        var ratioX = (double)limit.Width / original.Width;
        var ratioY = (double)limit.Height / original.Height;

        var ratio = Math.Min(ratioX, ratioY);

        return new Size((int)(original.Width * ratio), (int)(original.Height * ratio));
    }
}
