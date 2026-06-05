using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to a memory stream as PNG
                using (var rasterStream = new MemoryStream())
                {
                    var rasterizationOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions();
                    var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized PNG for filtering
                    using (Image rasterImage = Image.Load(rasterStream))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply the 3x3 sharpen convolution filter
                        raster.Filter(raster.Bounds,
                            new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));

                        // Save the sharpened image as PNG
                        raster.Save(outputPath);
                    }
                }
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
 * 1. When generating product thumbnails from vector logos, a developer can load the SVG, apply a Sharpen3x3 filter, and save a crisp PNG for e‑commerce listings.
 * 2. When converting SVG diagrams to high‑resolution PNGs for PDF reports, applying the 3x3 sharpen convolution enhances edge definition before saving.
 * 3. When preparing UI icons from SVG assets for mobile apps, a developer can rasterize the SVG, sharpen it, and output a clear PNG to improve visual clarity on small screens.
 * 4. When automating a batch job that processes SVG maps, rasterizing each map to PNG and applying the Sharpen3x3 filter makes street lines and landmarks more distinct.
 * 5. When building a C# web service that receives SVG templates, applying the Sharpen3x3 filter and returning a sharpened PNG provides users with a real‑time, high‑quality preview.
 */