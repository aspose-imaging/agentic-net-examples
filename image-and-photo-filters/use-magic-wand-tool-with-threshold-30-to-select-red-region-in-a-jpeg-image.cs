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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Select the red region using Magic Wand with a threshold of 30
            // Adjust the point coordinates (e.g., 10,10) to a pixel that lies within the red area
            MagicWandTool
                .Select(image, new MagicWandSettings(10, 10) { Threshold = 30 })
                .Apply();

            // Save the result as a PNG with alpha channel to preserve transparency
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}