// HOW-TO: Convert SVG to PNG with Maximum Compression Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify that the input SVG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options (use the original image size)
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PNG save options with maximum compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9,               // maximum compression (0‑9)
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG image
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
 * 1. When you need to embed scalable vector graphics in a web page but must serve them as small PNG files for browsers that don’t support SVG.
 * 2. When generating thumbnail previews of user‑uploaded SVG logos and want the PNGs to be as lightweight as possible for faster loading.
 * 3. When creating PDF reports that require raster images, converting SVG diagrams to high‑compression PNGs to keep the document size low.
 * 4. When automating a batch process that converts a library of SVG icons into PNG assets for mobile apps with strict bandwidth limits.
 * 5. When optimizing SVG artwork for email newsletters, converting it to a compressed PNG to ensure compatibility with email clients that block SVG.
 */
