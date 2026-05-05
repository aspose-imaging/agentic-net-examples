using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\combined_mask.png";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // First magic wand selection at point (120, 80)
                var firstMask = MagicWandTool.Select(image, new MagicWandSettings(120, 80));

                // Union with a second selection at point (300, 200)
                var combinedMask = firstMask.Union(new MagicWandSettings(300, 200));

                // Apply the combined mask to the image
                combinedMask.Apply();

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the result as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}