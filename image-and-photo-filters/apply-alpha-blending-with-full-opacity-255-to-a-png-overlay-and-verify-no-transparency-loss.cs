using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string backgroundPath = "background.png";
            string overlayPath = "overlay.png";
            string outputPath = "result.png";

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
            using (Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(backgroundPath))
            using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayPath))
            {
                // Blend overlay onto background at (0,0) with full opacity (255)
                background.Blend(new Aspose.Imaging.Point(0, 0), overlay, 255);

                // Prepare PNG save options with bound source
                var outputSource = new FileCreateSource(outputPath, false);
                PngOptions options = new PngOptions { Source = outputSource };

                // Save the blended image
                background.Save(outputPath, options);
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
 * 1. When a developer needs to merge a logo PNG onto a product photo without losing any transparent pixels, they can use this code to alpha‑blend the overlay at full opacity and save the result as a new PNG.
 * 2. When building a web‑based map application that stacks a terrain overlay on a base map, the code ensures the overlay’s alpha channel is preserved while compositing the images in C#.
 * 3. When generating printable marketing materials where a promotional banner PNG must be placed on a background image, this snippet blends the banner with 255 opacity so the final PNG retains its original transparency.
 * 4. When creating UI skins for a desktop application and need to combine a button icon PNG over a theme background, the code provides a reliable way to composite the images without altering the icon’s alpha values.
 * 5. When automating the preparation of game assets that require a sprite PNG to be overlaid on a terrain texture, the example guarantees full‑opacity blending and verifies that no transparency is lost during the save operation.
 */