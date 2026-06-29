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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create an initial mask (select pixel at 0,0), subtract an unwanted rectangle,
                // feather the mask edges, and apply the mask to the image
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .Subtract(new RectangleMask(50, 50, 100, 100)) // unwanted area
                    .GetFeathered(new FeatheringSettings { Size = 3 })
                    .Apply();

                // Save the result as GIF
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
 * 1. When a developer needs to remove a logo or watermark from a PNG image and smooth the transition before exporting it as an animated or static GIF.
 * 2. When a web application must automatically crop out a confidential region (e.g., a credit‑card number) from user‑uploaded screenshots, feather the edges to avoid harsh borders, and store the result as a GIF for fast preview.
 * 3. When a batch‑processing tool has to clean up scanned documents by subtracting unwanted rectangular artifacts, apply a feathered mask to preserve visual quality, and save the cleaned pages in GIF format for email attachments.
 * 4. When an e‑learning platform wants to generate GIF thumbnails from PNG slides, removing background elements that interfere with the thumbnail and using feathering to keep the edges smooth.
 * 5. When a game developer prepares sprite sheets by eliminating excess padding around characters, applying a feathered mask to blend the sprite edges, and exporting the final sprite as a GIF for use in UI animations.
 */