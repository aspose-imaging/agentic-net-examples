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
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask with Magic Wand, subtract a small rectangle mask, feather, and apply
                MagicWandTool
                    .Select(image, new MagicWandSettings(845, 128))          // initial selection
                    .Subtract(new RectangleMask(100, 100, 50, 30))          // remove unwanted artifact
                    .GetFeathered(new FeatheringSettings { Size = 3 })    // feather the edges
                    .Apply();                                              // apply mask to the image

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
 * 1. When cleaning up a scanned PNG document that contains a stray ink blot inside a larger background selection, a developer can use MagicWand to select the area, subtract a RectangleMask for the blot, feather the edges, and save the corrected image.
 * 2. When preparing product photos for an e‑commerce site and need to remove a small logo that intrudes into a broader background selection, the code lets a C# developer subtract a rectangular mask from the MagicWand selection, feather the border, and export the result as a PNG.
 * 3. When automating removal of a watermark that overlaps a selected region in a batch of images, a developer can apply the MagicWandTool, subtract a RectangleMask covering the watermark, feather the transition, and save the cleaned image.
 * 4. When creating a composite graphic and an unwanted artifact appears inside a previously selected foreground, the code enables a developer to subtract that artifact with a rectangle mask, feather the selection for smooth blending, and write the final PNG file.
 * 5. When processing medical imaging scans where a small sensor glitch lies inside a larger tissue selection, a C# developer can use the MagicWand selection, subtract a precise rectangular mask, apply feathering to avoid harsh edges, and store the corrected image.
 */