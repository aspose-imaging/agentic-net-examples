// HOW-TO: How To Disable Anti-Aliasing When Converting SVG To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options without anti‑aliasing
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                // Set up PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When generating thumbnails from SVG icons for a web dashboard and need fast rendering without smoothing artifacts.
 * 2. When batch-processing a large collection of vector graphics to PNG for a mobile app where CPU usage must be minimized.
 * 3. When creating printable PNG assets from SVG logos and want to preserve sharp edges by turning off anti-aliasing.
 * 4. When integrating Aspose.Imaging into a CI pipeline that converts SVG diagrams to PNG and requires the conversion to complete quickly.
 * 5. When developing a server-side image service that serves PNG versions of user-uploaded SVG files and must reduce processing time by disabling smoothing.
 */
