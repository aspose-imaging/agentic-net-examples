// HOW-TO: Convert EPS to High‑Resolution PNG with Resizing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Define high‑resolution rasterization options
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = 2000,   // desired width in pixels
                    PageHeight = 2000   // desired height in pixels
                };

                // Configure PNG export options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Optional explicit resize using a high‑quality resample mode
                image.Resize(2000, 2000, ResizeType.LanczosResample);

                // Save as high‑resolution PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate a print‑ready PNG from a vector EPS logo and ensure it matches a specific pixel dimension for web or UI display.
 * 2. When an application must batch‑process EPS artwork files, rasterize them at 2000 × 2000 pixels, and save the results as high‑quality PNGs for downstream image pipelines.
 * 3. When a C# service has to embed EPS diagrams into a PDF or report that only supports raster images, requiring on‑the‑fly conversion to a high‑resolution PNG.
 * 4. When a designer’s workflow requires scaling vector EPS illustrations to a fixed size while preserving detail, using Aspose.Imaging’s Lanczos resample before exporting to PNG.
 * 5. When an automated build script validates that EPS assets are correctly rasterized and saved as PNGs with consistent dimensions before publishing to a content delivery network.
 */
