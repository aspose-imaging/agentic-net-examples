// HOW-TO: Convert SVG to High Resolution PNG with 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                VectorImage vector = image as VectorImage;
                if (vector == null)
                {
                    Console.Error.WriteLine("Input image is not a vector image.");
                    return;
                }

                PngOptions pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                vector.Save(outputPath, pngOptions);
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
 * 1. When you need to render scalable SVG icons as crisp 300 DPI PNG files for print‑ready brochures using Aspose.Imaging in a .NET application.
 * 2. When a web service must generate high‑resolution PNG thumbnails from user‑uploaded SVG logos for e‑commerce product listings.
 * 3. When an automated build pipeline converts vector diagrams into raster PNG assets with exact DPI settings for inclusion in PDF reports.
 * 4. When a desktop utility transforms SVG floor plans into detailed PNG images for GIS systems that require a specific resolution.
 * 5. When a C# microservice prepares SVG artwork for high‑quality merchandise printing by exporting it as a 300 DPI PNG file.
 */
