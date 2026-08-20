// HOW-TO: Combine Multiple Magic Wand Selections With Feathering In C# (Aspose.Imaging for .NET)
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
                // Create first magic wand selection and union with two more selections
                var mask = MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 150))
                    .Union(new MagicWandSettings(300, 250))
                    // Feather the combined mask with radius 8
                    .GetFeathered(new FeatheringSettings() { Size = 8 });

                // Apply the feathered mask to the image
                mask.Apply();

                // Save the resulting image
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
 * 1. When you need to automatically select and merge several non‑contiguous regions in a PNG image and smooth their edges before saving.
 * 2. When creating a soft‑edge composite mask for a photo‑editing workflow in a C# application using Aspose.Imaging.
 * 3. When generating a feathered outline around multiple objects for a graphic design export without manual Photoshop work.
 * 4. When programmatically preparing a raster image for print by unifying selections and applying an 8‑pixel feather to avoid harsh borders.
 * 5. When building an automated image‑processing pipeline that combines magic‑wand selections and applies consistent feathering for UI thumbnails.
 */
