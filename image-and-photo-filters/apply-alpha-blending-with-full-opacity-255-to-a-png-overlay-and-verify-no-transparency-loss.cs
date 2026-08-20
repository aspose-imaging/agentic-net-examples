// HOW-TO: Blend PNG Overlay Onto Background With Full Opacity In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string backgroundPath = "background.png";
            string overlayPath = "overlay.png";
            string outputPath = "output.png";

            // Verify input files exist
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background and overlay images as RasterImage
            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Blend overlay onto background at (0,0) with full opacity (255)
                background.Blend(new Point(0, 0), overlay, 255);

                // Prepare PNG save options with bound output source
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the blended image preserving alpha channel
                background.Save(outputPath, pngOptions);
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
 * 1. When you need to place a fully opaque PNG logo on top of a background image for branding without losing the original alpha channel.
 * 2. When generating composite images for a web application, such as combining a transparent button graphic with a background panel while keeping the final PNG fully opaque.
 * 3. When preparing game assets where a sprite overlay must be merged onto a base texture at full opacity to ensure consistent rendering across devices.
 * 4. When creating printable marketing materials that require a PNG overlay (e.g., a badge or seal) to be blended onto a background without any transparency artifacts.
 * 5. When automating batch processing of UI mockups, merging design overlays onto base screens while preserving the PNG format and alpha information.
 */
