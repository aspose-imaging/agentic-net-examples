using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
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

            // Load the image and apply Magic Wand selection with threshold 70, then invert the mask
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100) { Threshold = 70 })
                    .Invert()
                    .Apply();

                // Save the modified image as PNG with alpha channel
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When a developer needs to isolate the sky in a landscape PNG to apply a different color grade or overlay, they can use the Magic Wand threshold 70 to select the sky region and then invert the mask to protect the foreground.
 * 2. When building an automated pipeline that removes the sky from aerial PNG images before stitching them together, the code can select the sky with a 70‑threshold wand and invert the selection to keep only the ground features.
 * 3. When creating a web service that generates transparent PNG assets by making the sky fully transparent, the Magic Wand selection with threshold 70 followed by inversion lets the developer preserve non‑sky pixels while adding an alpha channel.
 * 4. When implementing a batch process that replaces the sky in a series of landscape PNG files with a custom gradient, the code selects the sky using the 70‑threshold wand and inverts the mask to apply the new background only to the selected area.
 * 5. When developing a photo‑editing plugin that lets users quickly toggle sky visibility in C# applications, the Magic Wand selection at threshold 70 and subsequent inversion provide a reliable way to isolate and hide the sky while keeping the rest of the image intact.
 */