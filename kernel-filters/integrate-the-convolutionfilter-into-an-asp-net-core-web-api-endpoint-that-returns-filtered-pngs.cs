// HOW-TO: Apply Emboss Convolution Filter to PNG in ASP.NET Core Web API (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply an emboss convolution filter
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Save the filtered image as PNG
                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to add a 3‑D embossed effect to user‑uploaded PNG images before returning them from an ASP.NET Core Web API endpoint.
 * 2. When an e‑commerce platform wants to dynamically apply an emboss filter to product PNGs for enhanced visual appeal via a RESTful service.
 * 3. When a document‑management system generates preview thumbnails with an emboss convolution filter to differentiate file types in a web gallery.
 * 4. When a mobile app backend must provide on‑the‑fly image processing that returns filtered PNGs for augmented‑reality overlays.
 * 5. When a reporting dashboard requires server‑side generation of embossed PNG charts delivered through a C# Web API.
 */
