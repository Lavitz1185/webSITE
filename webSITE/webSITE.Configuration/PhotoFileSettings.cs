namespace webSITE.Configuration
{
    public class PhotoFileSettings
    {
        public string StoredFilesPath { get; set; }
        public long FileSizeLimit { get; set; } //In Byte
        public string[] PermittedExtension { get; set; }
    }
}
