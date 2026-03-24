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
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Select region using Magic Wand at point (100, 100) with a threshold of 50
            MagicWandTool
                .Select(image, new MagicWandSettings(100, 100) { Threshold = 50 })
                .Apply();

            // Save the processed image as APNG
            image.Save(outputPath, new ApngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 200, // milliseconds per frame
                NumPlays = 0 // infinite loop
            });
        }
    }
}