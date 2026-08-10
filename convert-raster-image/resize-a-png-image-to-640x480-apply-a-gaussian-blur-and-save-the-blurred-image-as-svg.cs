// HOW-TO: Resize PNG to 640x480, Apply Gaussian Blur, Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to 640x480
                image.Resize(640, 480);

                // Apply Gaussian blur
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save as SVG
                SvgOptions svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a lightweight vector version of a blurred thumbnail from a PNG for responsive web design.
 * 2. When creating a blurred background image for a UI overlay and you want the result in SVG to scale without loss.
 * 3. When preprocessing PNG assets for an e‑book, resizing them to 640×480, applying a soft blur, and converting to SVG for better compatibility with e‑reader rendering engines.
 * 4. When automating a batch process that prepares product photos by standardizing size, adding a Gaussian blur for aesthetic effect, and saving as SVG for print‑ready vector workflows.
 * 5. When developing a C# application that must convert user‑uploaded PNGs into blurred SVG icons of a fixed dimension for use in a mobile app’s asset pipeline.
 */
