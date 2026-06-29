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
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization without setting a background color (transparent)
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();

                // Set PNG save options with the rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG
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
 * 1. When a web developer needs to generate PNG icons from SVG assets for a responsive UI while preserving transparency for overlay on different background colors.
 * 2. When an e‑commerce platform automatically creates product thumbnails from vector logos, converting SVG to PNG with no background so the images blend seamlessly on varied storefront themes.
 * 3. When a reporting tool embeds vector diagrams into PDF reports and must rasterize them to PNG with a transparent background to maintain layout consistency across devices.
 * 4. When a mobile app processes user‑uploaded SVG illustrations and converts them to PNG assets for faster rendering, ensuring the background remains undefined for compositing with app UI elements.
 * 5. When a CI/CD pipeline automates asset optimization by converting design‑team SVG files to PNG format without a background color, enabling seamless integration into email templates and social media posts.
 */