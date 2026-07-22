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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output_mask.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // First magic wand selection at pixel (120, 100)
                ImageBitMask mask1 = MagicWandTool.Select(image, new MagicWandSettings(120, 100));

                // Second magic wand selection at pixel (300, 200)
                ImageBitMask mask2 = MagicWandTool.Select(image, new MagicWandSettings(300, 200));

                // Union of the two masks
                ImageBitMask combinedMask = mask1.Union(mask2);

                // Apply the combined mask to the image
                combinedMask.Apply();

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the resulting image (mask applied) as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to isolate and merge two separate background regions in a PNG photograph for further editing, they can use the Magic Wand union to create a combined mask.
 * 2. When generating a composite mask for a medical imaging scan where two distinct tissue areas must be highlighted together, the code merges the selections and saves the result as a PNG mask.
 * 3. When preparing assets for a game, a programmer may want to combine two non‑contiguous sprite outlines into a single mask file to simplify collision detection.
 * 4. When automating the removal of multiple logo watermarks from a scanned document, the union of two Magic Wand selections creates one mask that can be applied and exported as a PNG.
 * 5. When building a batch‑processing tool that extracts and saves combined foreground objects from product photos, the union operation merges the selections and outputs a clean PNG mask for downstream workflows.
 */