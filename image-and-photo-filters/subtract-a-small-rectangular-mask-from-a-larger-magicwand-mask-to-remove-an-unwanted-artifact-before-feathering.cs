using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using Magic Wand at a specific point
                var mask = MagicWandTool.Select(image, new MagicWandSettings(845, 128));

                // Subtract a small rectangular mask from the larger mask
                mask = mask.Subtract(new RectangleMask(100, 100, 50, 30));

                // Feather the resulting mask
                var featheredMask = mask.GetFeathered(new FeatheringSettings() { Size = 3 });

                // Apply the feathered mask to the image
                featheredMask.Apply();

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
 * 1. When cleaning up a scanned PNG document that contains a stray ink blot inside a selected area, a developer can use MagicWandTool to select the main region, subtract a small RectangleMask covering the blot, and feather the mask before saving the image.
 * 2. When preparing product photos for an e‑commerce site and a price tag or label intrudes on the background, a developer can subtract a rectangular mask from the Magic Wand selection to eliminate the tag and then feather the mask to blend the edit seamlessly.
 * 3. When removing a watermark that overlaps a larger object in a PNG image, a developer can use MagicWandTool to select the object, subtract a RectangleMask that isolates the watermark, and feather the result to avoid harsh edges.
 * 4. When processing satellite imagery where a sensor glitch creates a rectangular artifact inside a cloud region, a developer can subtract that rectangle from the Magic Wand mask and feather the mask to produce a smooth transition.
 * 5. When creating a composite graphic and a small placeholder rectangle remains inside a selected foreground, a developer can subtract the rectangle from the Magic Wand mask, feather the mask, and apply it to the raster image before exporting the final PNG.
 */