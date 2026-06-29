using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Apply an emboss convolution filter using the predefined kernel.
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Save the filtered image as PNG.
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer wants to expose an ASP.NET Core Web API endpoint that receives a PNG file, applies an emboss convolution filter using Aspose.Imaging, and returns the filtered PNG to the client.
 * 2. When a mobile app needs a server‑side service to apply a 3×3 convolution filter to uploaded PNG images for real‑time edge enhancement before sending the result back.
 * 3. When an e‑commerce platform requires an API that automatically adds an emboss effect to merchant‑uploaded product PNGs, delivering the processed image for storefront display.
 * 4. When a content‑management system must provide a RESTful endpoint that converts raw PNG uploads into visually enhanced versions with a predefined convolution kernel for preview thumbnails.
 * 5. When a medical imaging web service needs to run a convolution filter on diagnostic PNG scans to highlight tissue boundaries before returning the processed image to a client application.
 */