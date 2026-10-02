// HOW-TO: Extract WMF Images From Zip And Convert To BMP In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.zip";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (FileStream zipStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (string.Equals(Path.GetExtension(entry.FullName), ".wmf", StringComparison.OrdinalIgnoreCase))
                    {
                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(entry.FullName) + ".bmp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (Stream entryStream = entry.Open())
                        using (MemoryStream ms = new MemoryStream())
                        {
                            entryStream.CopyTo(ms);
                            ms.Position = 0;

                            using (Image image = Image.Load(ms))
                            {
                                BmpOptions options = new BmpOptions();
                                options.BitsPerPixel = 24;
                                image.Save(outputPath, options);
                            }
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

/*
 * Real-World Use Cases:
 * 1. When you receive a zip package containing WMF vector graphics and need to generate BMP raster files for legacy Windows applications.
 * 2. When automating a batch process that extracts each WMF from an archive and saves it as a 24‑bit BMP for printing or further image analysis.
 * 3. When integrating Aspose.Imaging into a C# service that converts user‑uploaded WMF files inside zip uploads to BMP thumbnails.
 * 4. When migrating old WMF assets stored in compressed archives to BMP format to ensure compatibility with systems that only support bitmap images.
 * 5. When creating a command‑line tool that reads a zip file, filters WMF entries, and outputs BMP files to a specified output directory.
 */
