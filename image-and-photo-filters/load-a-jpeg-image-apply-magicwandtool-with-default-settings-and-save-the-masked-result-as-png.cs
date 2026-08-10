// HOW-TO: Create PNG Mask From JPEG Using MagicWandTool In C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

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
                // Create a mask using MagicWandTool with default settings (reference point at 0,0)
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a region of a JPEG and export it as a transparent PNG for web overlays.
 * 2. When you want to generate a mask automatically from the top‑left pixel of an image to create cut‑out graphics.
 * 3. When building a batch process that converts scanned JPEG photos into PNG assets with alpha for UI icons.
 * 4. When integrating Aspose.Imaging into a C# application to isolate foreground objects and save them with transparency.
 * 5. When preparing product images for e‑commerce platforms that require PNGs with transparent backgrounds derived from original JPEGs.
 */
