// HOW-TO: Resize EPS Image to Double Size and Save as High‑Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                int newWidth = epsImage.Width * 2;
                int newHeight = epsImage.Height * 2;

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = newWidth,
                    PageHeight = newHeight
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Source = new FileCreateSource(outputPath, false)
                };

                epsImage.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a vector EPS logo to a larger, high‑resolution PNG for use on a high‑DPI website or digital signage.
 * 2. When a printing workflow requires scaling an EPS illustration to double its original dimensions before exporting to PNG for raster‑based printers.
 * 3. When an application must generate a zoomed‑in preview of an EPS diagram by rasterizing it at twice the size and saving it as PNG for quick display.
 * 4. When you need to create a high‑quality PNG thumbnail from an EPS file while preserving detail by increasing the rasterization resolution in C#.
 * 5. When a batch process must upscale multiple EPS assets and export them as PNG files for inclusion in a mobile app that only supports raster images.
 */
