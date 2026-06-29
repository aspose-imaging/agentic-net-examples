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
            string inputPath = @"c:\temp\test.svg";
            string outputPath = @"c:\temp\test.output.png";

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
                // Configure rasterization options
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set custom background color (hex #FF5733)
                    BackgroundColor = Aspose.Imaging.Color.FromArgb(255, 255, 87, 51),

                    // Preserve original size
                    PageSize = svgImage.Size
                };

                // Set PNG save options with the rasterization options
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG
                svgImage.Save(outputPath, saveOptions);
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
 * 1. When a web application must convert user‑uploaded SVG logos to PNG thumbnails with a branded background color defined by a hex code.
 * 2. When an automated reporting tool needs to generate PNG charts from SVG diagrams and ensure the output matches a corporate color palette by setting a custom background.
 * 3. When a desktop utility processes a batch of SVG icons and saves them as PNG files with a specific background shade to improve visibility on dark UI themes.
 * 4. When a CI/CD pipeline creates PNG previews of SVG assets for documentation and must apply a consistent background color using Aspose.Imaging’s rasterization options.
 * 5. When a mobile app backend converts SVG illustrations to PNG for caching and wants to replace transparent areas with a custom hex‑coded background to avoid rendering artifacts.
 */