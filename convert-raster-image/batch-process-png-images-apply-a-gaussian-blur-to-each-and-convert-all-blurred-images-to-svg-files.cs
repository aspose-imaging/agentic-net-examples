// HOW-TO: Batch Apply Gaussian Blur to PNGs and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Apply Gaussian blur to the entire image
                    RasterImage rasterImage = (RasterImage)image;
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Prepare SVG rasterization options
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save the blurred image as SVG
                    image.Save(outputPath, new SvgOptions { VectorRasterizationOptions = rasterizationOptions });
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
 * 1. When you need to automatically blur a collection of PNG assets and generate scalable SVG versions for web graphics.
 * 2. When preparing product images for a responsive website that requires vector files with a soft focus effect applied uniformly.
 * 3. When converting scanned PNG diagrams into SVG while applying a Gaussian blur to hide sensitive details before distribution.
 * 4. When creating a batch workflow that processes user‑uploaded PNG icons, adds a blur for a UI hover effect, and saves them as SVG for high‑resolution displays.
 * 5. When migrating legacy PNG artwork to SVG format and want to apply a consistent blur filter to all files in a single C# script.
 */
