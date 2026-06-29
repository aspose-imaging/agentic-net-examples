using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image from a memory stream
            byte[] emfData = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(emfData))
            using (Image image = Image.Load(memoryStream))
            {
                // Configure TIFF save options with LZW compression
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw
                };

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a Windows desktop application needs to convert vector‑based EMF reports stored in a database into compressed TIFF files for archival or printing.
 * 2. When a web service receives EMF graphics as byte arrays via an API and must generate LZW‑compressed TIFF images for downstream document management systems.
 * 3. When a batch processing tool reads EMF logo files from a file share, loads them from memory to avoid locking the source files, and saves them as TIFF with lossless LZW compression for inclusion in PDF portfolios.
 * 4. When a migration script extracts EMF drawings from legacy CAD software, streams the data in memory, and converts them to TIFF to meet the image format requirements of a new ERP system.
 * 5. When an automated testing framework captures EMF screenshots as byte streams and needs to store them as compact TIFF files with LZW compression for efficient test result storage.
 */