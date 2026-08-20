// HOW-TO: How To Convert SVG To PNG With Error Handling In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG with load options
            using (Image image = Image.Load(inputPath, new Aspose.Imaging.ImageLoadOptions.SvgLoadOptions()))
            {
                // Configure rasterization for SVG to PNG conversion
                var rasterOptions = new SvgRasterizationOptions { PageSize = image.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                // Save as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Log any exception details
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically convert user‑uploaded SVG graphics to PNG thumbnails while ensuring missing files are reported.
 * 2. When an automated batch job must generate PNG assets from SVG designs and create output folders on the fly.
 * 3. When a web service has to rasterize vector logos into PNG format and log any loading or conversion failures for troubleshooting.
 * 4. When a desktop application processes SVG icons and saves them as PNGs, handling exceptions to avoid crashes.
 * 5. When you want to validate the existence of an SVG file before conversion and capture detailed error messages for debugging.
 */
