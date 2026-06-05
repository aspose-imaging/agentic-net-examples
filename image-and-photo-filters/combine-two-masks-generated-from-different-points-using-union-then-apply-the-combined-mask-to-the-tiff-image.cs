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
        string inputImagePath = "input.tif";
        string outputImagePath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputImagePath))
        {
            Console.Error.WriteLine($"File not found: {inputImagePath}");
            return;
        }

        try
        {
            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputImagePath))
            {
                // Create first mask using Magic Wand at point (100, 150)
                ImageMask mask1 = MagicWandTool.Select(image, new MagicWandSettings(100, 150));

                // Create second mask using Magic Wand at point (300, 350)
                ImageMask mask2 = MagicWandTool.Select(image, new MagicWandSettings(300, 350));

                // Combine the two masks using Union
                ImageMask combinedMask = mask1.Union(mask2);

                // Apply the combined mask to the image
                combinedMask.Apply();

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath));

                // Save the modified image
                image.Save(outputImagePath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}