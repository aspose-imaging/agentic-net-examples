// HOW-TO: Combine Multiple Magic Wand Selections into One Mask for TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputImagePath = "input.tif";
            string outputImagePath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputImagePath))
            {
                // Create first mask using magic wand at point (100, 100)
                ImageMask mask1 = MagicWandTool.Select(image, new MagicWandSettings(100, 100));

                // Create second mask using magic wand at point (200, 200)
                ImageMask mask2 = MagicWandTool.Select(image, new MagicWandSettings(200, 200));

                // Combine masks using Union
                ImageMask combinedMask = mask1.Union(mask2);

                // Apply the combined mask to the image
                combinedMask.ApplyTo(image);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath));

                // Save the modified image
                image.Save(outputImagePath);
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
 * 1. When you need to remove or edit two separate regions of a large TIFF scan by selecting them with a magic wand and applying a single combined mask.
 * 2. When automating preprocessing of scanned documents to hide watermarks located at different coordinates before archiving them as TIFF files.
 * 3. When creating a composite mask to protect sensitive information in multiple areas of a medical image before sharing it with collaborators.
 * 4. When developing a batch tool that isolates and modifies distinct background sections of a high‑resolution TIFF map using C# and Aspose.Imaging.
 * 5. When implementing a workflow that selects two color‑based objects in a TIFF photograph, merges the selections, and applies the mask to adjust their transparency.
 */
