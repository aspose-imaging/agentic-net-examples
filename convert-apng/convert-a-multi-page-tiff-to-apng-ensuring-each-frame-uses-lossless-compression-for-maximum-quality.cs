using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page TIFF image
        using (Image tiffImage = Image.Load(inputPath))
        {
            // Configure APNG options for lossless compression (PNG compression is lossless)
            ApngOptions apngOptions = new ApngOptions
            {
                // No compression (level 0) keeps maximum quality while still being lossless
                PngCompressionLevel = 0,
                // Preserve alpha channel and truecolor data
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Save as APNG
            tiffImage.Save(outputPath, apngOptions);
        }
    }
}