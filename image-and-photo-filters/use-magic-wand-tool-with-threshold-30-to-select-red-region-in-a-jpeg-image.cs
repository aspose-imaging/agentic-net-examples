using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output\\result.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure Magic Wand settings: reference point (100,100) and threshold 30
                var settings = new MagicWandSettings(100, 100) { Threshold = 30 };

                // Create a mask for the red region and apply it to the image
                MagicWandTool.Select(image, settings).Apply();

                // Save the processed image as JPEG
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to automatically isolate and edit the red logo on product photos stored as JPEGs for e‑commerce catalogs.
 * 2. When a developer wants to create a mask that extracts red traffic signs from street‑view JPEG images before applying further analysis.
 * 3. When a developer must remove or replace a red background in scanned receipt JPEG files for data‑extraction pipelines.
 * 4. When a developer is building a batch process that highlights red defect areas on manufactured parts captured in JPEG images for quality control.
 * 5. When a developer needs to generate a transparent PNG from a JPEG by selecting the red region with a Magic Wand threshold of 30 for use in UI overlays.
 */