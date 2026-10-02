// HOW-TO: Convert PSD with Embedded EMF Text to TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.psd";
            string outputPath = "output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Save as TIFF, rasterizing any vector content (including EMF text)
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When you need to generate a print‑ready TIFF from a Photoshop PSD that contains EMF text layers, preserving the visual layout as rasterized vector graphics.
 * 2. When an automated workflow must convert design assets with embedded vector annotations into a single‑page TIFF for archival or downstream processing.
 * 3. When a web service receives PSD files with EMF captions and must output a TIFF that can be displayed in browsers without requiring vector support.
 * 4. When migrating legacy Photoshop documents to a format compatible with document management systems that only accept TIFF images.
 * 5. When creating thumbnails or previews of PSD files containing EMF text for a C# application that only handles raster image formats.
 */
