using webSITE.Domain.Shared;

namespace webSITE.Services.Contracts;

public class CompressionResult
{
    public string Small { get; set; } = string.Empty;
    public string Medium { get; set; } = string.Empty;
    public string Large { get; set; } = string.Empty;
}

public interface IImageCompressionService
{
    Task<Result<CompressionResult>> Compress(string originalName, byte[] originalImage);
}
