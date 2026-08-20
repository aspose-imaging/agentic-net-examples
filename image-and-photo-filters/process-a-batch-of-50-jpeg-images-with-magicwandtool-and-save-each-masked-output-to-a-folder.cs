// HOW-TO: Batch Apply Magic Wand Mask to JPEGs and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output folders
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Process 50 JPEG images
            for (int i = 1; i <= 50; i++)
            {
                string inputPath = Path.Combine(inputFolder, $"image{i}.jpg");
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, $"image{i}_masked.png");
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image, apply magic wand mask, and save
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Create a mask based on pixel (10,10) with default settings
                    MagicWandTool.Select(image, new MagicWandSettings(10, 10)).Apply();

                    // Save masked image as PNG with alpha channel
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
 * 1. When you need to automatically remove backgrounds from a large set of product photos stored as JPEGs and generate transparent PNGs for e‑commerce listings.
 * 2. When a photo‑editing application must apply a quick selection mask to dozens of images based on a reference pixel and preserve the result with an alpha channel.
 * 3. When a migration script has to convert scanned JPEG documents into masked PNG assets for use in a web portal that requires transparency.
 * 4. When a game‑development pipeline requires batch processing of texture JPEGs to create masked PNG sprites with per‑pixel opacity.
 * 5. When an automated reporting tool must preprocess a fixed number of camera images, apply a Magic Wand selection, and store the masked outputs in a separate folder for downstream analysis.
 */
