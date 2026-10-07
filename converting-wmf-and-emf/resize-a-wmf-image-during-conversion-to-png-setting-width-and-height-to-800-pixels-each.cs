// HOW-TO: Resize WMF to 800x800 PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 800
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
 * 1. When you need to convert legacy WMF vector graphics to PNG thumbnails of a fixed 800‑pixel size for web previews.
 * 2. When generating consistent‑sized product images from WMF files for an e‑commerce catalog in a C# application.
 * 3. When preparing WMF diagrams for inclusion in PDF reports that require raster images of exact dimensions.
 * 4. When automating batch processing of WMF icons to create uniformly sized PNG assets for a mobile app.
 * 5. When integrating Aspose.Imaging into a .NET service that resizes and rasterizes WMF files to meet a UI design specification of 800 × 800 pixels.
 */
