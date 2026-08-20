// HOW-TO: Apply Gaussian Blur With Sigma 2.8 To SVG And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
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

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur with size 5 and sigma 2.8
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.8));

                        // Save the filtered image as PNG
                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert an SVG logo to a blurred PNG thumbnail for a website using C#.
 * 2. When preprocessing vector icons by rasterizing them and applying a Gaussian blur before embedding them in a mobile app.
 * 3. When generating soft‑focus background images from SVG illustrations for marketing materials in an automated .NET workflow.
 * 4. When creating a dataset of blurred PNGs from SVG diagrams for machine‑learning training pipelines.
 * 5. When applying a custom sigma value to a Gaussian kernel while rasterizing SVG graphics for print‑ready PDFs in a C# application.
 */
