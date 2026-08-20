// HOW-TO: Combine Two Magic Wand Selections Into a PNG Mask in C# (Aspose.Imaging for .NET)
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
        string outputPath = "combined_mask.png";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create first magic wand selection
                var firstSelection = new MagicWandSettings(120, 80); // example coordinates

                // Create second magic wand selection
                var secondSelection = new MagicWandSettings(300, 200); // example coordinates

                // Combine the two selections using union
                ImageBitMask combinedMask = MagicWandTool
                    .Select(image, firstSelection)
                    .Union(secondSelection);

                // Apply the combined mask to the image (makes masked areas transparent)
                combinedMask.ApplyTo(image);

                // Save the resulting mask image as PNG
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
 * 1. When you need to isolate and export multiple non‑contiguous regions of a PNG photo for further editing or analysis.
 * 2. When creating a transparent overlay that combines two separate object selections for use in UI graphics or game assets.
 * 3. When automating batch processing to generate combined masks from scanned documents that contain several distinct elements.
 * 4. When preparing a composite mask for machine‑learning training data by merging two manually selected areas in an image.
 * 5. When simplifying a workflow that requires applying a union of two magic‑wand selections before saving the result as a PNG file.
 */
