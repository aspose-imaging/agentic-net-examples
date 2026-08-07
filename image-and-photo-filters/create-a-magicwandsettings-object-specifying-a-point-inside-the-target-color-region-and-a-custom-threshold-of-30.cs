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

            // Load the image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create MagicWandSettings with a point (50,50) and custom threshold 30
                MagicWandSettings settings = new MagicWandSettings(50, 50) { Threshold = 30 };

                // Apply the magic wand mask to the image
                MagicWandTool.Select(image, settings).Apply();

                // Save the resulting image as PNG with alpha channel
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
 * 1. When a developer needs to automatically remove a solid‑color background from a product photo by selecting a seed point inside the background and using a custom threshold of 30 to generate a transparent PNG with an alpha channel.
 * 2. When building a C# image‑editing tool that lets users click on a logo in a screenshot and creates a mask with MagicWandSettings so the logo can be isolated and saved as a PNG with transparency for reuse.
 * 3. When preparing assets for a web game, a developer can use the magic wand to select a region of similar terrain colors, apply a threshold of 30, and export the result as a TruecolorWithAlpha PNG for seamless layering.
 * 4. When implementing an automated batch process that extracts handwritten signatures from scanned documents by picking a point inside the ink region, applying a 30‑threshold mask, and saving the cut‑out as a transparent PNG.
 * 5. When creating a C# utility that converts scanned maps into selectable regions, the code can pick a point inside a colored area, use a 30 threshold to generate a mask, and output a PNG with an alpha channel for GIS integration.
 */