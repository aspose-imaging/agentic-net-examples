using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input zip file and output directory
        string zipPath = @"C:\Data\wmf_files.zip";
        string outputDirectory = @"C:\Data\ConvertedBmp";

        // Verify input zip exists
        if (!File.Exists(zipPath))
        {
            Console.Error.WriteLine($"File not found: {zipPath}");
            return;
        }

        // Ensure the output directory exists (creates parent directories as needed)
        Directory.CreateDirectory(outputDirectory);

        // Open the zip archive for reading
        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                // Process only WMF files
                if (!entry.FullName.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Build output BMP file path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(entry.Name) + ".bmp");

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