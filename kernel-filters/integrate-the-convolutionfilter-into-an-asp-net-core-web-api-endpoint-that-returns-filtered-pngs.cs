using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
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

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                raster.Filter(raster.Bounds, filterOptions);

                PngOptions pngOptions = new PngOptions
                {
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
                    Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false)
                };

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
 * 1. When a developer needs an ASP.NET Core Web API method that accepts a PNG file, applies the Aspose.Imaging ConvolutionFilter (e.g., Emboss3x3) to enhance edge details, and streams the filtered PNG back to the caller.
 * 2. When a developer wants to generate on‑the‑fly thumbnail previews of uploaded PNGs with a custom emboss effect using C# and Aspose.Imaging before storing them in a cloud bucket.
 * 3. When a developer must provide a REST endpoint that converts user‑submitted PNGs into an adaptive‑filtered PNG with a convolution filter for artistic rendering in a web‑based photo editor.
 * 4. When a developer is building a microservice that processes batch PNG images, applying the Emboss3x3 convolution filter to each raster image and saving the results with Aspose.Imaging’s PngOptions for lossless compression.
 * 5. When a developer needs to integrate server‑side image sharpening for PNG assets in an e‑commerce platform by applying a convolution filter via an ASP.NET Core API and returning the enhanced image to improve product visual quality.
 */