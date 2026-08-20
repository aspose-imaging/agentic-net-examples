// HOW-TO: Convert PNG to SVG With Background Color In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\source.png";
            string outputPath = "C:\\Images\\result.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image pngImage = Image.Load(inputPath))
            {
                // Create an SVG image with the same dimensions as the PNG
                using (SvgImage svgImage = new SvgImage(pngImage.Width, pngImage.Height))
                {
                    // Set background color (example: LightBlue)
                    svgImage.BackgroundColor = Aspose.Imaging.Color.LightBlue;
                    svgImage.HasBackgroundColor = true;

                    // Save the SVG image
                    svgImage.Save(outputPath, new SvgOptions());
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
 * 1. When you need to embed a PNG graphic into a web page as scalable SVG with a solid background color for consistent rendering across browsers.
 * 2. When generating vector assets from raster logos for print or marketing materials while preserving a specific background hue using C#.
 * 3. When automating batch conversion of product images to SVG format for responsive design, ensuring each SVG has a predefined background shade.
 * 4. When creating SVG placeholders from PNG thumbnails in a .NET application, setting a background color to match the app’s theme.
 * 5. When integrating Aspose.Imaging into a C# service that transforms user‑uploaded PNG files into SVG files with a custom background for further editing in vector editors.
 */
