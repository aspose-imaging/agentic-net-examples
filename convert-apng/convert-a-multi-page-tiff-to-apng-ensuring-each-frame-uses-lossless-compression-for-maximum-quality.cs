using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output\\result.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page TIFF
        using (Image image = Image.Load(inputPath))
        {
            // Configure APNG options for lossless compression
            var apngOptions = new ApngOptions
            {
                // Truecolor with alpha ensures full lossless PNG data
                ColorType = PngColorType.TruecolorWithAlpha
                // DefaultFrameTime can be left as default (uses source frame timings)
            };

            // Save as APNG
            image.Save(outputPath, apngOptions);
        }
    }
}