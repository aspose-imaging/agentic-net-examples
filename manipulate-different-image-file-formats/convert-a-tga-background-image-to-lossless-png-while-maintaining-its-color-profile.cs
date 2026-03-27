using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output\\converted.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Prepare PNG options to keep metadata (color profile) and use lossless truecolor with alpha
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                KeepMetadata = true
            };

            // Save as lossless PNG
            image.Save(outputPath, pngOptions);
        }
    }
}