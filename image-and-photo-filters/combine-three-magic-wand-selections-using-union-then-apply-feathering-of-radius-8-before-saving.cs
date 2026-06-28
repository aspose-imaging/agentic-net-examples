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
        string outputPath = "output\\result.png";

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

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create first magic wand selection and union with two more selections
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))               // first point
                    .Union(new MagicWandSettings(200, 150))                      // second point
                    .Union(new MagicWandSettings(300, 250))                      // third point
                    .GetFeathered(new FeatheringSettings() { Size = 8 })        // feather radius 8
                    .Apply();                                                    // apply mask to image

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
 * 1. When a developer wants to merge three separate areas of a PNG photo—such as a logo, a watermark, and a signature—into a single smooth mask, they can use the Magic Wand union with an 8‑pixel feather before saving the edited image.
 * 2. When preparing assets for an e‑commerce site and needs to softly blend the edges of three product features selected from a high‑resolution raster image, the C# code can combine the selections, apply a feather radius of 8, and export the result as a PNG.
 * 3. When building an automated batch process that removes background noise around three distinct objects in scanned documents, the Magic Wand tool can union the selections, feather them by 8 pixels, and save the cleaned image using Aspose.Imaging for .NET.
 * 4. When creating a composite map where three geographic regions must be highlighted with a gentle edge transition, a developer can use the union of three Magic Wand selections, feather them with size 8, and store the final map as a PNG file.
 * 5. When developing a desktop application that lets users select multiple parts of an illustration and apply a soft edge effect, the code demonstrates how to union the three selections, feather the mask with radius 8, and persist the modified raster image.
 */