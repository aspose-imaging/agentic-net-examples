using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input zip file path
        string zipPath = @"C:\Data\wmf_files.zip";

        // Verify the zip file exists
        if (!File.Exists(zipPath))
        {
            Console.Error.WriteLine($"File not found: {zipPath}");
            return;
        }

        // Hardcoded output directory for BMP files
        string outputDir = @"C:\Data\ConvertedBmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Open the zip archive for reading
        using (FileStream zipStream = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
        using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                // Process only WMF files
                if (!entry.FullName.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Determine output BMP file path
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(entry.FullName) + ".bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image from the zip entry stream and save as BMP
                using (Stream entryStream = entry.Open())
                using (Image image = Image.Load(entryStream))
                {
                    // Save using default BMP options
                    image.Save(outputPath, new BmpOptions());
                }
            }
        }
    }
}