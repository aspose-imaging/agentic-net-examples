using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Process exactly 50 JPEG files
            for (int i = 1; i <= 50; i++)
            {
                string inputPath = Path.Combine(inputDir, $"image{i}.jpg");
                string outputPath = Path.Combine(outputDir, $"image{i}_masked.png");

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
                    // Create a mask using MagicWandTool at point (0,0) with default settings
                    MagicWandTool
                        .Select(image, new MagicWandSettings(0, 0))
                        .Apply();

                    // Save the masked image as PNG with alpha channel
                    image.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
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
 * 1. When a developer needs to automatically remove backgrounds from a batch of 50 JPEG photos and save the results as PNGs with transparency using Aspose.Imaging's MagicWandTool in C#.
 * 2. When an e‑commerce platform wants to generate product thumbnail masks for 50 uploaded JPEG images to improve visual consistency on the website.
 * 3. When a digital archivist must apply a quick mask to a set of scanned JPEG documents before converting them to PNG with an alpha channel for further compositing.
 * 4. When a marketing automation script has to process exactly 50 campaign images, isolate the foreground using MagicWand settings, and store the masked PNG files in a designated output folder.
 * 5. When a photo‑editing application needs to batch‑process 50 user‑selected JPEG files to create transparent PNG overlays for use in mobile app UI design.
 */