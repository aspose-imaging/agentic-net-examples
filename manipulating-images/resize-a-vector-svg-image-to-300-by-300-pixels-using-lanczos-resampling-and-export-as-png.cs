using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 300x300 using Lanczos resampling
                image.Resize(300, 300, ResizeType.LanczosResample);

                // Prepare PNG save options with rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(300, 300) // Set target page size
                    }
                };

                // Save the rasterized PNG
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
 * 1. When a developer needs to generate a 300 × 300 pixel PNG thumbnail from an SVG icon for responsive web design, this code resizes the vector with Lanczos resampling and rasterizes it.
 * 2. When a mobile app must display a high‑quality preview of an SVG illustration at a fixed size, the snippet converts the SVG to a 300 × 300 PNG using C# image processing.
 * 3. When an e‑commerce platform requires product SVG graphics to be stored as PNG assets of a specific dimension for email newsletters, the code performs the resize and export automatically.
 * 4. When a reporting tool has to embed vector diagrams as raster images in PDF reports at 300 × 300 pixels, this example shows how to rasterize the SVG with Lanczos resampling in .NET.
 * 5. When a CI/CD pipeline needs to validate SVG assets by creating standardized 300 × 300 PNG snapshots for visual regression testing, the code provides a repeatable conversion method.
 */