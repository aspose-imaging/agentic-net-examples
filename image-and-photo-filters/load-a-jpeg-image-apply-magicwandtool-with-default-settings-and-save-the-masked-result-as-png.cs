using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply MagicWandTool with default settings (reference point at (0,0))
                MagicWandTool
                    .Select(image, new MagicWandSettings(0, 0))
                    .Apply();

                // Save the masked result as PNG with alpha channel
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
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
 * 1. When a developer needs to isolate the foreground of a JPEG photo using Aspose.Imaging’s MagicWandTool and export it as a transparent PNG for web thumbnails.
 * 2. When an e‑commerce platform automatically removes the background of product JPEG images with the default MagicWand settings and saves the result as a PNG with an alpha channel for overlay on different backgrounds.
 * 3. When a mobile app processes user‑uploaded JPEG pictures, applies a MagicWand selection to create a mask, and stores the masked image as a PNG for later compositing in C#.
 * 4. When a content management system batch‑converts legacy JPEG assets to PNG with transparent backgrounds by loading each JPEG, applying the default MagicWand reference point, and saving with TruecolorWithAlpha options.
 * 5. When a digital‑marketing tool generates cut‑out objects from JPEG banners using the MagicWandTool and saves them as PNG files with alpha transparency for reuse in email templates or social media posts.
 */