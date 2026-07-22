using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the high‑resolution TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply a mask (starting from an arbitrary point) and feather it with a radius of 5 pixels
                MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .GetFeathered(new FeatheringSettings { Size = 5 })
                    .Apply();

                // Save the processed image as TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to smooth the edges of a selection mask on a high‑resolution TIFF scanned document before saving it, they can use GetFeathered with a 5‑pixel radius to create a professional‑looking result.
 * 2. When preparing satellite imagery in TIFF format for overlay analysis, applying a 5‑pixel feather to the mask prevents harsh transitions and improves visual blending.
 * 3. When cleaning up scanned architectural blueprints, a C# routine that loads the TIFF, selects an area with MagicWand, and feathers the mask by 5 pixels helps eliminate jagged edges around cut‑outs.
 * 4. When generating printable marketing materials from large TIFF photographs, feathering the mask by 5 pixels ensures smooth borders around cropped sections, reducing artifacts in the final output.
 * 5. When automating a batch process that extracts regions of interest from high‑resolution medical TIFF scans, using GetFeathered with a 5‑pixel radius creates soft edges that are easier for downstream analysis tools to handle.
 */