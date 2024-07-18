namespace webSITE.Configuration
{
    public class PhotoFileSettingsOptions
    {
        public const string PhotoFileSettings = "PhotoFileSettings";

        public string StoredFilesPath { get; set; } = string.Empty;
        public long FileSizeLimit { get; set; } //In Byte
        public string[] PermittedExtension { get; set; } = Array.Empty<string>();
    }
}
