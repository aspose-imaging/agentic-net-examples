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
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Process 50 JPEG images named image1.jpg ... image50.jpg
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

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply magic wand mask, and save the result
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Create a mask using a reference point (10,10) and a custom threshold
                    MagicWandTool
                        .Select(image, new MagicWandSettings(10, 10) { Threshold = 100 })
                        .Apply();

                    // Save the masked image as PNG with alpha channel
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    };
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to batch‑process a set of JPEG photos and automatically remove backgrounds using the MagicWandTool, saving the results as PNGs with transparency.
 * 2. When an e‑commerce platform must generate product thumbnails with masked backgrounds from a catalog of 50 JPEG images, using C# and Aspose.Imaging to create PNG assets for web display.
 * 3. When a photo‑editing application wants to apply a custom threshold magic‑wand selection to multiple JPEG files and export the masked images to a designated output folder for further compositing.
 * 4. When a digital‑archiving workflow requires converting a batch of scanned JPEG documents into PNGs with alpha channels after isolating a region of interest via a reference point and threshold setting.
 * 5. When a marketing automation script needs to prepare a series of promotional images by extracting foreground objects from 50 JPEGs and saving the masked PNGs for use in layered designs.
 */