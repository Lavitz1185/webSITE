namespace webSITE.Configuration;

public class PDFFileSettingsOptions
{
    public const string PDFFileSettings = "PDFFileSettings";

    public string FolderPath { get; set; } = string.Empty;
    public int SizeLimit { get; set; }
}
