using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create first mask using magic wand at point (100, 100)
                ImageBitMask mask1 = MagicWandTool.Select(image, new MagicWandSettings(100, 100));

                // Create second mask using magic wand at point (200, 200)
                ImageBitMask mask2 = MagicWandTool.Select(image, new MagicWandSettings(200, 200));

                // Union the two masks
                ImageBitMask combinedMask = mask1.Union(mask2);

                // Apply the combined mask to the image
                combinedMask.ApplyTo(image);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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