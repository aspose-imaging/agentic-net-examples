using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input zip file and output directory
            string zipPath = @"C:\Data\wmf_archive.zip";
            string outputDir = @"C:\Data\ConvertedBmp";

            // Verify the zip file exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the zip archive for reading
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // Process only WMF files
                    if (string.Equals(Path.GetExtension(entry.FullName), ".wmf", StringComparison.OrdinalIgnoreCase))
                    {
                        // Build the output BMP file path
                        string outputPath = Path.Combine(
                            outputDir,
                            Path.GetFileNameWithoutExtension(entry.FullName) + ".bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Load the WMF image from the entry stream and save as BMP
                        using (Stream entryStream = entry.Open())
                        using (Image image = Image.Load(entryStream))
                        {
                            BmpOptions bmpOptions = new BmpOptions();
                            image.Save(outputPath, bmpOptions);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}