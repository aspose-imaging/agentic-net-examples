// HOW-TO: Render SVG to BMP with White Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.bmp";

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
                // Configure rasterization options with white background
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set BMP save options and attach rasterization options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert vector SVG graphics into a BMP bitmap for legacy Windows applications that only accept BMP files, while ensuring a solid white background.
 * 2. When generating thumbnails of SVG icons for a desktop UI and the thumbnail format must be BMP with a consistent background color.
 * 3. When automating a batch process that reads SVG assets from a folder and saves them as BMP images for printing pipelines that require a non‑transparent background.
 * 4. When integrating Aspose.Imaging into a C# service that receives SVG uploads and returns BMP responses for clients that cannot handle SVG transparency.
 * 5. When preparing SVG diagrams for inclusion in a PDF report that embeds BMP images, and you must enforce a white canvas to avoid unexpected background colors.
 */
