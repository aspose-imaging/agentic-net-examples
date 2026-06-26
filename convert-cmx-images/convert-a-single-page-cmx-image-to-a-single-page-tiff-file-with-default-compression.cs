using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\input.cmx";
            string outputPath = "C:\\output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image and save as TIFF with default compression
            using (Image image = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a developer needs to archive legacy CorelDRAW CMX drawings as single‑page TIFF files for compatibility with document management systems.
 * 2. When an application must convert a CMX illustration received from a client into a TIFF image to embed in a PDF report generated in C#.
 * 3. When a batch‑processing service processes incoming CMX files and saves them as TIFFs with default compression for efficient storage on a server.
 * 4. When a Windows desktop tool provides users the ability to export a single‑page CMX design to a TIFF format for printing on high‑resolution printers.
 * 5. When a migration script moves graphic assets from an old CMX‑based workflow to a modern TIFF‑based pipeline while preserving image quality using Aspose.Imaging for .NET.
 */