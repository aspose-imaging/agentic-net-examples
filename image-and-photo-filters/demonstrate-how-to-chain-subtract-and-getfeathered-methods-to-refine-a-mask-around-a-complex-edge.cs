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
        // Define input and output file paths
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

        // Load the image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create and refine mask using Magic Wand: subtract operations followed by feathering
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 80))                     // initial selection point
                .Subtract(new MagicWandSettings(300, 200) { Threshold = 40 })    // subtract unwanted region
                .Subtract(new RectangleMask(50, 50, 120, 80))                    // further subtraction with rectangle
                .GetFeathered(new FeatheringSettings() { Size = 5 })            // feather the mask edges
                .Apply();                                                       // apply mask to the image

            // Save the resulting image with transparent PNG options
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}