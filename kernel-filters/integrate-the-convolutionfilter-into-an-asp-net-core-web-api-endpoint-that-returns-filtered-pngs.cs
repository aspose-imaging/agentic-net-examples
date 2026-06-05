using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply a convolution filter (Emboss3x3)
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the filtered image as PNG
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
 * 1. When a developer wants to expose an ASP.NET Core Web API endpoint that receives a PNG image, applies an emboss convolution filter using Aspose.Imaging, and returns the processed PNG to the client.
 * 2. When a mobile app needs to upload a user‑generated PNG to a .NET backend that automatically enhances the image with a 3×3 convolution filter before sending it back for display.
 * 3. When an e‑commerce platform requires a server‑side service to generate stylized product thumbnails on‑the‑fly by applying Aspose.Imaging’s Emboss3x3 filter to PNG files requested via a RESTful API.
 * 4. When a content‑management system must provide a C# Web API that converts uploaded PNGs into filtered versions for artistic effects, leveraging RasterImage.Filter and ConvolutionFilterOptions.
 * 5. When a developer needs to integrate real‑time image processing into a .NET Core microservice that returns filtered PNG streams after applying a convolution kernel without storing intermediate files.
 */