using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, options);
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
 * 1. When a developer must verify the presence of an input.tif file and create a duplicate in a standardized TIFF format using Aspose.Imaging’s Image.Load and TiffOptions for downstream processing.
 * 2. When an application needs to load a multi‑frame TIFF, optionally re‑encode it, and save it to a specific output directory to ensure compatibility with other imaging tools.
 * 3. When a batch conversion job requires reading a TIFF, applying the default TiffExpectedFormat, and writing the result to reduce file size or normalize compression.
 * 4. When a .NET service has to handle missing TIFF files gracefully, log an error, and prevent crashes before attempting any image manipulation.
 * 5. When a migration script uses Aspose.Imaging to copy legacy TIFF assets into a new folder structure while preserving all frames and metadata for archival purposes.
 */