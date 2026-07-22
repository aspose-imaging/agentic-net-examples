using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // First magic wand selection at (100, 100)
                // Second selection at (200, 200) and union with first
                // Third selection at (300, 300) and union with previous result
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Union(new MagicWandSettings(300, 300))
                    // Feather the combined mask with radius 8
                    .GetFeathered(new FeatheringSettings() { Size = 8 })
                    // Apply the mask to the image
                    .Apply();

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a developer needs to isolate and smoothly blend three separate regions of a PNG photograph—such as a foreground object, a background element, and a watermark—by combining Magic Wand selections with a union operation and applying an 8‑pixel feathered mask before saving.
 * 2. When building an automated photo‑editing tool that removes or replaces multiple color‑based areas (e.g., sky, water, and foliage) in a raster image using Aspose.Imaging’s Magic Wand, then softens the edges with a radius‑8 feather to avoid harsh transitions.
 * 3. When creating a batch‑processing script that extracts three distinct parts of a scanned document (like header, signature, and stamp) from a PNG file, merges the selections into a single mask, feathers the edges, and saves the result for further OCR analysis.
 * 4. When developing a C# application that needs to apply a subtle vignette effect around three user‑defined points on an image by uniting the Magic Wand selections, feathering them with size 8, and exporting the edited PNG.
 * 5. When implementing a graphics workflow that programmatically selects three overlapping regions of a product image, combines them into one smooth selection using union, adds an 8‑pixel feather to create a natural blend, and writes the final image to disk.
 */