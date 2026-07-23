// HOW-TO: Convert and Save TIFF Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

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
 * 1. When you need to read an existing TIFF file and re‑save it with specific Aspose.Imaging options to ensure compatibility with downstream systems.
 * 2. When you want to programmatically copy a TIFF image to a new location while preserving its metadata and compression settings.
 * 3. When a batch process must validate that a source TIFF exists before creating an output folder and writing the image.
 * 4. When you need to convert a single‑page TIFF into a default‑format TIFF for archival or further processing in a .NET application.
 * 5. When you are handling TIFF files in C# and want to catch and log any I/O or image‑processing errors gracefully.
 */
