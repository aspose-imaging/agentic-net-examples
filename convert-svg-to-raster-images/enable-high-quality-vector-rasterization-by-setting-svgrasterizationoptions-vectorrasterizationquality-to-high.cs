using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.svg";
            string outputPath = "Output\\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Set PNG save options with the rasterization settings
                using (var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                })
                {
                    // Save the rasterized image
                    image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to convert user‑uploaded SVG logos into high‑resolution PNG thumbnails for product pages, a developer can use this code with high VectorRasterizationQuality to preserve crisp edges.
 * 2. When generating printable marketing materials from scalable vector graphics, a C# service can rasterize the SVG to a PNG at print‑ready DPI while ensuring smooth curves by setting VectorRasterizationQuality to high.
 * 3. When an e‑learning platform creates course slides that embed SVG diagrams, the platform can pre‑render them as PNG images with a white background to guarantee consistent rendering across browsers, using Aspose.Imaging’s high‑quality vector rasterization.
 * 4. When a desktop application needs to cache SVG icons as PNG files for faster loading in low‑performance environments, the developer can rasterize the icons with high quality to avoid visual artifacts.
 * 5. When an automated CI pipeline validates design assets by converting SVG mockups to PNG for visual regression testing, the code can be used with high VectorRasterizationQuality to ensure the rasterized images match the original vector intent.
 */