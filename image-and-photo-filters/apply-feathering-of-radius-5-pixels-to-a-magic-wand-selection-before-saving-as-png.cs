using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a magic wand mask, feather it with a radius of 5 pixels, and apply to the image
                MagicWandTool
                    .Select(image, new MagicWandSettings(0, 0)) // starting point for selection
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save the resulting image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}