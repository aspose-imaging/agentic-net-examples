// HOW-TO: Convert Multi‑Page CMX to Multi‑Page TIFF in C# Aspose Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image cmxImage = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When a publishing system receives multi‑page CorelDRAW CMX files and must archive them as multi‑page TIFFs for long‑term storage.
 * 2. When a document workflow needs to convert CMX artwork into a TIFF format that preserves the original page sequence for printing pipelines.
 * 3. When a migration tool must batch‑process CMX design files into TIFFs to integrate with a .NET image‑processing library.
 * 4. When an automated service generates TIFF previews from CMX source files while keeping each page in the correct order for review.
 * 5. When a C# application needs to transform multi‑page CMX drawings into TIFFs to comply with a client’s file‑format standards without losing page layout.
 */
