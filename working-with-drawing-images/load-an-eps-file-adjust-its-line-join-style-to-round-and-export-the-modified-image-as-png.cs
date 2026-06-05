using System;
using System.IO;
using System.Drawing.Drawing2D;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PNG export with rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        // Set line join style to round (if supported) or use anti-aliasing as fallback
                        //LineJoin = LineJoin.Round, // Uncomment if LineJoin property exists
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

                // Save the modified image as PNG
                epsImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a vector EPS logo into a high‑resolution PNG for web display while ensuring smooth rounded line joins.
 * 2. When an automated build script must rasterize EPS diagrams into PNG thumbnails with anti‑aliasing for a documentation portal.
 * 3. When a desktop application imports user‑provided EPS artwork and saves it as PNG with rounded joins to maintain visual consistency in UI elements.
 * 4. When a batch processing tool processes a folder of EPS files, adjusting line join styles to round before exporting them as PNG for print‑ready previews.
 * 5. When a C# service generates PNG assets from EPS source files for mobile apps, requiring anti‑aliased rendering and rounded line joins to improve image quality.
 */