// HOW-TO: Convert SVG to PNG with Proper Disposal in C# (Aspose.Imaging for .NET)
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
            try
            {
                string inputPath = "input.svg";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        svgImage.Save(outputPath, pngOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert user‑uploaded SVG graphics to PNG thumbnails in a .NET web application while ensuring memory is released promptly.
 * 2. When an automated build pipeline must generate PNG assets from SVG design files using Aspose.Imaging without leaking resources.
 * 3. When a desktop utility processes a folder of SVG icons and saves them as PNGs for use in Windows applications, requiring deterministic disposal of image objects.
 * 4. When a cloud function transforms SVG diagrams into PNG images for PDF reports and must clean up objects to stay within execution time limits.
 * 5. When a legacy system migrates vector assets to raster format and wants to use C# using blocks to guarantee proper cleanup of Aspose.Imaging objects.
 */
