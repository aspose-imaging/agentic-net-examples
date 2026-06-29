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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Select sky region using Magic Wand with threshold 70, then invert the selection
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 50) { Threshold = 70 })
                    .Invert()
                    .Apply();

                // Save the modified image
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
 * 1. When a developer needs to automatically isolate the sky in a landscape PNG and then apply effects only to the rest of the image, they can use the Magic Wand threshold 70 to select the sky and invert the selection.
 * 2. When building a photo‑editing tool that removes clouds by selecting the sky region in a PNG and then processing the non‑sky area, the code can select the sky with a threshold of 70 and invert the mask.
 * 3. When generating thumbnails where the foreground must be highlighted and the sky dimmed, a developer can select the sky using Aspose.Imaging’s Magic Wand with a 70 threshold and invert the selection to target the foreground.
 * 4. When creating an automated batch job that adds a watermark only to the ground and objects in landscape images, the Magic Wand tool can pick the sky at threshold 70 and invert the selection before compositing.
 * 5. When implementing a C# application that replaces the sky with a different background, the developer can first select the existing sky in a PNG using a 70‑threshold Magic Wand and then invert the selection to isolate the rest of the scene for further processing.
 */