using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

namespace SvgToPngConverter
{
    class Program
    {
        static void Main()
        {
            // Prerequisites (documented in comments):
            // 1. Aspose.Imaging for .NET library must be referenced (NuGet package Aspose.Imaging).
            // 2. A valid Aspose.Imaging license should be set if used in a non‑evaluation context.
            // 3. .NET runtime (e.g., .NET 6.0 or later) must be installed on the machine.
            // 4. The input SVG file must be accessible and the output directory must be writable.
            // 5. For SVG rasterization, the library may rely on system fonts; ensure required fonts are installed.

            // Hardcoded input and output paths (no argument validation)
            string inputPath = @"C:\Images\sample.svg";
            string outputPath = @"C:\Images\output\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image from file
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options (default values are usually sufficient)
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Optional: set background color, page size, etc.
                    // BackgroundColor = Color.White,
                    // PageSize = svgImage.Size
                };

                // Configure PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as PNG
                svgImage.Save(outputPath, pngOptions);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
    }
}