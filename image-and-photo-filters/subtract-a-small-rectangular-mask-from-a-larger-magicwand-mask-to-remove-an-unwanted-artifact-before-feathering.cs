// HOW-TO: Subtract a Rectangle from Magic Wand Mask and Feather in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create an initial mask using Magic Wand at a sample point (e.g., 100,100)
                var mask = MagicWandTool.Select(image, new MagicWandSettings(100, 100));

                // Subtract a small rectangular mask from the larger mask
                // Rectangle defined by left=50, top=50, width=30, height=30
                mask = mask.Subtract(new RectangleMask(50, 50, 30, 30));

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
 * 1. When you need to remove a small unwanted object from a selection created with the Magic Wand tool in a PNG before applying a smooth feathered edge.
 * 2. When preparing product photos where a logo or watermark must be excluded from a larger automatically selected region.
 * 3. When cleaning scanned documents by subtracting a rectangular blemish from a Magic Wand mask and then feathering to keep the surrounding area seamless.
 * 4. When building a C# image‑processing pipeline that isolates a foreground area but must cut out a known rectangular overlay before compositing.
 * 5. When creating custom cut‑outs for UI assets and you must eliminate a rectangular artifact from the auto‑selected mask and apply feathering for a soft transition.
 */
