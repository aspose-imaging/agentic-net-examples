// HOW-TO: Refine Image Mask by Subtracting Area and Feathering Edges in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create an initial mask using MagicWandTool at a sample coordinate
                // Subtract an unwanted rectangular area from the mask
                // Feather the mask edges with a size of 3
                var refinedMask = MagicWandTool.Select(image, new MagicWandSettings(845, 128))
                    .Subtract(new RectangleMask(0, 0, 800, 150))
                    .GetFeathered(new FeatheringSettings { Size = 3 });

                // Apply the refined mask to the image
                refinedMask.Apply();

                // Save the result as a GIF
                image.Save(outputPath, new GifOptions());
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
 * 1. When you need to remove an unwanted portion of a PNG and smooth the transition before exporting it as a GIF.
 * 2. When creating web‑ready graphics that require a clean cut‑out with softened edges to avoid harsh borders.
 * 3. When preprocessing scanned documents to eliminate background blocks and apply feathered masking for better visual quality.
 * 4. When generating thumbnails where a specific region must be excluded and the remaining area needs a subtle edge blend.
 * 5. When automating batch image processing to apply custom masks and save the results in GIF format for compatibility with legacy systems.
 */
