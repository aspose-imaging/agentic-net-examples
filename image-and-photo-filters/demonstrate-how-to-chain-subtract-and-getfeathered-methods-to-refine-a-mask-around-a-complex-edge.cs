using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and refine the mask using Subtract and GetFeathered
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))               // initial selection
                    .Subtract(new MagicWandSettings(150, 150) { Threshold = 30 }) // remove unwanted area
                    .Subtract(new RectangleMask(200, 200, 50, 50))                // further subtraction with rectangle
                    .GetFeathered(new FeatheringSettings() { Size = 5 })         // soften edges
                    .Apply();                                                    // apply mask to the image

                // Save the result as PNG with alpha channel
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}