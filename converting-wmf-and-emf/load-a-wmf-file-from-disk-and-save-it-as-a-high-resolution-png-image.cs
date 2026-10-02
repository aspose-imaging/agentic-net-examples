// HOW-TO: Convert WMF to High Resolution PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.wmf";
        string outputPath = "Output\\sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageWidth = image.Width * 2,
                    PageHeight = image.Height * 2,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to display legacy WMF vector graphics on modern web pages that only support raster PNG images.
 * 2. When generating printable marketing materials that require WMF logos to be converted to high‑resolution PNGs for accurate scaling.
 * 3. When automating a batch process that extracts WMF icons from a legacy application and saves them as PNG thumbnails with doubled pixel density.
 * 4. When integrating a document conversion service that must preserve the visual fidelity of WMF drawings by rasterizing them at higher resolution before storing as PNG.
 * 5. When creating a C# utility to convert user‑uploaded WMF files into PNGs for preview in a mobile app that cannot render WMF directly.
 */
