// HOW-TO: How To Blur, Resize CorelDRAW CDR And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Load the CDR file with CDR load options
            using (Image image = Image.Load(inputPath, new CdrLoadOptions()))
            {
                // Cast to RasterImage to apply raster operations
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Resize to 1200x800 using default resampling
                raster.Resize(1200, 800);

                // Save as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a thumbnail of a CorelDRAW design with a soft focus effect for a web gallery.
 * 2. When converting high‑resolution CDR artwork to a smaller PNG for faster page load while applying a Gaussian blur to hide details.
 * 3. When preparing print‑ready images from CDR files by resizing them to a standard 1200×800 size and exporting to PNG for digital proofing.
 * 4. When automating a batch process that adds a blur filter to CDR logos before embedding them in a presentation as PNG assets.
 * 5. When integrating CorelDRAW assets into a C# application that requires blurred, resized PNGs for UI backgrounds or placeholders.
 */
